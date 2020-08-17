using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using UserManagementBackEnd.Models;

namespace UserManagementBackEnd.Data
{
    public class CustomersRpository : ICustomersRepository
    {
        private readonly UserManagementBackEndContext _Context;
        private readonly ILogger _Logger;


        public CustomersRpository(UserManagementBackEndContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("CustomersRepository");
        }


        public async Task<List<Customer>> GetCustomersAsync()
        {

            List<int> customerIds = new List<int>();
            Dictionary<int, int> orderNumbersDictionary = new Dictionary<int, int>();
            List<Customer> customers = new List<Customer>();

            customerIds = _Context.Customer.Select(c => c.Id).ToList();
            orderNumbersDictionary = await this.GetNumberofOrdersAsync(customerIds);
            customers = await _Context.Customer.OrderBy(c => c.LastName).ToListAsync();

            foreach (Customer c in customers)
            {
                c.OrderCount = orderNumbersDictionary[c.Id];
            }

            return customers;           
        }


        public async Task<Dictionary<int, int>> GetNumberofOrdersAsync(List<int> customerIds)
        {
            Dictionary<int, int> orderNumbersDictionary = new Dictionary<int, int>();

            foreach (int id in customerIds)
            {
                orderNumbersDictionary[id] = await _Context.Order.Where(o => o.CustomerId == id).CountAsync();
            }
            
            return orderNumbersDictionary;
        }

        
        public async Task<PagingResult<Customer>> GetCustomersPageAsync(int skip, int take)
        {
            List<int> customerIds = new List<int>();
            Dictionary<int, int> orderNumbersDictionary = new Dictionary<int, int>();
            List<Customer> customers = new List<Customer>();
            var totalRecords = await _Context.Customer.CountAsync();
            customers = await _Context.Customer
                                 .OrderBy(c => c.LastName)
                                 .Include(c => c.Province)
                                 .Skip(skip)
                                 .Take(take)
                                 .ToListAsync();
            customerIds = _Context.Customer.Select(c => c.Id).ToList();
            orderNumbersDictionary = await this.GetNumberofOrdersAsync(customerIds);

            foreach (Customer c in customers)
            {
                c.OrderCount = orderNumbersDictionary[c.Id];
            }

            return new PagingResult<Customer>(customers, totalRecords);
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            Customer returnCustomer;

            try
            {
                returnCustomer = await (from c in _Context.Customer
                                        where c.Id == id
                                        join product in _Context.Product
                                        on c.Id equals product.CustomerId
                                        join province in _Context.Province
                                        on c.ProvinceId equals province.Id
                                        select
                                           (
                                                new Customer
                                                {
                                                    Id = id,
                                                    FirstName = c.FirstName,
                                                    LastName =  c.LastName,
                                                    Email = c.Email,
                                                    Address = c.Address,
                                                    Province = c.Province,
                                                    ProvinceId = c.ProvinceId,
                                                    Zip = c.Zip,
                                                    Gender = c.Gender,
                                                    OrderCount = c.OrderCount,
                                                    Orders = c.Orders,
                                                    Products = c.Products
                                                }
                                           )
                                   ).Distinct().FirstOrDefaultAsync();


                return returnCustomer;
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(GetCustomerAsync)}: " + exp.Message);
                return null;
            }
        }

        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            _Context.Add(customer);
            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _Logger.LogError($"Error in {nameof(InsertCustomerAsync)}: " + exp.Message);
            }

            return customer;
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            //Will update all properties of the Customer
            _Context.Customer.Attach(customer);
            _Context.Entry(customer).State = EntityState.Modified;
            try
            {
                return (await _Context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(UpdateCustomerAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            //Extra hop to the database but keeps it nice and simple for this demo
            //Including orders since there's a foreign-key constraint and we need
            //to remove the orders in addition to the customer
            var customer = await _Context.Customer
                                .Include(c => c.Orders)
                                .SingleOrDefaultAsync(c => c.Id == id);
            _Context.Remove(customer);
            try
            {
                return (await _Context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (System.Exception exp)
            {
                _Logger.LogError($"Error in {nameof(DeleteCustomerAsync)}: " + exp.Message);
            }
            return false;
        }

    }



}

