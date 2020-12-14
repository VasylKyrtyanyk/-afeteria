using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Сafeteria.DataModels.Entities.ValueObjects;

namespace Сafeteria.Infrastructure.Commands
{
    public class AddProductCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? FinalDate { get; set; }
        public double Weight { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public string ImageSrc { get; set; }
    }
}
