using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.BusinessLayer.Abstracts;
using RestaurantApp.DtoLayer.TestimonialDto;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _service;
        private readonly IMapper _mapper;

        public TestimonialsController(ITestimonialService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _service.TGetListAll();
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto dto)
        {
            var map = _mapper.Map<Testimonial>(dto);

            _service.TAdd(map);
            return Ok("İşlem başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto dto)
        {
            var map = _mapper.Map<Testimonial>(dto);
            _service.TUpdate(map);
            return Ok("Güncellendi");

        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _service.TGetById(id);
            return Ok(_mapper.Map<GetTestimonialDto>(value));
        }
    }
}
