using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bongles.WebAPI.Controllers;

namespace Bungles.FindDrinks.Models
{
    /// <summary>
    /// The following class describes Location entity
    /// </summary>
    public class Location
    {
        [Key]
        public int id { get; set; }
        public string gogId { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }
        public string description { get; set; }
        public string geolocation { get; set; }
        public string name { get; set; }
        public string openingHours{ get; set;}
        [Range(1.0, 5.0)]
        public float rating { get; set; }
        public string website { get; set; }
        //One Location, N Drinks(1-N)
        public virtual IEnumerable<Drink> drinks { get; set;  }
        public string url { get; set; }

    }


}