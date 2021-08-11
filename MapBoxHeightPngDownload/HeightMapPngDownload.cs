using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WK.Libraries.BetterFolderBrowserNS;

namespace MapBoxHeightPngDownload
{
    public partial class HeightMapPngDownload : Form
    {
        public HeightMapPngDownload()
        {
            InitializeComponent();
        }

        private static readonly string keepTempFolder = @"C:\keepTempFolder";

        private void HeightMapPngDownload_Load(object sender, EventArgs e)
        {
            /*
             * here we have to create the folder where we gonna keep temp files to create the main png heightmap data
             */
            if (!Directory.Exists(keepTempFolder))
            {
                Directory.CreateDirectory(keepTempFolder);
            }
        }

        public string selectedFoldersSaveAs = "";
        private void btnGenerateHeightPng_Click(object sender, EventArgs e)
        {
            try
            {
                //chera punji 9km X 9KM 91.67221, 25.23926, 91.76944, 25.32206
                //firstly we gonna get the extent of certain required area 
                double minLong = Convert.ToDouble(txtMinLong.Text.Trim());
                double minLat = Convert.ToDouble(txtMinLat.Text.Trim());

                double maxLong = Convert.ToDouble(txtMaxLong.Text.Trim());
                double maxLat = Convert.ToDouble(txtMaxLat.Text.Trim());

                double imgWidth = Convert.ToDouble(txtImageWidth.Text.Trim());
                double imgHeight = Convert.ToDouble(txtImageHeight.Text.Trim());

                //select an output folder to save outputHeightmap.png
                var betterFolderBrowser = new BetterFolderBrowser();
                betterFolderBrowser.Title = "Select a folder where your heightmap PNG will be saved...";
                betterFolderBrowser.RootFolder = @"C:\";
                betterFolderBrowser.Multiselect = false;
                if (betterFolderBrowser.ShowDialog() == DialogResult.OK)
                {
                    selectedFoldersSaveAs = betterFolderBrowser.SelectedFolder;
                }

                if (String.IsNullOrEmpty(selectedFoldersSaveAs))
                    return;

                if (radioOnline.Checked == true)
                {
                    HeightMapCreator heightMapCreator = new HeightMapCreator(minLong, minLat, maxLong, maxLat, selectedFoldersSaveAs, imgWidth, imgHeight);
                    if (heightMapCreator.getHeightMap())
                    {
                        MessageBox.Show("Success");
                    }
                    else
                    {
                        MessageBox.Show("Failed");
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
