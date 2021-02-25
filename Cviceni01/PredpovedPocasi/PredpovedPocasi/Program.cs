using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PredpovedPocasi
{
    class Program
    {
        static void Main(string[] args)
        {
            //string address = "prague";
            //string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={1}&address={0}&sensor=false", Uri.EscapeDataString(address),"AIzaSyBz0swV2HoU5kHmFj6GI5g6qIwQRrlpw_Q");

            //WebRequest request = WebRequest.Create(requestUri);
            //WebResponse response = request.GetResponse();
            //XDocument xdoc = XDocument.Load(response.GetResponseStream());

            //XElement result = xdoc.Element("GeocodeResponse").Element("result");
            //XElement locationElement = result.Element("geometry").Element("location");
            //XElement lat = locationElement.Element("lat");
            //XElement lng = locationElement.Element("lng");

            Console.WriteLine("Zadejte vasi zemepisnou sirku.");
            String zemSirka = Console.ReadLine();
            Console.WriteLine("Zadejte vasi zemepisnou delku.");
            String zemDelka = Console.ReadLine();

            zemSirka = "60";
            zemDelka = "15";

            String url = "https://api.met.no/weatherapi/locationforecast/1.9/?lat=" + zemSirka + "&lon=" + zemDelka;

            System.Net.WebClient webClient = new System.Net.WebClient();
            String pocasi = webClient.DownloadString(url);

            Match mTeplota = System.Text.RegularExpressions.Regex.Match(pocasi, "value=\"");
            Match mRychlostVetru = System.Text.RegularExpressions.Regex.Match(pocasi, "mps=\"");
            Match mTlak = System.Text.RegularExpressions.Regex.Match(pocasi, "hPa");

            int teplotaIndex = 0;
            int rychlostVetruIndex = 0;
            int tlakIndex = 0;

            if (mTeplota.Success&&mRychlostVetru.Success&&mTlak.Success) {
                teplotaIndex = mTeplota.Index;
                rychlostVetruIndex = mRychlostVetru.Index;
                tlakIndex = mTlak.Index;
            }

            String teplota = pocasi.Substring(teplotaIndex+7,10);
            String rychlostVetru = pocasi.Substring(rychlostVetruIndex+5,10);
            String tlak = pocasi.Substring(tlakIndex+12,10);

            teplota = teplota.Substring(0,teplota.IndexOf('\"'));
            rychlostVetru = rychlostVetru.Substring(0, rychlostVetru.IndexOf('\"'));
            tlak = tlak.Substring(0, tlak.IndexOf('\"'));


            Console.WriteLine($"Aktualni teplota je {teplota} °C, rychlost vetru {rychlostVetru} m/s, tlak {tlak} hPa.");
        }
    }
}
