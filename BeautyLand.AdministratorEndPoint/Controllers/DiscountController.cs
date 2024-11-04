using BeautyLand.Application.Services.Administrator.Discounts.GetDiscount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.AdministratorEndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        //[HttpGet]
        //[Route("SearchUser")]
        //public async Task<IActionResult> SearchUser(string term)
        //{
        //    return Ok(_discountService.GetUser(term));
        //}

        //[HttpGet]
        //[Route("SearchBrand")]
        //public async Task<IActionResult> SearchBrand(string term)
        //{
        //    return Ok(_discountService.GetBrand(term));
        //}

        //[HttpGet]
        //[Route("SearchType")]
        //public async Task<IActionResult> SearchType(string term)
        //{
        //    return Ok(_discountService.GetType(term));
        //}

        [HttpGet]
        [Route("SearchItem")]
        public async Task<IActionResult> SearchItem(string term)
        {
            return Ok(_discountService.GetItem(term)); 
        }
     
    }
}
