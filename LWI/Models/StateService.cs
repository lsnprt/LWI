using System.Diagnostics.Tracing;
using System.Text.RegularExpressions;
using Azure;

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
            if (cartCookie != null & cartCookie != "," & cartCookie != "")
            {
                int noOfItems = cartCookie.Substring(1).Split(",").Length;
                return noOfItems.ToString();
            }
            return "0";

		}

		internal int[] GetCartIds()
		{
			var cartCookie = Accessor.HttpContext.Request.Cookies["ShoppingCart"];
			if (cartCookie != null & cartCookie != "," & cartCookie != "")
			{
				string[] cartStrIdArr = cartCookie.Substring(1).Split(",");
                List<int> intList = new List<int>();
                foreach (var item in cartStrIdArr)
                {
                    int n;
                    if (int.TryParse(item, out n))
                        intList.Add(n);
                }
                return intList.ToArray();
			}
			return new int[0];
			
		}

		internal void RemoveFromCart(int id)
		{
			string cartCookie = Accessor.HttpContext.Request.Cookies["ShoppingCart"];
			string pattern = $",{id}";
			var rgx = new Regex(pattern);
			var result = rgx.Replace(cartCookie, "", 1);
			Accessor.HttpContext.Response.Cookies.Append("ShoppingCart", result);
		}
	}

}
