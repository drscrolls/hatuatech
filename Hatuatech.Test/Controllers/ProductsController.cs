using System.Collections.Specialized;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Hatuatech.Test.Api;
using Hatuatech.Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hatuatech.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var url = "";
            var response = await _productService.GetProducts(new ProductService.ProductApiRequest
            {
                Method = HttpMethods.Get,
                Path = url
            });

            if (response != null)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var data = JsonSerializer.Deserialize<object>(response.Response);
                    return Ok(data);
                }
            }
            return BadRequest(response);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredProducts(string minprice, string maxprice, string size, string highlight)
        {
            var url = "";
            // if (!string.IsNullOrEmpty(maxprice) || !string.IsNullOrEmpty(size) || !string.IsNullOrEmpty(highlight))
            // {
            //     NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            //     
            //     if (!string.IsNullOrEmpty(maxprice))
            //         queryString.Add("maxprice", maxprice);
            //
            //     if (!string.IsNullOrEmpty(size))
            //         queryString.Add("size", size);
            //     
            //     if (!string.IsNullOrEmpty(highlight))
            //         queryString.Add("highlight", highlight);
            //
            //     url += queryString;
            // }
            
            // return Ok("Filter");
            
            var response = await _productService.GetProducts(new ProductService.ProductApiRequest
            {
                Method = HttpMethods.Get,
                Path = url
            });

            if (response != null)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var data = JsonSerializer.Deserialize<object>(response.Response);
                    if (!string.IsNullOrEmpty(maxprice))
                    {
                        
                    }
                        
                    return Ok(data);
                }
            }
            return BadRequest(response);
        }


    }
}