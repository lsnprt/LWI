namespace LWI.Views.Lwi
{
    public class ShoppingCartVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
		public decimal? Price { get; set; }
        public string? ImgName { get; set; }
        public string? ImgAlt { get; set; }
		public string? Category { get; set; }
    }
}
