using WeatherApp.Web.Models;
using System.Collections.Generic;

namespace WeatherApp.Web.DAL
{
    public interface IWeatherDAL
    {
        List<Weather> getWeatherByParkCode(string parkCode);
    }
}