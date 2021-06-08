using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMarketService
    {
        IResult Add(Market market);
        IResult Update(Market market);
        IResult Delete(Market market);
        IDataResult<List<Market>> GetAll();
    

    }
}
