using System;
using System.Collections.Generic;

namespace Сafeteria.Infrastructure.Commands
{
    public class AddMenuCommand
    {
        public string Name { get; set; }
        public DateTime MenuDate { get; set; }
        public List<AddProductMenuCommand> ProductMenus { get; set; }
    }

    public class AddProductMenuCommand
    {
        public int ProductId { get; set; }
    }
}
