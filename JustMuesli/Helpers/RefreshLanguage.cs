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
        public static void Refresh(FrameworkElement elementContainer)
        {

          

             
            foreach (var item in DictionaryContainer.Elements)
            {
                var element = (elementContainer as dynamic).FindName(item.NameElement) as dynamic;
                try
                {

                    element.Content = item.Translations[DictionaryContainer.CurrentLanguage];
                }
                catch (Exception)
                {

                    try
                    {
                        element.Header = item.Translations[DictionaryContainer.CurrentLanguage];
                    }
                    catch (Exception)
                    {
                        try
                        {

                        element.Text = item.Translations[DictionaryContainer.CurrentLanguage];
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                    
                
            }
           
        }
    }
}
