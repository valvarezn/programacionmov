using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Parcial.Dependecy;
using Xamarin.Forms;
using System.IO;
using Parcial.Droid.DependecyDB;

[assembly:Dependency(typeof(ObtenerRuta))]
namespace Parcial.Droid.DependecyDB
{
    public class ObtenerRuta : IRutaDB
    {
        public string GetPathBb(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}