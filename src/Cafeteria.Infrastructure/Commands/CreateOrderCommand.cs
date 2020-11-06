using System;
using System.Collections.Generic;
using Сafeteria.DataModels.Entities.ValueObjects;

namespace Сafeteria.Infrastructure.Commands
{
    public class CreateOrderCommand
    {
        // TODO
        public int UserId { get; set; }
        // public decimal TotalSum { get; set; } // We should count it
        // public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public bool IsTakeAway { get; set; }
        public List<CreateOrderProductsCommand> OrderProducts { get; set; }
    }

    public class CreateOrderProductsCommand
    {
        public int ProductId { get; set; }
    }
}
