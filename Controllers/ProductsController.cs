using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Models;
using backend.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller {
        private readonly AllChargersDbContext context;
        private readonly IMapper mapper;

        public ProductsController(AllChargersDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
        [Authorize(Roles = "kees")]
        public async Task<IActionResult> UploadProduct([FromBody] ProductIn productIn) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            Product product = mapper.Map<ProductIn, Product>(productIn);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public IActionResult GetProducts() {
            var products = context.Products.ToList();
            products.Sort((a,b) => DateTime.Compare(b.Date, a.Date));
            return Ok(mapper.Map<List<Product>, List<ProductOut>>(products));
        }
    }
}