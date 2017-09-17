using System;
using System.Threading.Tasks;
using EcommerceApplication2.DataContext.UnitOfWork;
using EcommerceApplication2.Entities;
using EcommerceApplication2.Service.Interface;
using Microsoft.AspNetCore.Http;

namespace EcommerceApplication2.Service.Repository
{
    public class PictureService : IPictureService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPictureStorage pictureStorage;
        public PictureService(IUnitOfWork unitOfWork, IPictureStorage pictureStorage)
        {
            this.pictureStorage = pictureStorage;
            this.unitOfWork = unitOfWork;

        }

        public async Task<Picture> UploadPicture(Product product, IFormFile file, string uploadsFolderPath)
        {
            var fileName = await pictureStorage.StorePicture(uploadsFolderPath, file);

            var picture = new Picture { FileName = fileName };
            product.Pictures.Add(picture);
            await unitOfWork.CompleteAsync();

            return picture;
        }
    }
}