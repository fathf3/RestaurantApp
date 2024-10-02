using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.BusinessLayer.Abstracts;
using RestaurantApp.DtoLayer.AboutDto;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _service;

        public AboutController(IAboutService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _service.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto dto)
        {
            About about = new About()
            {
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Title = dto.Title,
            };

            _service.TAdd(about);
            return Ok("İşlem başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto dto)
        {
            About about = new About()
            {
                Id = dto.Id,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Title = dto.Title,
            };
            _service.TUpdate(about);
            return Ok("Güncellendi");

        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _service.TGetById(id);
            return Ok(value);
        }
    }
}
