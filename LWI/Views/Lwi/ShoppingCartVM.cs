namespace LWI.Views.Lwi
{
    public class ShoppingCartVM
    {
        public ShoppingCartItemVM[] shoppingCartItemVMs { get; set; }

        public string Total { get; set; }

        public int ItemCount { get; set; }
    }

    public class ShoppingCartItemVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
		public string Price { get; set; }
        public string? ImgName { get; set; }
        public string? ImgAlt { get; set; }
		public string? Category { get; set; }
        public bool IsEco { get; set; }
    }
}
