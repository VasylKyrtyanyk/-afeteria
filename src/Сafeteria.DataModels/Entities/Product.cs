using System;
using System.Collections.Generic;
using Сafeteria.DataModels.Entities.Abstraction;
using Сafeteria.DataModels.Entities.ValueObjects;

namespace Сafeteria.DataModels.Entities
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? FinalDate { get; set; }
        public double Weight { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string ImageName { get; set; }
        public List<ProductMenu> ProductMenus { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
    }
}
