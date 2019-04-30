using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core2Api.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.IdentityModel.Xml.WsTrustConstants_1_3;

namespace Core2Api.Controller
{
    [Route("api/[controller]")]



    [ApiController]
    public class MyCitiesController:ControllerBase
    {
        //[HttpGet]
        //public JsonResult GetAllCities()
        //{
        //    return new JsonResult(new List<object>
        //    {
        //        new{id=1,name="Kolkata"},
        //        new{id=2,name="Kolkata2"},
        //        new{id=3,name="Kolkata3"}
        //    });
        //}
        [HttpGet]
        [Route("GetAllCities")]
        public JsonResult GetAllCities()
        {
           // return new JsonResult(CityDataStore.Current.Cities);
           var temp= new JsonResult(CityDataStore.Current.Cities);
            temp.StatusCode = 200;
            return temp;


        }

        //[HttpGet("{id}")]
        //public JsonResult GetCity(int id)
        //{
        //    return new JsonResult(CityDataStore.Current.Cities.FirstOrDefault(x=>x.id==id));
        //}

        [HttpGet("{id}",Name ="GetCity")]
        public IActionResult GetCity(int id)
        {
            var returnCity=(CityDataStore.Current.Cities.FirstOrDefault(x => x.id == id));
            if(returnCity==null)
            {
                return NotFound();
            }
            return Ok(returnCity);
        }

        [HttpPost]
        public IActionResult PostCity([FromBody] City item)
        {
            CityDataStore.Current.Cities.Add(item);
            return CreatedAtRoute("GetCity", new { item.id }, item);
                     
        }

        [HttpPut("{id}")]
        public IActionResult PutCity([FromBody] City item, int id)
        {
            if(item==null)
            {
                return BadRequest();
            }
            if(item.Name==null & item.Description==null)
            {
                return BadRequest();
            }
            var temp = CityDataStore.Current.Cities.FirstOrDefault(x => x.id == id);
            if(temp==null)
            {
                return NotFound();
            }
            temp.Name = item.Name;
            temp.Description = item.Description;
            temp.Interest = item.Interest;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity( int id)
        {
           
            var temp = CityDataStore.Current.Cities.FirstOrDefault(x => x.id == id);
            if (temp == null)
            {
                return NotFound();
            }
            CityDataStore.Current.Cities.Remove(temp);
            return NoContent();
        }

    }
}
