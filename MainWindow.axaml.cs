using System;
using Avalonia.Controls;
using LibUsbDotNet;
using LibUsbDotNet.Main;


namespace usb_network_link;

public partial class MainWindow : Window
{
    public UsbDevice? myUsbDevice;
    public int pid { get; set; }
    public int vid { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        UsbRegDeviceList allDevices = UsbDevice.AllDevices;
        

        foreach (LegacyUsbRegistry registryDevice in allDevices)
        {
            this.pid = registryDevice.Pid;
            this.vid = registryDevice.Vid;
            
            UsbDeviceFinder myUsbFinder = new UsbDeviceFinder(this.vid, this.pid);

            try {
                this.myUsbDevice = UsbDevice.OpenUsbDevice(myUsbFinder);
                Console.WriteLine(this.myUsbDevice);
                if (this.myUsbDevice == null) continue;
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}