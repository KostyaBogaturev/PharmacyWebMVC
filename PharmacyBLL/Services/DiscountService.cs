using Newtonsoft.Json;
using PharmacyBLL.DTO;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyBLL.Services
{
    public class DiscountService
    {
        public async Task<IEnumerable<ProductDTO>> GetDiscountProductsAsync()
        {
            IEnumerable<ProductDTO> products;

            using (var sr = new StreamReader("../PharmacyBLL/DiscounteProducts.json"))
            {
                string json = await sr.ReadToEndAsync();
                products = JsonConvert.DeserializeObject<List<ProductDTO>>(json);
            }

            return products;
        }

        public async Task AddProductToDiscountAsync(ProductDTO product)
        {
            var products = await GetDiscountProductsAsync();

            await Task.Run(() =>
            {
               List<ProductDTO> result = products == null ? new List<ProductDTO>() : products.ToList();
               result.Add(product);

               using (var sw = new StreamWriter("../PharmacyBLL/DiscounteProducts.json"))
               {
                   var serializer = new JsonSerializer();
                   serializer.Serialize(sw, result);
               }
            });
        }


    }
}
