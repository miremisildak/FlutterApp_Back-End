using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult();
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }


        [CacheAspect]
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAllByMarketId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.MarketId == id));
        }

        [CacheAspect]
        public IDataResult<ListProductDetailDto> GetAllProductDetail()
        {
            return new SuccessDataResult<ListProductDetailDto>(_productDal.GetList());
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetByLikedNumber(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.LikedNumber >= min && p.LikedNumber <= max));
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetByPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.Price >= min && p.Price <= max));
        }

        [CacheAspect]
        public IDataResult<ProductDetailDto> GetProductDetailsById(int productId)
        {
            return new SuccessDataResult<ProductDetailDto>(_productDal.GetProductDetailsById(p => p.ProductId == productId));
        }


        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult();
        }
    }
}
