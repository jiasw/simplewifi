using SimpleWifi;

namespace WifiTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wifi wifi = new Wifi();
            string ssid = "郭大侠";
            string password = "zzjs_211";
            // get list of access points
            IEnumerable<AccessPoint> accessPoints = wifi.GetAccessPoints();

            // for each access point from list
            foreach (AccessPoint ap in accessPoints)
            {

                Console.WriteLine("ap: {0}\r\n", ap.Name);
                //check if SSID is desired
                if (ap.Name == ssid)
                {
                    //verify connection to desired SSID
                    Console.WriteLine("connected: {0}, password needed: {1}, has profile: {2}\r\n", ap.Name, ap.IsConnected, ap.HasProfile);

                    if (!ap.IsConnected)
                    {
                        //connect if not connected
                        Console.WriteLine("\r\n{0}\r\n", ap.ToString());
                        Console.WriteLine("Trying to connect..\r\n");

                        AuthRequest authRequest = new AuthRequest(ap);
                        authRequest.Password = password;

                        ap.ConnectAsync(authRequest, true);
                    }
                }
            }

            Console.WriteLine("点击任意键");
            Console.ReadKey();
        }
    }
}
