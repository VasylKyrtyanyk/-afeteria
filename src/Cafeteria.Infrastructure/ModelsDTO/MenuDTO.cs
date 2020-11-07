using System;
using System.Collections.Generic;

namespace Сafeteria.Infrastructure.ModelsDTO
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MenuDate { get; set; }
        public List<ProductMenuDTO> ProductMenus { get; set; }
    }
}
