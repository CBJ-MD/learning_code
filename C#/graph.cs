using System;
using System.IO;
using System.Drawing;
using System.Math;

namespace Graph
{
    class Light1
    {
        int Width;
        int Height;


        static void Main(string[] args)
        {
            Bitmap bmp = new Bitmap(Width,Height)

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    bmp.SetPixel(i,j,Sample(i/Width,j/Height))
                }
            }

            bmp.Save("Sample.bmp")
        }

        private double Sample(double x,double y)
        {
            
        }
    }
}