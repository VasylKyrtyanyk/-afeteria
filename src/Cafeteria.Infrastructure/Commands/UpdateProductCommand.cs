using System;
using Сafeteria.DataModels.Entities.ValueObjects;

namespace Сafeteria.Infrastructure.Commands
{
    public class UpdateProductCommand
    {
        // TODO
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? FinalDate { get; set; }
        public double Weight { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
