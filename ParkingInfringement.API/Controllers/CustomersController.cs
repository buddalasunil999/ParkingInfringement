﻿using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ParkingInfringement.API.Models;
using ParkingInfringement.API.Models.Repositories;

namespace ParkingInfringement.API.Controllers
{
    public class CustomersController : ApiController
    {
        private CustomerRepository rep = new CustomerRepository();

        // GET: api/Customers
        public IEnumerable<Customer> GetCustomers()
        {
            return rep.GetCustomers();
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer Customer = rep.GetCustomer(id);
            if (Customer == null)
            {
                return NotFound();
            }

            return Ok(Customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            try
            {
                rep.Update(id, customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rep.CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            rep.Add(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer Customer = rep.GetCustomer(id);
            if (Customer == null)
            {
                return NotFound();
            }

            rep.Delete(Customer);

            return Ok(Customer);
        }
    }
}