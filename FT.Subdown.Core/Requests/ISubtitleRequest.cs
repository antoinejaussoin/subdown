using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace FT.Subdown.Core.Requests
{
    public interface ISubtitleRequest
    {
        string MovieName { get; }

        FileInfo MovieLocation { get; }

        IList<CultureInfo> Languages { get; }
    }
}
