using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Penguin.Update
{
    class Update
    {
        public static bool CheckVersion()
        {
            using (WebClient wc = new WebClient())
            {
                bool result = false;
                var json = wc.DownloadString("http://lessthanthreedev.com/penguin/config.json");
                dynamic version = JsonConvert.DeserializeObject(json);
                

                string[] nums  = Application.ProductVersion.Split('.');
                int major = int.Parse(nums[0]);
                int minor = int.Parse(nums[1]);
                int revision = int.Parse(nums[2]);                

                if (version["major"] > major)
                {
                    result = true;
                }
                else if(version["minor"] > minor)
                {
                    result = true;
                }
                else if(version["revision"] > revision)
                {
                    result = true;
                }
                return result;                
            }            
        }

        public static void DownloadUpdate()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile("http://lessthanthreedev.com/penguin/installer/InstallPenguin.exe", @".\InstallPenguin.exe");
            }
        }

        public static void InstallUpdate()
        {
            Console.WriteLine("Applying the Update");
            Process.Start(@".\InstallPenguin.exe");
            Environment.Exit(0);
        }
    }
}
     
