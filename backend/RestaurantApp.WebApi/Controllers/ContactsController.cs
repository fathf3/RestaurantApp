using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.BusinessLayer.Abstracts;

using RestaurantApp.DtoLayer.ContactDto;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;
        private readonly IMapper _mapper;

        public ContactsController(IContactService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _service.TGetListAll();
            return Ok(_mapper.Map<List<ResultContactDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto dto)
        {
            var map = _mapper.Map<Contact>(dto);

            _service.TAdd(map);
            return Ok("İşlem başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto dto)
        {
            var map = _mapper.Map<Contact>(dto);
            _service.TUpdate(map);
            return Ok("Güncellendi");

        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _service.TGetById(id);
            return Ok(_mapper.Map<GetContactDto>(value));
        }
    }
}
