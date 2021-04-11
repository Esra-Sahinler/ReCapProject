using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Utilities.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly ICarService _carService;
        private readonly ICustomerService _customerService;
        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }

        [SecuredOperation("rental.add, admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(FindeksScoreCheck(rental.CustomerId, rental.Id),
                UpdateCustomerFindexPoint(rental.CustomerId, rental.Id));

            if (result != null)
                return result;

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded); 
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult FindeksScoreCheck(int customerId, int carId)
        {
            var customerFindexPoint = _customerService.GetById(customerId).Data.FindexPoint;

            if (customerFindexPoint == 0)
                return new ErrorResult(Messages.CustomerFindexPointIsZero);

            var carFindexPoint = _carService.GetById(carId).Data.FindexPoint;

            if (customerFindexPoint < carFindexPoint)
                return new ErrorResult(Messages.CustomerScoreIsInsufficient);

            return new SuccessResult();
        }

        private IResult UpdateCustomerFindexPoint(int customerId, int carId)
        {
            var customer = _customerService.GetById(customerId).Data;
            var car = _carService.GetById(carId).Data;

            customer.FindexPoint = (car.FindexPoint / 2) + customer.FindexPoint;

            _customerService.Update(customer);
            return new SuccessResult();
        }
    }
}
