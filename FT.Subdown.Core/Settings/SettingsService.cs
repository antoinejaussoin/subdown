using System;
using System.Configuration;
using System.IO;

namespace FT.Subdown.Core.Settings
{
    public class SettingsService : ISettingsService
    {
        public T Read<T>(string key)
        {
            var stringValue = ConfigurationManager.AppSettings[key];

            if (stringValue == null)
                throw new Exception("Can't find the key "+key+" in the configuration");

            if (typeof(T) == typeof(string))
            {
                return (T)(object)stringValue;
            }

            if (typeof(T) == typeof(int))
            {
                return (T)(object)int.Parse(stringValue);
            }

            if (typeof(T) == typeof(DateTime))
            {
                return (T)(object)DateTime.Parse(stringValue);
            }

            if (typeof(T) == typeof(FileInfo))
            {
                return (T) (object) new FileInfo(stringValue);
            }

            if (typeof(T) == typeof(DirectoryInfo))
            {
                return (T)(object)new DirectoryInfo(stringValue);
            } 

            throw new Exception("Unexpected type "+key);
        }
    }
}