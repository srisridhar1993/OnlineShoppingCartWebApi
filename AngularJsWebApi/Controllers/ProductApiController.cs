using OnlineShop.IBLL;
using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AngularJsWebApi.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductApiController : ApiController
    {
        IProduct iproduct;
        
        public ProductApiController(IProduct _iproduct)
        {
            iproduct = _iproduct;
        }
        [HttpPost]
        [Route("GetAllProductList")]
        public async Task<HttpResponseMessage> GetAllProductList(SearchProduct search)
        {
            List<ProductDetails> productList = new List<ProductDetails>();
            try
            {
                await Task.Run(() =>
                {
                    productList= iproduct.GetAllProductList(search);
                });
                if(productList!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, productList);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { StatusCode = HttpStatusCode.NotFound, Status = "Failed" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("SaveProductDetails")]
        public async Task<HttpResponseMessage> SaveProductDetails(ProductDetails product)
        {
            ProductModel prodModel = new ProductModel();
            try
            {
                await Task.Run(() =>
                {
                    prodModel = iproduct.AddNewProduct(product);
                });
                return Request.CreateResponse(HttpStatusCode.OK, prodModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAllCategoryList")]
        public async Task<HttpResponseMessage> GetAllCategoryList(int categoryId,int parentCategoryId)
        {
            try
            {
                List<M_Category> list = new List<M_Category>();
                await Task.Run(() =>
                {
                    list = iproduct.GetAllCategoryList(categoryId,parentCategoryId);
                });
                return Request.CreateResponse(HttpStatusCode.OK, list); 
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAllBrandList")]
        public async Task<HttpResponseMessage> GetAllBrandList(int brandId)
        {
            try
            {
                List<M_Brand> list = new List<M_Brand>();
                await Task.Run(() =>
                {
                    list = iproduct.GetAllBrandList(brandId);
                });
                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("UploadProductImage")]
        public async Task<HttpResponseMessage> UploadProductImages(M_ProductImage images)
        {
            try
            {
                M_ProductImage proImg = await Task.Run(() => iproduct.UploadProductImage(images));
                if(proImg!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, proImg);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { StatusCode=HttpStatusCode.BadRequest,Status="Failed" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
