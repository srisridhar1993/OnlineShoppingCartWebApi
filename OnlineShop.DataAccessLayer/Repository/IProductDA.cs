using OnlineShop.Model;
using System.Collections.Generic;

namespace OnlineShop.DataAccessLayer.Repository
{
    public interface IProductDA
    {
        ProductModel AddNewProduct(ProductDetails product);
        List<ProductDetails> GetAllProductList(SearchProduct product);
        List<M_Category> SelectAllCategory(int categoryId, int parentCategoryId);
        List<M_Brand> SelectAllBrand(int brandId);
        M_ProductImage UploadProductImages(M_ProductImage image);
    }
}
