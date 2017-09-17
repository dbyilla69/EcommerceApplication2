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
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllCategory()
        {
            var categories = await repository.GetAll();

            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

        }

    }
}