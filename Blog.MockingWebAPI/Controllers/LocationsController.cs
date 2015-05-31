using Blog.MockingWebAPI.Repository;
using Bungles.FindDrinks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bongles.WebAPI.Controllers
{
    /// <summary>
    /// LocationsController: returns information about your Location
    /// </summary>
    public class LocationsController : ApiController
    {

        public databaseEF db{get; set;}


        /// <summary>
        /// Default constructor
        /// </summary>
        public LocationsController()
        {
                this.db= new databaseEF();
        }

        /// <summary>
        /// Constructor used by Moq
        /// </summary>
        /// <param name="mockDB">Repository</param>
        public LocationsController(databaseEF mockDB )
        {
            this.db = mockDB;
        }


        /// <summary>
        /// Controller used to get location by id
        /// GET api/values/id
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public Location Get(int locationId)
        {
                //
                //Prendo quello con id corrispondente
                //
                return db.locations.Where(l => l.id == locationId).ToList().FirstOrDefault<Location>();
        }

       
    }
}
