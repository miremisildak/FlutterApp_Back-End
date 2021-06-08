using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MarketManager : IMarketService
    {

        IMarketDal _marketDal;

        public MarketManager(IMarketDal marketDal)
        {
            _marketDal = marketDal;
        }

        public IResult Add(Market market)
        {
            _marketDal.Add(market);
            return new SuccessResult(Messages.MarketAdded);
        }

        public IResult Delete(Market market)
        {
            _marketDal.Delete(market);
            return new SuccessResult(Messages.MarketDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Market>> GetAll()
        {
            return new SuccessDataResult<List<Market>>(_marketDal.GetAll());
        }

        public IResult Update(Market market)
        {
            _marketDal.Update(market);
            return new SuccessResult();
        }
    }
}
