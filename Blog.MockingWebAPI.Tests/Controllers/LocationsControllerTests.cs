using Blog.MockingWebAPI.Repository;
using Bongles.WebAPI.Controllers;
using Bungles.FindDrinks.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Bongles.WebAPI.Tests.Controllers
{
    [TestClass]
    public class LocationsControllerTests
    {
        [TestMethod()]
        public void Get()
        {
             var data = new List<Location> 
            { 
                new Location { id= 1,	gogId="ChIJ_w0bJLzUf0cRy_s3-sYl0UU", address="Via Zamboni, 16/d, 40126 Bologna, Italia", telephone="051 1889 9835", description=null,
                    geolocation="(44.495439, 11.348128999999972)", name="Lab16", openingHours="Lunedì: 07:00–03:00 | Martedì: 07:00–03:00 | Mercoledì: 07:00–03:00 | Giovedì: 07:00–03:00 | Venerdì: 07:00–03:00 | Sabato: 17:30–03:30 | Domenica: 17:30–03:30",
                    rating=4.4F, website="http://www.lab16.it/", url=	"https://plus.google.com/108077084127565302676/about?hl=it-IT" }
              
            }.AsQueryable();
 
            var mockSet = new Mock<DbSet<Location>>(); 
            
            mockSet.As<IQueryable<Location>>().Setup(m => m.Provider).Returns(data.Provider); 
            mockSet.As<IQueryable<Location>>().Setup(m => m.Expression).Returns(data.Expression); 
            mockSet.As<IQueryable<Location>>().Setup(m => m.ElementType).Returns(data.ElementType); 
            mockSet.As<IQueryable<Location>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator()); 
 

           //TODO: Start MOCKING
                                  
            var mockContext = new Mock<databaseEF>(); 
            mockContext.Setup(c => c.locations).Returns(mockSet.Object); 

            var service= new LocationsController(mockContext.Object);


            Assert.AreEqual("Lab16",service.Get(data.First().id).name);

      
        } 
    } 
}
      