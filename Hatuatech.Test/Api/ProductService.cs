using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Hatuatech.Test.Api
{
    public class ProductService : IProductService
    {
        private string ApiUrl { get; set; }
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        public ProductService(IConfiguration configuration,
            HttpClient httpClient,
            ILogger<ProductService> logger)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _logger = logger;
        }


        public async Task<ProductApiResponse> GetProducts(ProductApiRequest request)
        {
            try
            {
                ApiUrl = _configuration["ProductsApi:BaseUrl"];
                var url = $"{ApiUrl}{request.Path}";

                var results = await _httpClient.GetAsync(url);

                return new ProductApiResponse
                {
                    StatusCode = results.StatusCode,
                    Response = await results.Content.ReadAsStringAsync()
                };
            }
            catch (Exception e)
            {
                var exception = e.Message;
                _logger.LogCritical(e, "Could not fetch products api response {response}", exception);

                return new ProductApiResponse
                {
                    StatusCode = (HttpStatusCode)StatusCodes.Status400BadRequest,
                    Response = null
                };
            }
        }



        public class ProductApiRequest
        {
            public string Path { get; set; }
            public string Method { get; set; }
        }

        public class ProductApiResponse
        {
            public HttpStatusCode StatusCode { get; set; }
            public dynamic Response { get; set; }
        }

    }

}
