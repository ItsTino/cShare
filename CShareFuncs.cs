using System;
using System.Drawing;
using System.IO;

namespace cShare
{
    public class CShareFuncs
    {
        public String saveLocation()
        {
            string SaveLoc = Path.GetRandomFileName();
            return SaveLoc;
        }
    }

    public class ImgObject
    {
        public string objFileName { get; set; }
        public Bitmap objCapImg { get; set; }
        public ImgObject(string fileName, Bitmap capImg)
        {

            objFileName = fileName;
            objCapImg = capImg;


        }
    }
}
