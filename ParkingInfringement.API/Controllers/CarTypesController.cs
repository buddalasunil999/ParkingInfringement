﻿using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ParkingInfringement.API.Models;
using ParkingInfringement.API.Models.Repositories;
using ParkingInfringement.API.Filters;

namespace ParkingInfringement.API.Controllers
{
    
    public class CarTypesController : ApiController
    {
        private CarTypeRepository rep = new CarTypeRepository();

        // GET: api/CarTypes
        [AllowAnonymous]
        public IEnumerable<CarType> GetCarTypes()
        {
            return rep.GetCarTypes();
        }

        // GET: api/CarTypes/5
        [AllowAnonymous]
        [ResponseType(typeof(CarType))]
        public IHttpActionResult GetCarType(int id)
        {
            CarType carType = rep.GetCarType(id);
            if (carType == null)
            {
                return NotFound();
            }

            return Ok(carType);
        }

        // PUT: api/CarTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarType(int id, CarType carType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carType.Id)
            {
                return BadRequest();
            }

            try
            {
                rep.Update(id, carType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rep.CarTypeExists(id))
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

        // POST: api/CarTypes
        [ResponseType(typeof(CarType))]
        public IHttpActionResult PostCarType(CarType carType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            rep.Add(carType);

            return CreatedAtRoute("DefaultApi", new { id = carType.Id }, carType);
        }

        // DELETE: api/CarTypes/5
        [ResponseType(typeof(CarType))]
        public IHttpActionResult DeleteCarType(int id)
        {
            CarType carType = rep.GetCarType(id);
            if (carType == null)
            {
                return NotFound();
            }

            rep.Delete(carType);

            return Ok(carType);
        }
    }
}