using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using OnlineShop.DataAccessLayer.Repository;

namespace OnlineShop.DataAccessLayer
{
    public class ProductDA : IProductDA
    {
        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineShopingEntities"].ToString());
        SqlCommand cmd;
       
        ProductModel IProductDA.AddNewProduct(ProductDetails product)
        {
            ProductModel prod = new ProductModel();
            try
            {
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("uspInsertUpdateProduct", connString);
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Tags", product.Tags);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("@BrandId", product.BrandId);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@TaxExcludedPrice", product.TaxExcludedPrice);
                cmd.Parameters.AddWithValue("@TaxIncludedPrice", product.TaxIncludedPrice);
                cmd.Parameters.AddWithValue("@TaxRate", product.TaxRate);
                cmd.Parameters.AddWithValue("@ComparedPrice", product.ComparedPrice);
                cmd.Parameters.AddWithValue("@SKU", product.SKU);
                cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@CreatedBy", product.CreatedBy);
                cmd.Parameters.AddWithValue("@Width", product.Width);
                cmd.Parameters.AddWithValue("@Height",product.Height);
                cmd.Parameters.AddWithValue("@Length",product.Length);
                cmd.Parameters.AddWithValue("@Weight",product.Weight);
                cmd.Parameters.AddWithValue("@Color",product.Color);
                cmd.Parameters.AddWithValue("@Debth",product.Depth);
                cmd.Parameters.AddWithValue("@ExtraShippingFees", product.ExtraShippingFees);
                //int a = cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Dispose();
                prod = ExtensionMethods.ConvertToListOf<ProductModel>(dt).FirstOrDefault();
                return prod;
            }
            catch (Exception ex)
            {
                return prod;
            }
            finally
            {
                connString.Close();
            }
        }

        List<ProductDetails> IProductDA.GetAllProductList(SearchProduct product)
        {
            List<ProductDetails> list = new List<ProductDetails>();
            try
            {
                DataSet ds = new DataSet();
                
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("uspGetProductList", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FuzzySearch",product.FuzzySearch);
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("@BrandId", product.BrandId);
                cmd.Parameters.AddWithValue("@FromPrice", product.FromPrice);
                cmd.Parameters.AddWithValue("@ToPrice", product.ToPrice);
                cmd.Parameters.AddWithValue("@StartIndex", product.StartIndex);
                cmd.Parameters.AddWithValue("@NumberOfRows", product.NumberOfRows);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                sda.Dispose();

                list = ExtensionMethods.ConvertToListOf<ProductDetails>(ds.Tables[0]);
                if(list!=null && list.Count>0 && ds.Tables.Count>1 && ds.Tables[1].Rows.Count>0)
                {
                    list[0].ProductImage = new List<M_ProductImage>();
                    list[0].ProductImage = ExtensionMethods.ConvertToListOf<M_ProductImage>(ds.Tables[1]);
                }

                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connString.Close();
            }
        }

        List<M_Category> IProductDA.SelectAllCategory(int categoryId, int parentCategoryId)
        {
            List<M_Category> list = new List<M_Category>();
            try
            {
                DataTable dt = new DataTable();
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("uspGetAllCategoryList", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@ParentCategoryId", parentCategoryId);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Dispose();

                list = ExtensionMethods.ConvertToListOf<M_Category>(dt);

                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
            finally
            {
                connString.Close();
            }
        }

        List<M_Brand> IProductDA.SelectAllBrand(int brandId)
        {
            List<M_Brand> list = new List<M_Brand>();
            try
            {
                
                DataTable dt = new DataTable();
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("uspGetAllBrandList", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BrandId", brandId);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Dispose();

                list = ExtensionMethods.ConvertToListOf<M_Brand>(dt);

                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
            finally
            {
                connString.Close();
            }
        }
        M_ProductImage IProductDA.UploadProductImages(M_ProductImage image)
        {
            try
            {
                DataTable dt = new DataTable();
                if (connString.State == ConnectionState.Closed)
                    connString.Open();
                cmd = new SqlCommand("uspUploadProductImages", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductImageId", image.ProductImageId);
                cmd.Parameters.AddWithValue("@ProductId", image.ProductId);
                cmd.Parameters.AddWithValue("@ProductImage", image.ProductImage);
                cmd.Parameters.AddWithValue("@CreatedBy", image.CreatedBy);
                cmd.Parameters.AddWithValue("@IsDefault", image.IsDefault);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sda.Dispose();

                M_ProductImage result = ExtensionMethods.ConvertToListOf<M_ProductImage>(dt).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
