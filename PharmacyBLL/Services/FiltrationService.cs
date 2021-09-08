using PharmacyBLL.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyBLL.Services
{
    public class FiltrationService
    {
        public IEnumerable<ProductDTO> FilterByFirm(IEnumerable<ProductDTO> products, string firmName)
        {
            if (products == null)
                return null;
            var result = products.Where(p => p.Firm == firmName);
            return result;
        }

        public IEnumerable<ProductDTO> FilterByAvailability(IEnumerable<ProductDTO> products, bool IsStockOnly)
        {
            if (products == null)
                return null;

            if (IsStockOnly)
                products = products.Where(p => p.Count > 0);

            return products;
        }


        public IEnumerable<ProductDTO> FilterByType(IEnumerable<ProductDTO> products, string typeName)
        {
            if (products == null)
                return null;
            var result = products.Where(p => p.Subtype.Type.Name==typeName);
            return result;
        }

        public IEnumerable<ProductDTO> FilterBySubtype(IEnumerable<ProductDTO> products, string subtypeName)
        {
            if (products == null)
                return null;
            var result = products.Where(p => p.Subtype.Name == subtypeName);
            return result;
        }

    }
}
