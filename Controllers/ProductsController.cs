using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceApplication2.DataContext.UnitOfWork;
using EcommerceApplication2.Entities;
using EcommerceApplication2.Resources;
using EcommerceApplication2.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication2.Controllers
{
      [Route("/api/products")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ProductsController(IProductRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;

        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllProduct()
        {
            var products = await repository.GetAll();

            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

        }
        [HttpGet("{id}/pictures")]
        public async Task<IActionResult> GetProductByPicture(int id)
        {
            var products = await repository.GetProductWithPicture(id);

               if (products == null)
                return NotFound();

            var pictureResource = mapper.Map<Product, ProductPictureResource>(products);

            return Ok(pictureResource);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await repository.GetById(id);

            if (product == null)
                return NotFound();

            var productResource = mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]SaveProductResource productResource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = mapper.Map<SaveProductResource, Product>(productResource);
            //customer.SignupDate = DateTime.Now; Add the Product Create in the future??

            repository.Insert(product);
            await unitOfWork.CompleteAsync();

            product = await repository.GetById(product.Id);

            var result = mapper.Map<Product, ProductResource>(product);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody]SaveProductResource productResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await repository.GetById(id);

            if (product == null)
                return NotFound();

            mapper.Map<SaveProductResource, Product>(productResource, product);
            //customer.SignupDate = DateTime.Now; MIGHT NEED TO ADD SIGNUP DATE IN FEATURE

            await unitOfWork.CompleteAsync();

            product = await repository.GetById(product.Id);
            var result = mapper.Map<Product, SaveProductResource>(product);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await repository.GetById(id);

            if (product == null)
                return NotFound();

            repository.Remove(product);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}
