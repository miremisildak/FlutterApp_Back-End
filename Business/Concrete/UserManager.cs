using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(us => us.Id == Id));
        }

        [CacheAspect]
        public IDataResult<User> GetByUserName(string username)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserName == username));
        }

        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

       
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        //[SecuredOperation("user")]
        public IResult UpdateForPassword(UpdatePasswordDto updatePassword)
        {
            var user = _userDal.Get(u => u.Id == updatePassword.Id);
            if (user.Answer == updatePassword.Answer)
            {
                //if (!HashingHelper.VerifyPasswordHash(updatePassword.CurrentPassword, user.PasswordHash,
                //    user.PasswordSalt)) return new ErrorResult(Messages.PasswordError);

                //if (!string.IsNullOrEmpty(updatePassword.NewPassword))
                //{
                    byte[] passwordHash, passwordSalt;
                    HashingHelper.CreatePasswordHash(updatePassword.NewPassword, out passwordHash, out passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                //}

                _userDal.Update(user);
                return new SuccessResult(Messages.PasswordUpdated);
            }
            else
            {
                return new ErrorResult(Messages.AnswerNotTrue);
            }
        }

        [CacheRemoveAspect("IUserService.Get")]
        public IResult UpdateForProfile(UpdateProfileDto updateProfile)
        {                   
            var user = _userDal.Get(u => u.Id == updateProfile.Id);
            if (user == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
           
                if (!HashingHelper.VerifyPasswordHash(updateProfile.CurrentPassword, user.PasswordHash,
                    user.PasswordSalt)) return new ErrorResult(Messages.PasswordError);

                if (!string.IsNullOrEmpty(updateProfile.NewPassword))
                {

                    byte[] passwordHash, passwordSalt;
                    HashingHelper.CreatePasswordHash(updateProfile.NewPassword, out passwordHash, out passwordSalt);
                    var updatedUser = new User
                    {
                        UserName = updateProfile.UserName,
                        FirstName = updateProfile.FirstName,
                        Answer=user.Answer,
                        Id = updateProfile.Id,
                        LastName = updateProfile.LastName,
                        PasswordHash = user.PasswordHash,
                        PasswordSalt = user.PasswordSalt,
                        Status = updateProfile.Status
                    };
               
                    _userDal.Update(updatedUser);
                   
                }
                return new SuccessResult(Messages.UserUpdated);
            
        }
    }
}


