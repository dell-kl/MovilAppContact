using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace FormularioSesion.iOS
{
    public class FileAccess
    {
        public static string GetLocalFilePath(string filePath)
        {
            string path = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal
            );

            return System.IO.Path.Combine(path, filePath);
        }
    }
}