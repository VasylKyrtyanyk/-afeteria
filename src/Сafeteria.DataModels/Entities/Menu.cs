using System;
using System.Collections.Generic;
using Сafeteria.DataModels.Entities.Abstraction;

namespace Сafeteria.DataModels.Entities
{
    public class Menu: IEntity<int>
    {
        public int Id { get; set; }
        public DateTime MenuDate { get; set; }
        public List<ProductMenu> ProductMenus { get; set; }
    }
}
