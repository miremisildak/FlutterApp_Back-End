using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        ProductDetailDto GetProductDetailsById(Expression<Func<ProductDetailDto, bool>> filter=null);
        ListProductDetailDto GetList(Expression<Func<ListProductDetailDto, bool>> filter = null);
    }
}
