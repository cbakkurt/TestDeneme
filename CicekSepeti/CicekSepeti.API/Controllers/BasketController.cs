using AutoMapper;
using CicekSepeti.API.DTO;
using CicekSepeti.Domain.Entities;
using CicekSepeti.Service.IServices;
using CicekSepeti.Service.ResponseApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace CicekSepeti.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly ILogger<BasketController> _logger;
        private readonly IMapper _mapper;
        public BasketController(ILogger<BasketController> logger, IBasketService basketService, IMapper mapper)
        {
            _logger = logger;
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<BasketDTO>> GetBasket(Guid userId)
        {
            var baskets = await _basketService.GetAllBasketsByUserId(userId);


            var basketDto = _mapper.Map<IEnumerable<Basket>, IEnumerable<BasketDTO>>(baskets);


            return Json(basketDto);
        }

        //[HttpPost]
        //public async Task<ActionResult<BasketDTO>> AddBasket([FromBody] BasketDTO basketDTO)
        //{

        //    var basket = _mapper.Map<BasketDTO, Basket>(basketDTO);


        //    _logger.LogInformation("testlog123");
        //    var newBasket = await _basketService.AddBasket(basket);

        //    if (newBasket == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(basketDTO);
        //}

        //[HttpPost]
        //public async Task<ActionResult> AddBasket([FromBody] BasketDTO basketDTO)
        //{

        //    var basket = _mapper.Map<BasketDTO, Basket>(basketDTO);


        //    _logger.LogInformation("testlog123");
        //    //var newBasket = await _basketService.AddBasket(basket);
        //    ApiResponse newBasket = await _basketService.AddBasketApiResponse(basket);

        //    if (newBasket.StatusCode == 404)
        //    {
        //        return NotFound(new ApiNotFoundResponse(newBasket.Result));
        //    }

        //    return Ok(new ApiOkResponse(newBasket.Result));
        //}

        [HttpPost]
        public async Task<JsonResult> AddBasketJson([FromBody] BasketDTO basketDTO)
        {

            var basket = _mapper.Map<BasketDTO, Basket>(basketDTO);


            _logger.LogInformation("testlog123");
            //var newBasket = await _basketService.AddBasket(basket);
            var newBasket = await _basketService.AddBasketApiResponseTest(basket);

            return Json(newBasket);
            //if (newBasket.IsSuccess == false)
            //{
            //    return NotFound(newBasket.Message);
            //}

            //return Created("", basketDTO);
        }
        //[HttpPost]
        //public async Task<IActionResult> AddBasket([FromBody] BasketDTO basketDTO)
        //{

        //    var basket = _mapper.Map<BasketDTO, Basket>(basketDTO);


        //    _logger.LogInformation("testlog123");
        //    //var newBasket = await _basketService.AddBasket(basket);
        //    var newBasket = await _basketService.AddBasketApiResponseTest(basket);

        //    if (newBasket.IsSuccess == false)
        //    {
        //        return NotFound(newBasket.Message);
        //    }

        //    return Created("", basketDTO);
        //}
    }
}