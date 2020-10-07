using System;
using System.Collections.Generic;
using Сafeteria.DataModels.Entities.Abstraction;
using Сafeteria.DataModels.Entities.ValueObjects;

namespace Сafeteria.DataModels.Entities
{
    public class Order: IEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalSum { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public bool IsTakeAway { get; set; } = false; // Means that the user want to takeaway his order
        public User User { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
    }
}
