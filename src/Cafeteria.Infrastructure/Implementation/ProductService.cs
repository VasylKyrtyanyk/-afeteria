using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Сafeteria.DataModels.Entities;
using Сafeteria.Infrastructure.Abstraction;
using Сafeteria.Infrastructure.Commands;
using Сafeteria.Infrastructure.ModelsDTO;
using Сafeteria.Services;

namespace Сafeteria.Infrastructure.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductDTO> Add(AddProductCommand product)
        {
            _logger.LogInformation("Going to create a new ProductEntity");

            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException();
                }

                var productEntity = _mapper.Map<Product>(product);

                await _unitOfWork.ProductRepository.Add(productEntity);
                await _unitOfWork.Save();

                return await GetById(productEntity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to create a new ProductEntity");
                //TODO think about error handilng and implement it
                throw;
            }
        }

        public async Task<bool> DeleteById(int productId)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.Get(productId);

                if (product == null)
                {
                    _logger.LogError($"Couldn't get product from the data base. ProductId: {productId}");
                    return false;
                }

                await _unitOfWork.ProductRepository.Remove(product);
                await _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Couldn't delete product from the data base.");
                return false;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var orders = await _unitOfWork.ProductRepository.GetAll();

            if (orders == null || !orders.Any())
            {
                _logger.LogError("Couldn't find products in the database.");
            }

            return _mapper.Map<IEnumerable<ProductDTO>>(orders);
        }

        public async Task<ProductDTO> GetById(int productId)
        {
            var product = await _unitOfWork.ProductRepository.GetProductWithDetails(productId);

            if (product == null)
            {
                _logger.LogError($"Couldn't get product from the database. ProductId: {productId}");
            }

            return _mapper.Map<ProductDTO>(product);
        }
    }
}
