using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCard.Models
{
    public class Settings
    {
        public string BaseURL { get; set; }

        public string AuthToken { get; set; }

        public string Email { get; set; }

        public string IdNumber { get; set; }

        public Boolean IsValid { get; }

        public string Name { get; set; }

        public Settings(string[] studentArgs)
        {
            Dictionary<string, string> Dictionary = ParseArgs(studentArgs);
            BaseURL = GetSetting("baseURL", Dictionary);
            AuthToken = GetSetting("authToken", Dictionary);
            Email = GetSetting("email", Dictionary);
            IdNumber = GetSetting("idNumber", Dictionary);
            Name = GetSetting("name", Dictionary);
            IsValid = BaseURL == null || BaseURL == "" || AuthToken == null || AuthToken == "" ||
                Email == null || Email == "" || IdNumber == null || IdNumber == "";
        }

        private static Dictionary<string, string> ParseArgs(string[] studentArgs)
        {
            char[] DelimiterChars = { '=' };
            Dictionary<string, string> Settings = new Dictionary<string, string>();

            foreach (var Arg in studentArgs)
            {
                string[] Entry = Arg.Split(DelimiterChars);
                Settings[Entry[0]] = Entry[1];
            }
            return Settings;
        }

        private static string GetSetting(string key, Dictionary<string, string> settings)
        {
            string Value;
            if (settings.TryGetValue(key, out Value))
            {
                System.Diagnostics.Debug.WriteLine($"{key} is {Value}.");
                return Value;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"{key} is not specified.");
                return null;
            }
        }
    }
}
