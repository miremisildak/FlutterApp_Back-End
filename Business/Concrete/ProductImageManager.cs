using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductImageManager:IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public IResult Add(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(productImage.ProductId));
            if (result != null)
            {
                return result;
            }
            productImage.ImagePath = FileHelper.Add(file);
            _productImageDal.Add(productImage);
            return new SuccessResult();
        }

        public IResult Delete(ProductImage productImage)
        {

            FileHelper.Delete(productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<ProductImage> GetById(int id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<ProductImage>> GetByProductId(int id)
        {
            return new SuccessDataResult<List<ProductImage>>(CheckIfCarImageNull(id));
        }

       
        public IResult Update(IFormFile file, ProductImage productImage)
        {
            productImage.ImagePath = FileHelper.Update(_productImageDal.Get(p => p.Id == productImage.Id).ImagePath, file);
            _productImageDal.Update(productImage);
            return new SuccessResult();
        }

        private IResult CheckImageLimitExceeded(int productId)
        {
            var productImageCount = _productImageDal.GetAll(p => p.ProductId == productId).Count;
            if (productImageCount <= 3)
            {
                return new ErrorResult(Messages.CountOfImageLimitError);
            }

            return new SuccessResult();
        }
        private List<ProductImage> CheckIfCarImageNull(int id)
        {
            string path = @"\default.png";
            var result = _productImageDal.GetAll(c => c.ProductId == id).Any();
            if (!result)
            {
                return new List<ProductImage> { new ProductImage { ProductId = id, ImagePath = path} };
            }
            return _productImageDal.GetAll(p => p.ProductId == id);
        }

    }
}
