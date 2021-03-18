using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IBLL
{
    public interface IProduct
    {
        ProductModel AddNewProduct(ProductDetails produt);
        List<ProductDetails> GetAllProductList(SearchProduct search);
        List<M_Category> GetAllCategoryList(int categoryId, int parentCategoryId);
        List<M_Brand> GetAllBrandList(int brandId);
        M_ProductImage UploadProductImage(M_ProductImage image);
    }
}
