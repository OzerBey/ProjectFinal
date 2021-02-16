using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //route bu istegi yaparken bize nasıl ulaşsın demektir
    [ApiController] //Attribute denir buraya
    public class ProductsController : ControllerBase
    {
        //Loosely coupled :bagımlılılk var ama soyuta bagımlılık var
        //naming convention = isimlendirme standartıff
        //IoC Container : IoC :Inversion of control 
        private IProductService _productService; //bagımlı ama gevşek bagımlı yani tam bagımlı degil

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")] //http de istekte bulunursa datayı döndürebiliriz
        public IActionResult GetAll()
        {

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]// [HttpGet("getById")] alias veriyoruz (isimlendirme)
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        //silme ve güncelleme POST kullanılır
        [HttpPost("add")] //for post request
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
