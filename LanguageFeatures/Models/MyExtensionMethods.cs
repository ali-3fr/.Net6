namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalCount(this IEnumerable<Product?> cart)
        {
            decimal total = 0;
            if (cart != null)
            {
                foreach (var item in cart)
                {
                    total += item?.Price ?? 0;
                }
            }
            
            return total;
        }
        public static IEnumerable<Product?> FilterByPrice(this IEnumerable<Product?> productEnum, decimal minPrice)
        {
            foreach(Product? prod in productEnum) 
            {
                if ((prod?.Price ?? 0) >= minPrice)
                {
                    yield return prod;
                }
            }
        }
    }
}
