using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMuesli.Helpers
{
    public class DictionaryContainer
    {
        public static string CurrentLanguage { get; set; } = "NameEn";
        public static List<ElementLanguage> elements;
        public static List<ElementLanguage> Elements
        {
            get
            {
                elements = elements ?? JsonConvert.DeserializeObject<List<ElementLanguage>>(Properties.Resources.LanguageDictionary);
                return elements;
            }
        }
    }
}
