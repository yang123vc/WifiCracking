using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using NativeWifi;

using System.Linq;

namespace WifiCracking
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();
        }     

        private void Form1_Load(object sender, EventArgs e)
        {
            var list = ScanSSID();
            list = list.OrderByDescending(p => p.WlanSignalQuality).ToList();
            var bs = new BindingSource {DataSource = list};
            this.listBox1.DataSource = bs;
            this.listBox1.DisplayMember = "SSID";            
        }

        static string GetStringForSSID(Wlan.Dot11Ssid ssid)
        {

            return Encoding.UTF8.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);

        }

        /// <summary>

        /// 枚举所有无线设备接收到的SSID

        /// </summary>

        private List<WifiSSID> ScanSSID()
        {
            var ssids = new List<WifiSSID>();

            var client = new WlanClient();

            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                // Lists all networks with WEP security
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    var targetSSID = new WifiSSID
                        {
                            WlanInterface = wlanIface,
                            WlanSignalQuality = (int)network.wlanSignalQuality,
                            SSID = GetStringForSSID(network.dot11Ssid),
                            Dot11DefaultAuthAlgorithm = network.dot11DefaultAuthAlgorithm.ToString(),
                            Dot11DefaultCipherAlgorithm = network.dot11DefaultCipherAlgorithm.ToString()
                        };
                    //targetSSID.SSID = Encoding.Default.GetString(network.dot11Ssid.SSID, 0, (int)network.dot11Ssid.SSIDLength);
                    ssids.Add(targetSSID);                    
                }
            }

            return ssids;
        } 
    }
}
