using WeatherApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WeatherApp.Web.DAL
{
    public class WeatherSqlDAL : IWeatherDAL
    {

        //private string connectionString = @"Data Source=DESKTOP-F8ON8GR\SQLEXPRESS;Initial Catalog=ParkDB;Integrated Security=True";
        private string connectionString = @"Data Source=DESKTOP-F8ON8GR;Initial Catalog=ParkDB;Integrated Security=True";

        private const string getWeatherByParkCodeSqlCommand = @"SELECT * FROM weather WHERE parkCode=@parkCode";

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public List<Weather> getWeatherByParkCode(string parkCode)
        {
            List<Weather> fiveDayWeathers = new List<Weather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(getWeatherByParkCodeSqlCommand, conn);
                    command.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Weather currentDayWeather = new Weather();
                        currentDayWeather.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        currentDayWeather.Forecast = Convert.ToString(reader["forecast"]);
                        currentDayWeather.High = Convert.ToInt32(reader["high"]);
                        currentDayWeather.Low = Convert.ToInt32(reader["low"]);
                        currentDayWeather.ParkCode = Convert.ToString(reader["parkCode"]);
                        currentDayWeather.Tempature = "F";
                        fiveDayWeathers.Add(currentDayWeather);
                    }
                }
                return fiveDayWeathers;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}