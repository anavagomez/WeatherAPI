using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using System.Web.Script.Serialization;

namespace WeatherAPI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void GetWeatherInfo(object sender, EventArgs e)
        {
            string appId = "07b188606c1f2c32a63d78a88a6e9652";

            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&cnt=1", txtCity.Text.Trim(), appId);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherResponse weatherResponse = (new JavaScriptSerializer()).Deserialize<WeatherResponse>(json);

                lblCity_Country.Text = weatherResponse.name + ", " + weatherResponse.sys.country;
                imgCountryFlag.ImageUrl = string.Format("http://openweathermap.org/images/flags/{0}.png", weatherResponse.sys.country.ToLower());
                lblDescription.Text = weatherResponse.weather[0].description;
                imgWeatherIcon.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherResponse.weather[0].icon);
                lblTemperature.Text = string.Format("{0}°С", weatherResponse.main.temp);
                lblHumidity.Text = weatherResponse.main.humidity.ToString();
                lblWind.Text = weatherResponse.wind.speed.ToString();
                lblClouds.Text = weatherResponse.clouds.all.ToString();
                lblTempMin.Text = weatherResponse.main.temp_min.ToString();
                lblTempMax.Text = string.Format("{0}°С", weatherResponse.main.temp_max);
                lblPressure.Text = weatherResponse.main.pressure.ToString();
                lblLon.Text = weatherResponse.coord.lon.ToString();
                lblLat.Text = weatherResponse.coord.lat.ToString();
                tblWeather.Visible = true;
            }
        }

        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public int temp_min { get; set; }
            public int temp_max { get; set; }

        }
        public class Wind
        {
            public double speed { get; set; }
            public double deg { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public double message { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class WeatherResponse
        {
            public Coord coord { get; set; }
            public List<Weather> weather { get; set; }
            public string @base { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }

        }

    }
}