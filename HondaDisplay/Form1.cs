using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;
using HondaDisplay;

namespace HondaDisplay
{
    public partial class Form1 : Form
    {
        //Starts listening for the insight regardless of it's IP address
        public static TcpListener server = new TcpListener(IPAddress.Any, 3000);
        public static string insightData; 
        public static Form2 form = new Form2();

        public Form1()
        {
            InitializeComponent();
            form.Show();

            //Define what folder the program needs to watch
            //check for various changes
            //when a change happens to the folder, run the image update
            FileSystemWatcher watchFiles = new FileSystemWatcher();
            watchFiles.Path = "C:\\ProgramData\\Cognex\\In-Sight\\Emulators\\5.9.2\\";
            watchFiles.NotifyFilter = NotifyFilters.LastWrite
                | NotifyFilters.FileName
                | NotifyFilters.LastAccess
                | NotifyFilters.Size;
            //any changes made all get processed the same way
            watchFiles.Changed += watchFiles_onChanged;
            watchFiles.Created += watchFiles_onChanged;
            watchFiles.Deleted += watchFiles_onChanged;
            watchFiles.Renamed += watchFiles_onChanged;
            watchFiles.EnableRaisingEvents = true;
            //program starts listening for data from the insight
            server.Start();
            this.startListening();
        }

        public void watchFiles_onChanged(object sender, FileSystemEventArgs e)
        {
            //load the folder
            //check for the image that is sent from the insight
            string directoryName = Path.GetDirectoryName(e.FullPath);
            foreach (string filename in Directory.GetFiles(directoryName, "Image000.bmp"))
            {
                var i = new FileInfo(filename).Length;
                //check to see that the image has fully transfered from the insight
                //once the image has been fully loaded, continue
                if (filename == "Image000.bmp")
                {
                    while (i < 138000)
                    {
                        
                    }
                }
            }
            //reload the display with the latest image

            if (Image0.InvokeRequired)
            {
                Image0.Invoke(new Action(() => watchFiles_onChanged(sender, e)));
            }
            else
            {
                UriTypeConverter uriTypeConverter = new UriTypeConverter();
                Image0.Url = (Uri)uriTypeConverter.ConvertFromString("C:\\ProgramData\\Cognex\\In-Sight\\Emulators\\5.9.2\\Image000.svg");
            } 
            //start listening again for the next trigger
            this.startListening();
        }

        //Wait for the insight and program to connect, and once the data has been received, show it to the display
        public async void startListening()
        {
            //program starts listening
            TcpClient client = await server.AcceptTcpClientAsync();
            if (partNumber.InvokeRequired)
            {
                partNumber.Invoke(new Action(() => startListening()));
            }
            else
            {
                partNumber.Text = "Connected";

            }
            NetworkStream networkStream = client.GetStream();
            Byte[] vs = new Byte[1024];
            var data = await networkStream.ReadAsync(vs, 0, vs.Length);
            var inputData = System.Text.Encoding.ASCII.GetString(vs, 0, data);

            if (partNumber.InvokeRequired)
            {
                partNumber.Invoke(new Action(() => startListening()));
            }
            else
            {
                partNumber.Text = inputData;
                insightData = inputData;
            }
        }
    }
}
