using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.DataContext
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
