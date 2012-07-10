using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.Win32;

namespace SoftwareManagementTool.WpfApplication2
{
    public class InstalledSoftware
    {
        public string DisplayName { get; set; }
        public string InstallLocation { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets a list of installed software and, if known, the software's install path.
        /// </summary>
        /// <returns></returns>
        private List<InstalledSoftware> Getinstalledsoftware()
        {
            //Declare the string to hold the list:

            List<InstalledSoftware> softwareNameList = new List<InstalledSoftware>();


            //The registry key:

            string SoftwareKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(SoftwareKey))
            {
                //Let's go through the registry keys and get the info we need:

                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            //If the key has value, continue, if not, skip it:

                            object displayName = sk.GetValue("DisplayName");
                            if (displayName != null)
                            {
                                //Is the install location known?

                                object installLocation = sk.GetValue("InstallLocation");
                                if (installLocation == null)
                                {
                                    softwareNameList.Add(new InstalledSoftware()
                                                             {
                                                                 DisplayName = displayName.ToString(),
                                                                 InstallLocation = " - Install path not known\n",
                                                             });
                                }
                                else
                                {
                                    //Nope, not here.

                                    softwareNameList.Add(new InstalledSoftware()
                                                             {
                                                                 DisplayName = displayName.ToString(),
                                                                 InstallLocation = installLocation.ToString(),
                                                             }); //Yes, here it is...
                                }
                            }
                        }

                        catch (Exception ex)
                        {
                            //No, that exception is not getting away... :P
                        }
                    }
                }
            }


            return softwareNameList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<InstalledSoftware> s = Getinstalledsoftware();
            foreach (var softwareName in s)
            {
                this.listBox1.Items.Add(softwareName.DisplayName + "-" + softwareName.InstallLocation);
            }
        }
    }
}