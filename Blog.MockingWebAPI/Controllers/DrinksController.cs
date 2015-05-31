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
    /// DrinksController: returns information about your Drinks
    /// </summary>
    public class DrinksController : ApiController
    {
        //Repository object, entity data model
         public databaseEF db{get; set;}

        /// <summary>
        /// Default constructor
        /// </summary>
        public DrinksController()
        {
                this.db= new databaseEF();
        }
        /// <summary>
        /// Constructor used by Moq
        /// </summary>
        /// <param name="mockDB">Repository</param>
        public DrinksController(databaseEF mockDB)
        {
            this.db = mockDB;
        }

        /// <summary>
        /// Controller used to get drinks by Locations Id
        /// GET api/values/id
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public IEnumerable<Drink> GetByLocId(int locationId)
        {
            return db.locations.Where<Location>(l => l.id == locationId).First().drinks;
        }
              
    }
}