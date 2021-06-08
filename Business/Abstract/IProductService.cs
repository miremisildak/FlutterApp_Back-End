using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
        IDataResult<List<Product>> GetAll();
        IDataResult<ProductDetailDto> GetProductDetailsById(int productId);
        IDataResult<ListProductDetailDto> GetAllProductDetail();//
        IDataResult<List<Product>> GetByPrice(decimal min, decimal max);
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetAllByMarketId(int id);
        IDataResult<List<Product>> GetByLikedNumber(decimal min, decimal max);


    }
}
