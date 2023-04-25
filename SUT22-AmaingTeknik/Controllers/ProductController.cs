using AmazingTeknikModels;
using Microsoft.AspNetCore.Mvc;
using SUT22_AmaingTeknik.Services;

namespace SUT22_AmaingTeknik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IAmazingTeknik<Product> _amazingTeknik;
        // Dependency Injection
        public ProductController(IAmazingTeknik<Product> amazingTeknik)
        {
            this._amazingTeknik = amazingTeknik;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                return Ok(await _amazingTeknik.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retriev data from Database...");
            }
        }
        
    }
}
