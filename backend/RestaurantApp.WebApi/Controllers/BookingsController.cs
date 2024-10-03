using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.BusinessLayer.Abstracts;
using RestaurantApp.DtoLayer.BookingDto;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _service;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _service.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto dto)
        {
            var map = _mapper.Map<Booking>(dto);

            _service.TAdd(map);
            return Ok("İşlem başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto dto)
        {
            var map = _mapper.Map<Booking>(dto);
            _service.TUpdate(map);
            return Ok("Güncellendi");

        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _service.TGetById(id);
            return Ok(_mapper.Map<GetBookingDto>(value));
        }
    }
}
