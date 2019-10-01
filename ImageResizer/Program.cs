using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            Stopwatch sw = new Stopwatch();

            ImageProcessOrigin imageProcessOrigin = new ImageProcessOrigin();
            imageProcessOrigin.Clean(destinationPath);

            sw.Start();
            imageProcessOrigin.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();

            Console.WriteLine($"修改前花費時間: {sw.ElapsedMilliseconds} ms");

            ImageProcess imageProcess = new ImageProcess();
            imageProcess.Clean(destinationPath);

            sw.Reset();
            sw.Start();
            await imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            sw.Stop();

            Console.WriteLine($"修改後花費時間: {sw.ElapsedMilliseconds} ms");
        }
    }
}