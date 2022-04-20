using System.Threading.Tasks;

namespace Hatuatech.Test.Api
{
    public interface IProductService
    {
        Task<ProductService.ProductApiResponse> GetProducts(ProductService.ProductApiRequest request);
    }
}
