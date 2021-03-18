using System;
using OnlineShop.IBLL;
using OnlineShop.Model;
using OnlineShop.DataAccessLayer.Repository;
using OnlineShop.DataAccessLayer;
using System.Collections.Generic;

namespace OnlineShop.BusinessLayer
{
    public class ProductManager : IProduct
    {
        IProductDA iProduct;
        public ProductManager(IProductDA _iProduct)
        {
            iProduct = _iProduct;
        }
        ProductModel IProduct.AddNewProduct(ProductDetails product)
        {
            try
            {
                return iProduct.AddNewProduct(product);
            }
            catch (Exception)
            {
                return new ProductModel();
            }
        }

        List<M_Brand> IProduct.GetAllBrandList(int brandId)
        {
            List<M_Brand> list = new List<M_Brand>();
            try
            {
                list = iProduct.SelectAllBrand(brandId);
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }

        List<M_Category> IProduct.GetAllCategoryList(int categoryId, int parentCategoryId)
        {
            List<M_Category> list = new List<M_Category>();
            try
            {
                list = iProduct.SelectAllCategory(categoryId, parentCategoryId);
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }

        List<ProductDetails> IProduct.GetAllProductList(SearchProduct search)
        {
            List<ProductDetails> list = new List<ProductDetails>();
            try
            {
                list = iProduct.GetAllProductList(search);
                return list;
            }
            catch (Exception)
            {
                return list;
            }
        }

        M_ProductImage IProduct.UploadProductImage(M_ProductImage image)
        {
            try
            {
                M_ProductImage proImg = iProduct.UploadProductImages(image);
                return proImg;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
