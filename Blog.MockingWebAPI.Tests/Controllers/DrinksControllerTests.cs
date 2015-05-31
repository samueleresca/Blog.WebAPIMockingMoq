using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bungles.FindDrinks.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Bongles.WebAPI.Controllers;
using Moq;
using Blog.MockingWebAPI.Repository;

namespace Bongles.WebAPI.Tests.Controllers
{
    [TestClass]
    public class DrinksControllerTests
    {
        [TestMethod]
        public void GetByIdLocation()
        {
            //Define the mock data
            var data = new List<Location> 
            { 
                new Location { id= 1 ,	gogId="ChIJ_w0bJLzUf0cRy_s3-sYl0UU", address="Via Zamboni, 16/d, 40126 Bologna, Italia", telephone="051 1889 9835", description=null,
                    geolocation="(44.495439, 11.348128999999972)", name="Lab16", openingHours="Lunedì: 07:00–03:00 | Martedì: 07:00–03:00 | Mercoledì: 07:00–03:00 | Giovedì: 07:00–03:00 | Venerdì: 07:00–03:00 | Sabato: 17:30–03:30 | Domenica: 17:30–03:30",
                    rating=4.4F, website="http://www.lab16.it/", url=	"https://plus.google.com/108077084127565302676/about?hl=it-IT" , drinks=new List<Drink>{
                    new Drink{ id= 4, description="Drink1", name="Drink1", price=5.00M},
                    new Drink{ id= 5, description="Drink2", name="Drink2", price=3.50M},
                    new Drink{ id=6, description="Drink3", name="Drink3", price=4.00M}
                    }
                }
              
            }.AsQueryable();


            //Define the mock type as DbSet<Location>
            var mockSet = new Mock<DbSet<Location>>();
            //Define the mock Repository as databaseEf
            var mockContext = new Mock<databaseEF>();
           

            //Bind all data  attributes to your mockSe
            
            mockSet.As<IQueryable<Location>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Location>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Location>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Location>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            //Setting up the mockSet to mockContext
            mockContext.Setup(c => c.locations).Returns(mockSet.Object);

            //Init the WebAPI service
            var service = new DrinksController(mockContext.Object);
            //Check the equality between the returned data and the expected data
            Assert.AreEqual( "Drink1", service.GetByLocId(data.First().id).First().name);

      
        }
    }
}
