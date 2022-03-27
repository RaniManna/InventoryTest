using Inventory.API.DTOs.Product;
using Inventory.API.DTOs.Result;
using Inventory.API.Services.Products;
using Inventory.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService) : base()
        {
            _productService = productService;
        }

        /// <summary>
        /// Count the number of products grouped by status
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Products/Count")]
        [ProducesResponseType(statusCode: 200, Type = typeof(ApiResult<Dictionary<string, List<ProductCountByStatusDTO>>>))]
        [ProducesResponseType(statusCode: 500)]
        public async Task<IActionResult> GetProductsCountByStatus()
        {
            var products = await _productService.GetProductCountByStatus();
            return SendResponse(products, "Products Count Retrieved Successfully");
        }

        /// <summary>
        /// update product status
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:int}/ChangeStatus")]
        [ProducesResponseType(statusCode: 200, Type = typeof(ApiResult<GetProductDTO>))]
        [ProducesResponseType(statusCode: 500)]
        public async Task<IActionResult> UpdateStatus([Required] long id, [FromForm] UpdateProductDTO updateProductDTO)
        {
            var products = await _productService.UpdateProductStatus(id, updateProductDTO);
            return SendResponse(products, "Product status changed successfully");
        }

        /// <summary>
        /// sell product
        /// </summary>
        /// <returns></returns>
        [HttpPost("Sell")]
        [ProducesResponseType(statusCode: 200, Type = typeof(ApiResult<GetProductDTO>))]
        public async Task<IActionResult> SellProduct([FromForm] SellProductDTO sellProductDTO)
        {
            var product = await _productService.SellProduct(sellProductDTO);
            return SendResponse(product, "Product selled Successfully");
        }

    }
}
