using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product, MarketAppContext>,IProductDal
    {
        public ProductDetailDto GetProductDetailsById(Expression<Func<ProductDetailDto, bool>> filter )
        {
            using (MarketAppContext context = new MarketAppContext())
            {
                var result = from product in context.Products
                             join m in context.Markets
                             on product.MarketId equals m.Id
                             join c in context.Categories
                             on product.CategoryId equals c.Id
                             join im in context.ProductImages
                             on product.Id equals im.Id
                             select new ProductDetailDto
                             {
                                 ProductId = product.Id,
                                 MarketId = m.Id,
                                 CategoryId = c.Id,
                                 ProductName = product.Name,
                                 MarketName = m.Name,
                                 CategoryName = c.Name,
                                 Price = product.Price,
                                 Description = product.Description,
                                 ImagePath = im.ImagePath,
                                 LikedNumber=product.LikedNumber

                             };
                return result.FirstOrDefault(filter);
            }
        }
        public ListProductDetailDto GetList(Expression<Func<ListProductDetailDto, bool>> filter)
        {
            using (MarketAppContext context = new MarketAppContext())
            {
                var result = from p in context.Products
                        select new ListProductDetailDto()
                        {
                            ProductId = p.Id,
                            ProductName = p.Name,
                            Price = p.Price
                        };

                return result.FirstOrDefault();
            }
        }

      
    }
}
