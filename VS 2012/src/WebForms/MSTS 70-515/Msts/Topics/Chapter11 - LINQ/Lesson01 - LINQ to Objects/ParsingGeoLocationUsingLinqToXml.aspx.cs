using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Msts.Topics.Chapter11___LINQ.Lesson01___LINQ_to_Objects
{
    public partial class ParsingGeoLocationUsingLinqToXml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public static object GetIPLocation(string ip)
        {
            //var docs = XDocument.Load(HttpContext.Current.Server.MapPath("~/Topics/Chapter09 - Scripts/Lesson03 - JQuery/MyXmlFile.xml"));

            //return docs.ToString();

            var req = WebRequest.Create("http://freegeoip.net/xml/" + ip);
            var res = req.GetResponse() as HttpWebResponse;

            using (var s = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding(1252)))
            {
                var xml = XDocument.Parse(s.ReadToEnd());
                var elements = xml.Root.Elements();
                var currentCountry = elements.First(x => x.Name.ToString().Equals("CountryName", StringComparison.InvariantCultureIgnoreCase));

                var addressID = Guid.NewGuid();
                var address = new XElement("address", new XAttribute("id", addressID));
                var states = new XElement("states");
                var edo = new XElement("state", new XAttribute("name", "Distrito Federal"));
                var city = new XElement("city", new XAttribute("name", "Distrito Federal"));
                var addressDetail = new XElement("addressDetail");
                var col = new XAttribute("name", "Lindavista");
                var intNumber = new XAttribute("numeroInterior", 12);
                var extNumber = new XAttribute("numeroExterior", 142);
                var mnz = new XAttribute("manzana", 318);
                var calle = new XAttribute("calle", "correjidora");

                currentCountry.AddFirst(address);
                address.Add(states);
                states.Add(edo);
                edo.Add(city);
                city.Add(addressDetail);
                addressDetail.Add(col, intNumber, extNumber, mnz, calle);

                var g = from c in xml.Root.Element("CountryName").Elements()
                        where (Guid)c.Attribute("id") == addressID
                        select c;

                if (g == null)
                {
                    throw new Exception("Something wrong happened");
                }

                var o = new
                {
                    IP = elements.First(x => x.Name.ToString().Equals("IP", StringComparison.InvariantCultureIgnoreCase)).Value,
                    Country = new
                    {
                        Name = currentCountry.Value,
                        Address = new
                        {
                            ID = currentCountry.Elements().First(x => x.Name.ToString().Equals("address")).Attribute("id").Value
                        }
                    },
                    CountryCode = elements.First(x => x.Name.ToString().Equals("CountryCode", StringComparison.InvariantCultureIgnoreCase)).Value,
                    RegionCode = elements.First(x => x.Name.ToString().Equals("RegionCode", StringComparison.InvariantCultureIgnoreCase)).Value,
                    RegionName = elements.First(x => x.Name.ToString().Equals("RegionName", StringComparison.InvariantCultureIgnoreCase)).Value,
                    ZipCode = elements.First(x => x.Name.ToString().Equals("ZipCode", StringComparison.InvariantCultureIgnoreCase)).Value,
                    MetroCode = elements.First(x => x.Name.ToString().Equals("MetroCode", StringComparison.InvariantCultureIgnoreCase)).Value,
                    Latitude = elements.First(x => x.Name.ToString().Equals("Latitude", StringComparison.InvariantCultureIgnoreCase)).Value,
                    Longitude = elements.First(x => x.Name.ToString().Equals("Longitude", StringComparison.InvariantCultureIgnoreCase)).Value
                };

                return o;

                //var xmlser = new XmlSerializer(o.GetType());
                //var mem = new MemoryStream();

                //xmlser.Serialize(mem, o);

                //return UTF8Encoding.UTF8.GetString(mem.ToArray());
            }
        }
    }
}