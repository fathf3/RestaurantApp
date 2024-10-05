using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.BusinessLayer.Abstracts;
using RestaurantApp.DtoLayer.DiscountDto;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _service;
        private readonly IMapper _mapper;

        public DiscountsController(IDiscountService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _service.TGetListAll();
            return Ok(_mapper.Map<List<ResultDiscountDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto dto)
        {
            var map = _mapper.Map<Discount>(dto);

            _service.TAdd(map);
            return Ok("İşlem başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto dto)
        {
            var map = _mapper.Map<Discount>(dto);
            _service.TUpdate(map);
            return Ok("Güncellendi");

        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _service.TGetById(id);
            return Ok(_mapper.Map<GetDiscountDto>(value));
        }
        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _service.TChangeStatusToTrue(id);
            return Ok("Ürün İndirimi Aktif Hale Getirildi");
        }

        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _service.TChangeStatusToFalse(id);
            return Ok("Ürün İndirimi Pasif Hale Getirildi");
        }

        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {
            return Ok(_service.TGetListByStatusTrue());
        }
    }
}
