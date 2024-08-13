﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormularioSesion.Droid
{
    public class FileAccess
    {
        public static string GetLocalFilePath(string filePath)
        {
            string path = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal    
            );

            return System.IO.Path.Combine( path, filePath );    
        }
    }
}