using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Сafeteria.Infrastructure.Abstraction;
using Сafeteria.Infrastructure.ModelsDTO;
using Сafeteria.Services;

namespace Сafeteria.Infrastructure.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OrderDTO> GetById(int orderId)
        {
            var order = await _unitOfWork.OrderRepository.Get(orderId);

            if (order == null)
            {
                _logger.LogError($"Couldn't get order from the data base. OrderId: {orderId}");
            }

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var orders = await _unitOfWork.OrderRepository.GetAll();

            if (orders == null || !orders.Any())
            {
                _logger.LogError("Couldn't find orders in the data base.");
            }

            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<bool> DeleteById(int orderId)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.Get(orderId);

                if (order == null)
                {
                    _logger.LogError($"Couldn't get order from the data base. OrderId: {orderId}");
                    return false;
                }

                await _unitOfWork.OrderRepository.Remove(order);
                await _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Couldn't delete order from the data base.");
                return false;
            }
        }

        public async Task<IEnumerable<OrderDTO>> GetUserOrders(int userId)
        {
            var orders = await _unitOfWork.OrderRepository.GetUserOrders(userId);

            if (orders == null || !orders.Any())
            {
                _logger.LogError($"Couldn't get orders for user with id: {userId}");
            }

            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }
    }
}
