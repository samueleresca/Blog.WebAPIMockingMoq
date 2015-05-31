using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Bungles.FindDrinks.Models
{

    /// <summary>
    /// The following class describes Drink entity
    /// </summary>
    public class Drink
    {
        [Key]
        public int id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}