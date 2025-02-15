using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Bb
{
    /// <summary>
    /// Internet connectivity checker
    /// </summary>
    public static class InternetConnectivityChecker
    {


        public static bool IsConnected
        {
            get => IsConnectedToInternet().Result;
        }

        /// <summary>
        /// return true if connected to Internet
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> IsConnectedToInternet()
        {

            if (InternetMethodMock != null)
                return await InternetMethodMock();

            if (!IsNetworkInterfaceConnected())
                return false;

            return await _isConnectedToInternet();

        }

        /// <summary>
        /// Return true if network interface is connected
        /// </summary>
        /// <returns></returns>
        public static bool IsNetworkInterfaceConnected()
        {

            bool test = false;

            var nn = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                if (ni.OperationalStatus == OperationalStatus.Up
                    && (ni.NetworkInterfaceType != NetworkInterfaceType.Loopback
                        && ni.NetworkInterfaceType != NetworkInterfaceType.Tunnel))
                {

                    var sb = new StringBuilder();

                    // if ((ni.NetworkInterfaceType & NetworkInterfaceType.Unknown) == NetworkInterfaceType.Unknown) sb.Append(NetworkInterfaceType.Unknown + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Tunnel) == NetworkInterfaceType.Tunnel) sb.Append(NetworkInterfaceType.Tunnel + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Ethernet) == NetworkInterfaceType.Ethernet) sb.Append(NetworkInterfaceType.Ethernet + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.TokenRing) == NetworkInterfaceType.TokenRing) sb.Append(NetworkInterfaceType.TokenRing + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Fddi) == NetworkInterfaceType.Fddi) sb.Append(NetworkInterfaceType.Fddi + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.BasicIsdn) == NetworkInterfaceType.BasicIsdn) sb.Append(NetworkInterfaceType.BasicIsdn + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.PrimaryIsdn) == NetworkInterfaceType.PrimaryIsdn) sb.Append(NetworkInterfaceType.PrimaryIsdn + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Ppp) == NetworkInterfaceType.Ppp) sb.Append(NetworkInterfaceType.Ppp + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Loopback) == NetworkInterfaceType.Loopback) sb.Append(NetworkInterfaceType.Loopback + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Ethernet3Megabit) == NetworkInterfaceType.Ethernet3Megabit) sb.Append(NetworkInterfaceType.Ethernet3Megabit + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Slip) == NetworkInterfaceType.Slip) sb.Append(NetworkInterfaceType.Slip + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Atm) == NetworkInterfaceType.Atm) sb.Append(NetworkInterfaceType.Atm + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.GenericModem) == NetworkInterfaceType.GenericModem) sb.Append(NetworkInterfaceType.GenericModem + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.FastEthernetT) == NetworkInterfaceType.FastEthernetT) sb.Append(NetworkInterfaceType.FastEthernetT + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Isdn) == NetworkInterfaceType.Isdn) sb.Append(NetworkInterfaceType.Isdn + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.FastEthernetFx) == NetworkInterfaceType.FastEthernetFx) sb.Append(NetworkInterfaceType.FastEthernetFx + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Wireless80211) == NetworkInterfaceType.Wireless80211) sb.Append(NetworkInterfaceType.Wireless80211 + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.AsymmetricDsl) == NetworkInterfaceType.AsymmetricDsl) sb.Append(NetworkInterfaceType.AsymmetricDsl + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.RateAdaptDsl) == NetworkInterfaceType.RateAdaptDsl) sb.Append(NetworkInterfaceType.RateAdaptDsl + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.SymmetricDsl) == NetworkInterfaceType.SymmetricDsl) sb.Append(NetworkInterfaceType.SymmetricDsl + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.VeryHighSpeedDsl) == NetworkInterfaceType.VeryHighSpeedDsl) sb.Append(NetworkInterfaceType.VeryHighSpeedDsl + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.IPOverAtm) == NetworkInterfaceType.IPOverAtm) sb.Append(NetworkInterfaceType.IPOverAtm + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.GigabitEthernet) == NetworkInterfaceType.GigabitEthernet) sb.Append(NetworkInterfaceType.GigabitEthernet + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.MultiRateSymmetricDsl) == NetworkInterfaceType.MultiRateSymmetricDsl) sb.Append(NetworkInterfaceType.MultiRateSymmetricDsl + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.HighPerformanceSerialBus) == NetworkInterfaceType.HighPerformanceSerialBus) sb.Append(NetworkInterfaceType.HighPerformanceSerialBus + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Wman) == NetworkInterfaceType.Wman) sb.Append(NetworkInterfaceType.Wman + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Wwanpp) == NetworkInterfaceType.Wwanpp) sb.Append(NetworkInterfaceType.Wwanpp + " ");
                    if ((ni.NetworkInterfaceType & NetworkInterfaceType.Wwanpp2) == NetworkInterfaceType.Wwanpp2) sb.Append(NetworkInterfaceType.Wwanpp2 + " ");

                    Trace.WriteLine($"network interface '{ni.Name}' of type '{sb.ToString()}' is connected");

                    test = true;
                }

            return test;

        }

        /// <summary>
        /// Set a mock for the method <see cref="IsConnectedToInternet"/>
        /// </summary>
        /// <param name="method"></param>
        public static void SetMock(Func<Task<bool>> method)
        {
            InternetMethodMock = method;
        }



        private static async Task<bool> _isConnectedToInternet()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("http://www.google.com");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        private static Func<Task<bool>> InternetMethodMock;
        private static readonly HttpClient httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(1) };


    }

}
