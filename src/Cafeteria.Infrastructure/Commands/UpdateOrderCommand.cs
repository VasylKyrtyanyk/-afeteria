using System;
using System.Collections.Generic;
using Сafeteria.DataModels.Entities.ValueObjects;
using Сafeteria.Infrastructure.ModelsDTO;

namespace Сafeteria.Infrastructure.Commands
{
    public class UpdateOrderCommand
    {
        //TODO
        public int UserId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public bool IsTakeAway { get; set; } = false; // Means that the user want to takeaway his order
    }
}
