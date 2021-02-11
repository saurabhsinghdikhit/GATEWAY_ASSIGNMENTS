using BookingEntities.BookingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Service
{
    public class CustomerService
    {
        public List<Customer> getCustomers()
        {
            var customer = new List<Customer>();
            for (int i = 1; i <= 10; i++)
            {
                customer.Add(new Customer
                {
                    Id = i,
                    Name = $"Customer_{i}",
                    Email=$"Email_{i}",
                    Mobile=$"42343{i}"
                });
            }
            return customer;
        }
        public Customer GetCustomer(int Id)
        {
            return getCustomers().Find(r => r.Id == Id);
        }
    }
}
