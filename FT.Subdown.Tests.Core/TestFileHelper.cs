using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FT.Subdown.Tests.Core
{
    public static class TestFileHelper
    {
        public static string ReadFile(string name)
        {
            var fileInfo = new FileInfo(@"Files\" + name);
            using (var reader = fileInfo.OpenText())
            {
                return reader.ReadToEnd();
            }
        }
    }
}
