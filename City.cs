using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class City
    {
        public string Name { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double Windspeed { get; set; }

        public City(string row) 
        {
            var p = row.Split(';');
            Name = p[0];
            Temperature = double.Parse(p[1]);
            Humidity = int.Parse(p[2]);
            Windspeed = double.Parse(p[3]);
        }

        public City(string name, double temperature, int humidity, double windspeed)
        {
            Name = name;
            Temperature = temperature;
            Humidity = humidity;
            Windspeed = windspeed;
        }
    }


}
