using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace FT.Subdown.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            FT.Subdown.Core.Subdown.DownloadSubtitles(new FileInfo(@"d:\\fish4.avi"), new CultureInfo("fr-FR"), new CultureInfo("en-GB"));
            //Subdown.Core.Subdown.Plop();

            System.Console.Out.WriteLine("End");
            System.Console.Read();
        }
    }
}
