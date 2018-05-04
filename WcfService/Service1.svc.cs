using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] Weather(string zipcode)
        {
            //Date from a day after current day
            DateTime todaydate = DateTime.Now.AddDays(1);

            //Client Object of National weather service 
            weatherwebref.ndfdXML demo = new weatherwebref.ndfdXML();

            //gets the latitude longitude from zipcode 
            string result = demo.LatLonListCityNames(zipcode);

            //Parsing of XML response to get latitude longitude
            var locationElement = XElement.Parse(result);

            XmlSerializer ser = new XmlSerializer(typeof(dwml));
            dwml _dwml;

            using (StringReader stringReader = new StringReader(result))
            {
                _dwml = (dwml)ser.Deserialize(stringReader);
            }

            string l = locationElement.Element("latLonList").Value;
            var longi = (l.Split(',')[1]).ToString().Remove(3, 3);
            decimal latitude = Convert.ToDecimal(l.Split(',')[0]);
            decimal longitude = Convert.ToDecimal(longi);

            var cities = _dwml.cityNameList.Split('|');
            var _latlonglist = _dwml.latLonList.Split(',');


            return cities;

        }


    }
}
