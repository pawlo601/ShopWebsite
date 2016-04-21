namespace ShopWebsite.Data.Services.Interfaces
{
    public interface IDatabaseService
    {
        void SavaAllProductsToXml();
        void SaveAllOrdersToXml();
        void DropAllTables();
        void DeleteAllProducts();
        void DeleteAllOrders();
        void LoadProductsFromXml();
        void LoadOrdersFromXml();
    }
}
