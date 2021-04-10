using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDataController : ControllerBase
    {
        // GET: api/<WeatherDataController>
        [HttpGet]
        public IEnumerable<WeatherData> Get()
        {
            string path = "C:\\Data\\Data.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));
            using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            var data = (IEnumerable<WeatherData>)serializer.Deserialize(fileStream);
            return data;
        }

        // GET api/<WeatherDataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WeatherDataController>
        [HttpPost]
        public ActionResult Post(WeatherData weatherData)
        {
            if (weatherData.City is null) 
            {
                return BadRequest();
            }
            string path = "C:\\Data\\";
            XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));
            Directory.CreateDirectory(path);
            using FileStream fileStream = new FileStream(path+ "Data.xml", FileMode.Append,FileAccess.Write);
             fileStream.Flush();
            serializer.Serialize(fileStream,weatherData);
          
            fileStream.Close();
            return Ok("ok");
        }

        // PUT api/<WeatherDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WeatherDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
