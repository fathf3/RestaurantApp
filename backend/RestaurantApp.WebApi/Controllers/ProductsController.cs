using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.BusinessLayer.Abstracts;
using RestaurantApp.DataAccessLayer.Concretes;
using RestaurantApp.DtoLayer.ProductDto;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _service.TGetListAll();
            return Ok(_mapper.Map<List<ResultProductDto>>(values));
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                Id = y.Id,
                Name = y.Name,
                Status = y.Status,
                CategoryName = y.Category.Name
            });
            return Ok(values.ToList());
        }

        
        

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            var map = _mapper.Map<Product>(dto);

            _service.TAdd(map);
            return Ok("İşlem başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto dto)
        {
            var map = _mapper.Map<Product>(dto);
            _service.TUpdate(map);
            return Ok("Güncellendi");

        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _service.TGetById(id);
            return Ok(_mapper.Map<GetProductDto>(value));
        }
        [HttpGet("ProductCountByCategoryNameHamburger")]
        public IActionResult ProductCountByCategoryNameHamburger()
        {
            return Ok(_service.TProductCountByCategoryNameHamburger());
        }
        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            return Ok(_service.TGetProductCount());
        }
    }
}
