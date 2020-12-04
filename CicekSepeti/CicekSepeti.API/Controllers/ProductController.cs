using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CicekSepeti.API.DTO;
using CicekSepeti.Domain.Entities;
using CicekSepeti.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CicekSepeti.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        public ProductController(ILogger<ProductController> logger, IProductService productService, IMapper mapper)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProductDTO>> Get()
        {
            _logger.LogInformation("testlog123");
            var product = await _productService.GetAllProducts();

            var musicResource = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(product);
            return Ok(musicResource);


        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Kaydet([FromBody]ProductDTO productDTO)
        {
            _logger.LogInformation("testlog123");
            var product = await _productService.GetAllProducts();

            var musicResource = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(product);
            return Ok(musicResource);


        }
    }
}