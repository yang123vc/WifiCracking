using NativeWifi;

namespace WifiCracking
{
    class WifiSSID
    {
        public WifiSSID()
        {
           SSID = "NONE";
           Dot11DefaultAuthAlgorithm = "";
           Dot11DefaultCipherAlgorithm = "";
           NetworkConnectable = true;
           WlanNotConnectableReason = "";
           WlanSignalQuality = 0;
           WlanInterface = null;
        }


        public string SSID { get; set; }

        public string Dot11DefaultAuthAlgorithm { get; set; }

        public string Dot11DefaultCipherAlgorithm { get; set; }

        public bool NetworkConnectable { get; set; }

        public string WlanNotConnectableReason { get; set; }

        public int WlanSignalQuality { get; set; }

        public WlanClient.WlanInterface WlanInterface { get; set; }
    }
}
