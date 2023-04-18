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
    public sealed partial class pageAddSale : Page
    {
        public pageAddSale()
        {
            this.InitializeComponent();
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                salesApp.wcfSales.Service1Client proxy = new salesApp.wcfSales.Service1Client();
                Sales sales = new Sales(int.Parse(customerId.Text), int.Parse(itemId.Text), float.Parse(quantity.Text));
                bool x = proxy.AddSaleAsync(sales).Result;
                ResultTxt.Text = x.ToString();

               
            }
            catch
            {
                ResultTxt.Text = "false";
            }
            customerId.Text = "";
            itemId.Text = "";
            quantity.Text = "";

        }
    }
}
