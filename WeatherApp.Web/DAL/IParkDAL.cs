using WeatherApp.Web.Models;
using System.Collections.Generic;

namespace WeatherApp.Web.DAL
{
    public interface IParkDAL
    {
        List<Park> getAllParksData();

        Park getParkIdData(string parkCode);
    }
}