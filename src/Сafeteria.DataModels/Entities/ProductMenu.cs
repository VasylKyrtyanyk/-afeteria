namespace Сafeteria.DataModels.Entities
{
    public class ProductMenu
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
