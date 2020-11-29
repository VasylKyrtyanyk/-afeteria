using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Сafeteria.DataModels.Entities;
using Сafeteria.Infrastructure.Abstraction;
using Сafeteria.Infrastructure.Commands;
using Сafeteria.Infrastructure.ModelsDTO;
using Сafeteria.Services;

namespace Сafeteria.Infrastructure.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<MenuService> _logger;
        public MenuService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MenuService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MenuDTO> Add(AddMenuCommand command)
        {
            if (command == null)
            {
                // throw new ArgumentNullException();
            }

            var menu = new Menu() { Name = command.Name, MenuDate = command.MenuDate };

            await _unitOfWork.MenuRepository.Add(menu);
            await _unitOfWork.Save();

            menu.ProductMenus = new List<ProductMenu>();

            foreach (var item in command.ProductMenus)
            {
                menu.ProductMenus.Add(new ProductMenu() { MenuId = menu.Id, ProductId = item.ProductId });
            }
            await _unitOfWork.Save();

            return _mapper.Map<MenuDTO>(menu);
        }

        public async Task<MenuDTO> Update(int menuId, UpdateMenuCommand updateMenuCommand)
        {
            Menu menu = await _unitOfWork.MenuRepository.Get(menuId);
            if (menu == null)
            {
                _logger.LogError($"Couldn't find menu in database. MenuId: {menuId}");
                return null;
            }

            menu.Name = updateMenuCommand.Name;
            menu.MenuDate = updateMenuCommand.MenuDate;

            await _unitOfWork.MenuRepository.Update(menu);
            await _unitOfWork.Save();

            return _mapper.Map<MenuDTO>(menu);
        }

        public async Task<bool> DeleteById(int menuId)
        {
            try
            {
                var menu = await _unitOfWork.MenuRepository.Get(menuId);

                if (menu == null)
                {
                    _logger.LogError($"Couldn't get menu from the data base. MenuId: {menuId}");
                    return false;
                }

                await _unitOfWork.MenuRepository.Remove(menu);
                await _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Couldn't delete menu from the data base.");
                return false;
            }
        }

        public async Task<IEnumerable<MenuDTO>> GetAll()
        {
            var menus = await _unitOfWork.MenuRepository.GetAllMenusWithProductDetails();

            return _mapper.Map<IEnumerable<MenuDTO>>(menus);
        }

        public async Task<MenuDTO> GetByID(int menuId)
        {
            var menu = await _unitOfWork.MenuRepository.GetMenuWithProductDetails(menuId);

            if (menu == null)
            {
                _logger.LogError($"Couldn't get menu from the database. MenuId: {menuId}");
            }

            return _mapper.Map<MenuDTO>(menu);
        }
    }
}
