using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FT.Subdown.Core.Settings
{
    public interface ISettingsService
    {
        T Read<T>(string key);
    }
}
