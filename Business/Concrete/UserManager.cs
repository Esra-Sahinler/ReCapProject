using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        //[ValidationAspect(typeof(UserValidator))]
        //public IResult Add(User user)
        //{
        //    _userDal.Add(user);
        //    return new SuccessResult(Messages.UserAdded);
        //}

        //public IResult Delete(User user)
        //{
        //    _userDal.Delete(user);
        //    return new SuccessResult(Messages.UserDeleted);
        //}

        //public IDataResult<List<User>> GetAll()
        //{
        //    return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        //}

        //public IDataResult<User> GetById(int userId)
        //{
        //    return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        //}

        //public IResult Update(User user)
        //{
        //    _userDal.Update(user);
        //    return new SuccessResult(Messages.UserUpdated);
        //}
    }
}
