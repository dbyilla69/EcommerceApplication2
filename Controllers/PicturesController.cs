using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceApplication2.DataContext.UnitOfWork;
using EcommerceApplication2.Entities;
using EcommerceApplication2.Resources;
using EcommerceApplication2.Service.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EcommerceApplication2.Controllers
{
    [Route("api/pictures/products")]
    public class PicturesController : Controller
    {

        private readonly IHostingEnvironment host;

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly PictureSettings pictureSettings;
        private readonly IPictureRepository pictureRepository;
        private readonly IProductRepository productRepository;
        private readonly IPictureService pictureService;

        public PicturesController(IHostingEnvironment host, IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper, IPictureRepository pictureRepository, IOptionsSnapshot<PictureSettings> options, IPictureService pictureService)
        {
            this.pictureService = pictureService;
            this.productRepository = productRepository;
            this.pictureRepository = pictureRepository;
            this.pictureSettings = options.Value;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.host = host;

        }

        public async Task<IEnumerable<ProductPictureResource>> GetPictures()
        {
            var pictures = await pictureRepository.GetPictures();

            return mapper.Map<IEnumerable<Picture>, IEnumerable<ProductPictureResource>>(pictures);
        }

        // [HttpGet("api/pictures")]
        // public async Task<IEnumerable<PictureResource>> GetAllPictures(int productId)
        // {
        //     var pictures = await pictureRepository.GetAllPictures();

        //     return mapper.Map<IEnumerable<Picture>, IEnumerable<PictureResource>>(pictures);
        // }


        [HttpPost("{productId}")]
        public async Task<IActionResult> Upload(int productId, IFormFile file)
        {
            var product = await productRepository.GetById(productId);
            if (product == null)
                return NotFound();

            if (file == null) return BadRequest("Null file");
            if (file.Length == 0) return BadRequest("Empty file");
            if (file.Length > pictureSettings.MaxBytes) return BadRequest("Max file size exceeded");
            if (!pictureSettings.IsSupported(file.FileName)) return BadRequest("Invalid file type.");

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
            var picture = await pictureService.UploadPicture(product, file, uploadsFolderPath);


            return Ok(mapper.Map<Picture, PictureResource>(picture));

        }

    }
}