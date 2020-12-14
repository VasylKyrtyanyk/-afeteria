using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Сafeteria.DataModels.Entities;
using Сafeteria.Infrastructure.Abstraction;
using Сafeteria.Infrastructure.Commands;
using Сafeteria.Infrastructure.ModelsDTO;
using Сafeteria.Services;
using Сafeteria.Services.Common.Exeptions;

namespace Сafeteria.Infrastructure.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ProductService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<ProductService> logger,
            IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
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

                product.ImageName = await SaveImage(product.ImageFile);

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

        public async Task<ProductDTO> Update(int productId, UpdateProductCommand updateProductCommand)
        {
            Product product = await _unitOfWork.ProductRepository.Get(productId);
            if (product == null)
            {
                _logger.LogError($"Couldn't find product in database. ProductId: {productId}");
                throw new NotFoundException(nameof(Product), productId.ToString());
            }

            product.Description = updateProductCommand.Description;
            product.Price = updateProductCommand.Price;
            product.FinalDate = updateProductCommand.FinalDate;
            product.Weight = updateProductCommand.Weight;
            product.ProductCategory = updateProductCommand.ProductCategory;


            if (!String.IsNullOrEmpty(updateProductCommand.ImageName)
                && updateProductCommand.ImageFile != null)
            {
                DeleteImage(updateProductCommand.ImageName);
                product.ImageName = await SaveImage(updateProductCommand.ImageFile);
            }

            await _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.Save();

            return _mapper.Map<ProductDTO>(product);
        }
        public async Task<bool> DeleteById(int productId)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.Get(productId);

                if (product == null)
                {
                    _logger.LogError($"Couldn't get product from the database. ProductId: {productId}");
                    return false;
                }

                if (!String.IsNullOrEmpty(product.ImageName))
                {
                    DeleteImage(product.ImageName);
                }

                await _unitOfWork.ProductRepository.Remove(product);
                await _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Couldn't delete product from the database.");
                return false;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _unitOfWork.ProductRepository.GetAll();

            if (products == null || !products.Any())
            {
                _logger.LogError("Couldn't find products in the database.");
            }

            var httpContext = _httpContextAccessor.HttpContext.Request;

            var productsResult = _mapper.Map<IEnumerable<ProductDTO>>(products);
            productsResult.Select(x => new ProductDTO
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                FinalDate = x.FinalDate,
                Weight = x.Weight,
                ProductCategory = x.ProductCategory,
                ImageName = x.ImageName,
                ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", httpContext.Scheme, httpContext.Host, httpContext.PathBase, x.ImageName)
            });

            return productsResult;
        }

        public async Task<ProductDTO> GetById(int productId)
        {
            var product = await _unitOfWork.ProductRepository.GetProductWithDetails(productId);

            if (product == null)
            {
                _logger.LogError($"Couldn't get product from the database. ProductId: {productId}");
                throw new NotFoundException(nameof(Product), productId.ToString());
            }

            var httpContext = _httpContextAccessor.HttpContext.Request;

            var result = _mapper.Map<ProductDTO>(product);

            result.ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", httpContext.Scheme, httpContext.Host, httpContext.PathBase, product.ImageName);

            return result;
        }

        private async Task<string> SaveImage(IFormFile formFile)
        {
            var imageName = new String(Path.GetFileNameWithoutExtension(formFile.FileName).ToArray());
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(formFile.FileName);
            var imagePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }

            return imageName;
        }

        private void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Images", imageName);
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }
    }
}
