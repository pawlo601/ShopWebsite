using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Data.Services.Interfaces
{
    public interface IProductService
    {
        Product GetProduct(int id, out TransactionalInformation transaction);
        Product CreateProduct(Product product, out TransactionalInformation transaction);
        void DeleteProduct(Product product, out TransactionalInformation transaction);
        void DeleteProduct(Expression<Func<Product, bool>> where, out TransactionalInformation transaction);
        IEnumerable<Product> GetAllProducts(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows, out TransactionalInformation transaction);
        IEnumerable<Product> GetAllProductsIf(Expression<Func<Product, bool>> where, int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows, out TransactionalInformation transaction);
        void UpdateEntity(Product entity, out TransactionalInformation transaction);
        Product GetIf(Expression<Func<Product, bool>> where, out TransactionalInformation transaction);
        void SaveProduct();
    }
}
