using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace salesApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        salesApp.wcfSales.Service1Client proxys;
        public  MainPage()
        {
            this.InitializeComponent();
            proxys = new salesApp.wcfSales.Service1Client();
           // showallcustomer();
        }
        public async void showallcustomer()
        {
            var result = await proxys.ShowAllCustomerAsync();  // בניית רשימה של התוצאות  

            //lstUsers.ItemsSource = result;  // הצגת הרשימה שנבנתה 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = ChBox.SelectedIndex;
            if (index ==0)
            {
                Frame.Navigate(typeof(ShowDataPage));
            }
            else
            {
                Frame.Navigate(typeof(AddDataPage));

            }
        }
    }
}
