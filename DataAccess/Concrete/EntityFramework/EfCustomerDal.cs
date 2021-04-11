using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDatabaseContext>, ICustomerDal
    {
        public CustomerDetailDto GetByEmail(Expression<Func<CustomerDetailDto, bool>> filter)
        {
                using (var context = new ReCapDatabaseContext())
                {
                    var result = from customer in context.Customers
                                 join user in context.Users
                                 on customer.UserId equals user.UserId
                                 select new CustomerDetailDto
                                 {
                                     Id = customer.CustomerId,
                                     UserId = customer.UserId,
                                     FirstName = user.FirstName,
                                     LastName = user.LastName,
                                     Email = user.Email,
                                     CompanyName = customer.CompanyName,
                                     FindexPoint = (int)customer.FindexPoint
                                 };

                    return result.SingleOrDefault(filter);
                }
            }

        public List<CustomerDetailDto> GetCustomerDetails()
        {
                using (var context = new ReCapDatabaseContext())
                {
                    var result = from customer in context.Customers
                                 join user in context.Users
                                 on customer.UserId equals user.UserId
                                 select new CustomerDetailDto
                                 {
                                     Id = customer.CustomerId,
                                     UserId = customer.UserId,
                                     FirstName = user.FirstName,
                                     LastName = user.LastName,
                                     Email = user.Email,
                                     CompanyName = customer.CompanyName,
                                     FindexPoint = (int)customer.FindexPoint
                                 };

                    return result.ToList();
                }
        }
    }
 }
