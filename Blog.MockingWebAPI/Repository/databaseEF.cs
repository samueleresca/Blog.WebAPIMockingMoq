namespace Blog.MockingWebAPI.Repository
{
    using Bungles.FindDrinks.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;


    /// <summary>
    /// Entity Data Model class, extends DbContext
    /// </summary>
    public class databaseEF : DbContext
    {
         public databaseEF()
            : base("name=databaseEF"){}

        //Locations DbSet 
         public virtual DbSet<Location> locations { get; set; }
        //Drinks DbSet 
        public virtual DbSet<Drink> drink { get; set; }

    }

    
}