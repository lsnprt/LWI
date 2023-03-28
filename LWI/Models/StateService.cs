namespace LWI.Models
{
	public class StateService
	{
        IHttpContextAccessor Accessor;
		public StateService(IHttpContextAccessor accessor)
        {
            Accessor = accessor;
        }

        public string NoOfCartItems()
        {
            var cartCookie = Accessor.HttpContext.Request.Cookies["ShoppingCart"];
            if (cartCookie != null & cartCookie != "")
            {
                int noOfItems = cartCookie.Split(",").Length;
                return noOfItems.ToString();
            }
            return "";

		}
    }

}
