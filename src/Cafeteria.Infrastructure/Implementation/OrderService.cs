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
using Сafeteria.Services.Common.Exeptions;

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
                throw new NotFoundException(nameof(Order), orderId.ToString());
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

        public async Task<OrderDTO> Add(CreateOrderCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("Command can't be null");
            }

            var order = new Order()
            {
                UserId = command.UserId,
                CreatedDate = DateTime.Now,
                CompletedDate = command.CompletedDate,
                PaymentType = command.PaymentType,
                OrderStatus = command.OrderStatus,
                IsTakeAway = command.IsTakeAway
            };

            foreach (var item in command.OrderProducts)
            {
                Product product = await _unitOfWork.ProductRepository.Get(item.ProductId);
                order.TotalSum += product.Price;
            }
            await _unitOfWork.OrderRepository.Add(order);
            await _unitOfWork.Save();

            order.ProductOrders = new List<ProductOrder>();

            foreach (var item in command.OrderProducts)
            {
                order.ProductOrders.Add(new ProductOrder() { OrderId = order.Id, ProductId = item.ProductId });
            }
            await _unitOfWork.Save();

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<bool> DeleteById(int orderId)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.Get(orderId);

                if (order == null)
                {
                    _logger.LogError($"Couldn't get order from the data base. OrderId: {orderId}");
                    throw new NotFoundException(nameof(Order), orderId.ToString());
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

        public async Task<OrderDTO> Update(int orderId, UpdateOrderCommand updateOrderCommand)
        {
            Order order = await _unitOfWork.OrderRepository.Get(orderId);
            if (order == null || order.UserId != updateOrderCommand.UserId)
            {
                _logger.LogError($"Couldn't find order in database. OrderId: {orderId}");
                throw new NotFoundException(nameof(Order), orderId.ToString());
            }

            order.CompletedDate = updateOrderCommand.CompletedDate;
            order.PaymentType = updateOrderCommand.PaymentType;
            order.OrderStatus = updateOrderCommand.OrderStatus;
            order.IsTakeAway = updateOrderCommand.IsTakeAway;

            await _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.Save();

            return _mapper.Map<OrderDTO>(order);
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
