using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Model;
using Portfolio.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;
        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
        
        [HttpPost(Name = "Create")]
        public IActionResult Create([FromBody]PortfolioModel portfolioModel)
        {
            if(portfolioModel == null)
            {
                return BadRequest("portfolio object is null");

            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var portfolio = _portfolioService.GetByISIN(portfolioModel.ISIN);
            if (portfolio != null)
            {
                return BadRequest("portfolio already exist");
            }
            
            try
            {
                _portfolioService.Create(portfolioModel);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}