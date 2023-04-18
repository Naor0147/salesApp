using salesApp.wcfSales;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace salesApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pageAddProduct : Page
    {
        public pageAddProduct()
        {
            this.InitializeComponent();
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                salesApp.wcfSales.Service1Client proxy = new salesApp.wcfSales.Service1Client(); ;
                Item item = new Item(InputName.Text, float.Parse(InputPrice.Text));
                bool x = proxy.AddProductAsync(item).Result;
                ResultTxt.Text = x.ToString();
               

            }
            catch
            {
                ResultTxt.Text = "false";
            }
            InputName.Text = "";
            InputPrice.Text = "";

        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));

        }
    }
}
