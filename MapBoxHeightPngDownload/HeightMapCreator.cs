using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MapBoxHeightPngDownload
{
    public class HeightMapCreator
    {
        private double topleftX = 0.0, topleftY = 0.0, bottomrightX = 0.0, bottomrightY = 0.0;
        private readonly string outputFolder = "";
        private static readonly string keepTempFolder = @"C:\keepTempFolder";
        double reqImgWidth = 0.0, reqImgHeight = 0.0;
        public HeightMapCreator(double minx, double miny, double maxx, double maxy, string oFolder, double reqImgWidth, double reqImgHeight)
        {
            topleftX = minx;
            topleftY = maxy;
            bottomrightX = maxx;
            bottomrightY = miny;
            outputFolder = oFolder;
            this.reqImgWidth = reqImgWidth;
            this.reqImgHeight = reqImgHeight;
        }

        public bool getHeightMap()
        {
            try
            {
                int zoom = 14;

                // get a tile that covers the top left and bottom right (for the tile count calculation)
                int x = long2tile(topleftX, zoom);
                int y = lat2tile(topleftY, zoom);
                int x2 = long2tile(bottomrightX, zoom);
                int y2 = lat2tile(bottomrightY, zoom);

                // get the required tile count in Zoom 17
                int tileCnt = Math.Max(x2 - x + 1, y2 - y + 1);
                int iCnt = tileCnt;

                //create 2D array with null value to store height images' location into tiles[,]
                string[,] tiles = Create2DArray(tileCnt, null);

                int totalTile = (tileCnt * tileCnt) - 1;
                for (int i = 0; i < tileCnt; i++)
                {
                    for (int j = 0; j < tileCnt; j++)
                    {
                        //here we are downloading height data png from mapbox api
                        string file = downloadPNG(zoom, x + i, y + j);

                        //string FileNameWithoutExtension = "" + zoom + "_" + (x + i) + "_" + (y + j);
                        //ColorToGrayImageConverter(file1);
                        //string file = keepTempFolder + @"\" + FileNameWithoutExtension + ".png";

                        tiles[i, j] = file;
                        Console.WriteLine("Remainder: " + totalTile--);
                    }
                }
                //here we are merging all tile height data
                string combinedFile = MergeImage(tiles);
                if (combinedFile == null)
                    return false;
                double[,] heightData = modifyHeightmapFind(combinedFile);
                double MaxHeight = Enumerable.Range(0, heightData.GetLength(1)).Max(i => heightData[1, i]);
                double MinHeight = Enumerable.Range(0, heightData.GetLength(1)).Min(i => heightData[1, i]);
                double differrenceRange = MaxHeight - MinHeight;
                double shaddingIncrement = (double)(differrenceRange / 255.0);

                Image Image = imageCreate(heightData, MaxHeight, MinHeight, shaddingIncrement);

                Image.Save(keepTempFolder + @"\outputHeightMap.png", ImageFormat.Png);
                Image.Save(outputFolder + @"\outputHeightMap.png", ImageFormat.Png);
                Console.WriteLine("Download Complete!!");
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public double[,] modifyHeightmapFind(string file)
        {
            Bitmap image = new Bitmap(file);
            int dimension = image.Height;
            double[,] heightData = new double[dimension, dimension];
            for (int y = 0; y < dimension; y++)
            {
                for (int x = 0; x < dimension; x++)
                {
                    Color color = image.GetPixel(x, y);
                    double height = (-100000 + (color.R * 256 * 256 + color.G * 256 + color.B)) * 0.1;
                    heightData[x, y] = height;
                }
            }

            return heightData;
        }
        public Image imageCreate(double[,] heightmap, double MaxHeight, double MinHeight, double shaddingIncrement)
        {
            int dimension = (int)(Math.Sqrt(heightmap.Length));
            Bitmap image = new Bitmap(dimension, dimension);
            for (int y = 0; y < dimension; y++)
            {
                for (int x = 0; x < dimension; x++)
                {
                    //var index = y * dimension + x;
                    double value = heightmap[x, y];
                    int avgRGB = (int)Math.Round(255.0 - ((MaxHeight - value) / (double)shaddingIncrement));
                    if (avgRGB <= 0)
                        avgRGB = 0;
                    if (avgRGB >= 255)
                        avgRGB = 255;

                    Color color = Color.FromArgb(255, avgRGB, avgRGB, avgRGB);
                    image.SetPixel(x, y, color);
                }
            }



            //now we have to resize with our requirement
            BiLinearInterPolation biLinearInterPolation = new BiLinearInterPolation();
            float w = (float)(reqImgWidth / image.Width);
            float h = (float)(reqImgHeight / image.Height);
            Image img = biLinearInterPolation.Scale(image, w, h);

            return img;
        }
        public string downloadPNG(int zoom, int x, int y)
        {
            try
            {
                WebClient wc = new WebClient();
                string urlP1 = "https://api.mapbox.com/v4/mapbox.terrain-rgb/";
                string urlP2 = zoom + "/" + x + "/" + y;
                string urlP3 = "@2x.pngraw?access_token=pk.eyJ1Ijoiam9obmJlcmciLCJhIjoiY2s2d3FwdTJpMDJnejNtbzBtb2ljbXZiYyJ9.yRKViKWpsMTtE-NPesWZvA";

                string url = urlP1 + urlP2 + urlP3;

                if (!Directory.Exists(keepTempFolder))
                {
                    Directory.CreateDirectory(keepTempFolder);
                }

                string FileNameWithoutExtension = "" + zoom + "_" + x + "_" + y;
                string file = keepTempFolder + @"\" + FileNameWithoutExtension + ".png";
                //byte[] a = wc.DownloadData(url);
                //string ax = wc.DownloadString(url);
                wc.DownloadFile(url, file);
                //after download the png height map. We have to convert it colored to gray
                return file;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }

        }
        public int long2tile(double lon, int z)
        {
            int a = Convert.ToInt32(Math.Floor((lon + 180.0) / 360.0 * (1 << z)));
            return a;
        }
        public int lat2tile(double lat, int z)
        {
            int a = Convert.ToInt32(Math.Floor((1 - Math.Log(Math.Tan(ToRadians(lat)) + 1 / Math.Cos(ToRadians(lat))) / Math.PI) / 2 * (1 << z)));
            return a;
        }
        public double ToRadians(double angle)
        {
            return (angle * Math.PI) / 180;
        }
        public double tile2long(int x, int z)
        {
            return x / (double)(1 << z) * 360.0 - 180;
        }
        public double tile2lat(int y, int z)
        {
            double n = Math.PI - 2.0 * Math.PI * y / (double)(1 << z);
            return 180.0 / Math.PI * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n)));
        }
        public string[,] Create2DArray(int rows, string value)
        {
            string[,] arr = new string[rows, rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    arr[i, j] = value;
                }
            }
            return arr;
        }
        public string MergeImage(string[,] tiles)
        {
            DirectoryInfo directory = new DirectoryInfo(keepTempFolder);
            if (directory != null)
            {
                FileInfo[] files = directory.GetFiles("*.png");
                string outputFileHeightData = CombineImages(files, tiles);
                if (outputFileHeightData != null)
                {
                    return outputFileHeightData;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }

        }

        /*
         * here we are merging all heightmap with a certain level zoom
         */
        private string CombineImages(FileInfo[] files, string[,] tiles)
        {
            try
            {
                //change the location to store the final image.
                string finalImageFile = keepTempFolder + @"\CombinedImage.png";
                int height_width = (int)Math.Sqrt(files.Length);
                Bitmap finalImage = new Bitmap(height_width * 512, height_width * 512);
                int crtX = 0;
                int crtY = 0;
                int trackCrtY = 0;
                for (int tiley = 0; tiley < height_width; tiley++)
                {
                    int trackCrtX = 0;
                    crtX = trackCrtX;
                    for (int tilex = 0; tilex < height_width; tilex++)
                    {
                        string file = tiles[tilex, tiley];
                        file = Path.GetDirectoryName(file) + @"\" + Path.GetFileNameWithoutExtension(file) + ".png";
                        Bitmap inputImage = new Bitmap(file);



                        for (int y = 0; y < 512; y++)
                        {
                            for (int x = 0; x < 512; x++)
                            {
                                Color color = inputImage.GetPixel(x, y);
                                finalImage.SetPixel(crtX, crtY, color);

                                Console.WriteLine(crtX + "&" + crtY + "____" + x + "&" + y + "____" + color.ToArgb());
                                crtX++;
                            }
                            crtX = trackCrtX;
                            crtY++;//= y;
                                   //Console.WriteLine(crtY + "__" + y);
                        }
                        inputImage.Dispose();
                        trackCrtX = ((tilex + 1) * 512);
                        crtX = trackCrtX;
                        crtY = trackCrtY;
                        //crtX = crtX + ((tilex + 1) * 512);
                    }
                    //crtY = crtY + ((tiley + 1) * 512);
                    trackCrtY = (tiley + 1) * 512;
                    crtY = trackCrtY;
                }

                finalImage.Save(finalImageFile);
                Console.WriteLine("OK Merged!!!");
                return finalImageFile;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
