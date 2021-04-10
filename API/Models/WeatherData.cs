using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Models
{
    //latitud longitud stad temperatur och ip
    [Serializable]
    public class WeatherData
    {
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public string City { get; set; }
        public short Temperature { get; set; }
        public string Ip { get; set; }
    }
}
