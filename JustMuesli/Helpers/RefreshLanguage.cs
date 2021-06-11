using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JustMuesli.Helpers
{
    public static class RefreshLanguage
    {
        public static void Refresh<T>(T elementContainer)
        {
            if (elementContainer.GetType().BaseType == new Window().GetType() || elementContainer.GetType().BaseType == new Page().GetType())
            {
                foreach (var item in DictionaryContainer.Elements)
                {
                    var element = (elementContainer as dynamic).FindName(item.NameElement) as dynamic;
                    try
                    {

                        element.Content = item.Translations["NameRu"];
                    }
                    catch (Exception)
                    {

                       
                    }
                    try
                    {
                        element.He
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
           
        }
    }
}
