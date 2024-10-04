using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.BusinessLayer.Abstracts;
using RestaurantApp.DtoLayer.CategoryDto;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _service.TGetListAll();
            return Ok(_mapper.Map<List<ResultCategoryDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto dto)
        {
            var map = _mapper.Map<Category>(dto);

            _service.TAdd(map);
            return Ok("İşlem başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto dto)
        {
            var map = _mapper.Map<Category>(dto);
            _service.TUpdate(map);
            return Ok("Güncellendi");

        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _service.TGetById(id);
            return Ok(_mapper.Map<GetCategoryDto>(value));
        }
        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            
            return Ok(_service.TGetCategoryCount);
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_service.TActiveCategoryCount);
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            return Ok(_service.TPassiveCategoryCount);
        }
    }
}
