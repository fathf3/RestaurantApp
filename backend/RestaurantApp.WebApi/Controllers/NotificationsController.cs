using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.BusinessLayer.Abstracts;
using RestaurantApp.DtoLayer.NotificationDto;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _service;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _service.TGetListAll();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto dto)
        {
            dto.Status = false;
            dto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var map = _mapper.Map<Notification>(dto);

            _service.TAdd(map);
            return Ok("İşlem başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto dto)
        {

            var map = _mapper.Map<Notification>(dto);
            _service.TUpdate(map);
            return Ok("Güncellendi");

        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _service.TGetById(id);
            return Ok(_mapper.Map<GetNotificationDto>(value));
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_service.NotificationCountByStatusFalse());
        }
        [HttpGet("GetAllNotificationsByFalse")]
        public IActionResult GetAllNotificationsByFalse()
        {
            return Ok(_service.GetAllNotificationsByFalse());
        }
        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            var value = _service.TGetById(id);
            value.Status = true;
            _service.TUpdate(value);
            return Ok();

        }
        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            var value = _service.TGetById(id);
            value.Status = false;
            _service.TUpdate(value);
            return Ok();

        }
    }
}
