using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int Id);
        IDataResult<User> GetByUserName(string username);
        IDataResult<List<OperationClaim>> GetClaims(User user);//!!//
        IResult UpdateForProfile(UpdateProfileDto updateProfile);
        IResult UpdateForPassword(UpdatePasswordDto updatePassword);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

    }
}
