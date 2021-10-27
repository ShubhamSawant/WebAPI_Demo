using System;

namespace WebAPI_Demo
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }

        public string Employee_Name { get; set; }

        public string Department { get; set; }

        public string Employee_Location { get; set; }
    }
}
