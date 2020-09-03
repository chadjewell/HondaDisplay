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

namespace HondaDisplay
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

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
        }

        public void watchFiles_onChanged(object sender, FileSystemEventArgs e)
        {
            //load the folder
            //check for the image that is sent from the insight
            string directoryName = Path.GetDirectoryName(e.FullPath);
            foreach (string filename in Directory.GetFiles(directoryName, "Image001.bmp"))
            {
                var i = new FileInfo(filename).Length;
                //check to see that the image has fully transfered from the insight
                //once the image has been fully loaded, continue
                if (filename == "Image001.bmp")
                {
                    while (i < 138000)
                    {

                    }
                }
            }
            //reload the display with the latest image

            if (webBrowser1.InvokeRequired)
            {
                webBrowser1.Invoke(new Action(() => watchFiles_onChanged(sender, e)));
            }
            else
            {
                UriTypeConverter uriTypeConverter = new UriTypeConverter();
                webBrowser1.Url = (Uri)uriTypeConverter.ConvertFromString("C:\\ProgramData\\Cognex\\In-Sight\\Emulators\\5.9.2\\Image001.svg");
            }
        }
    }
}
