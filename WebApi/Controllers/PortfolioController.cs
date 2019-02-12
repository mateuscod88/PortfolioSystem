using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Model;
using Portfolio.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IPortfolioAnaliticsService _portfolioAnaliticsService;
        public PortfolioController(IPortfolioService portfolioService, IPortfolioAnaliticsService portfolioAnaliticsService)
        {
            _portfolioService = portfolioService;
            _portfolioAnaliticsService = portfolioAnaliticsService;
        }

        [HttpGet("{isin}", Name = "GetByISIN")]
        public ActionResult<PortfolioModel> Get(string isin)
        {
            var portfolio = _portfolioService.GetByISIN(isin);
            if (portfolio == null)
            {
                return NotFound();
            }
            return portfolio;
        }
        [HttpGet( Name = "GetByISINandDate")]
        public ActionResult<IEnumerable<PortfolioModel>> Get(string isin, DateTime date)
        {
            var portfolio = _portfolioService.GetByISINAndDate(isin,date).ToList();
            if (portfolio.Count == 0)
            {
                return NotFound();
            }
            return portfolio;
        }
        [HttpGet("{isin}", Name = "GetLatestByISIN")]
        public ActionResult<PortfolioModel> GetLatestByISIN(string isin)
        {
            var portfolio = _portfolioService.GetLatestByISIN(isin);
            if (portfolio == null)
            {
                return NotFound();
            }
            return portfolio;
        }
        [HttpGet(Name = "GetAgreggations")]
        public ActionResult<PortfolioAnaliticsModel> GetAgreggations(string isin,DateTime date)
        {
            var portfolioAnaliticsModel = _portfolioAnaliticsService.GetByISINAndDate(isin, date);
            if(portfolioAnaliticsModel == null)
            {
                return NotFound();
            }

            return portfolioAnaliticsModel;
        }
        [HttpPost(Name = "Create")]
        public IActionResult Create([FromBody]PortfolioModel portfolioModel)
        {
            
            
            try
            {
                if (portfolioModel == null)
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

                _portfolioService.Create(portfolioModel);
                return CreatedAtRoute("GetByISIN",new { isin = portfolioModel.ISIN},portfolioModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{isin}", Name = "Update")]
        public ActionResult Update(string isin, [FromBody]PortfolioModel portfolioModel)
        {
            try
            {
                if (portfolioModel == null)
                {
                    return BadRequest("portfolio object is null");

                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                if (isin != portfolioModel.ISIN)
                {
                    return BadRequest();
                }

                var portfolio = _portfolioService.GetByISIN(portfolioModel.ISIN);
                if (portfolio == null)
                {
                    return NotFound();
                }

                _portfolioService.Update(isin, portfolioModel);
                return new NoContentResult();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }



        }
        [HttpDelete("{isin}")]
        public ActionResult Delete(string isin)
        {
            try
            {
                var portfolio = _portfolioService.GetByISIN(isin);
                if (portfolio == null)
                {
                    return NotFound();
                }
                _portfolioService.Delete(isin);
                return NoContent();
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }

    }
}