using salesApp.wcfSales;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class ShowDataPage : Page
    {
        public ShowDataPage()
        {
            this.InitializeComponent();
        }
        private string ObjectToString(object obj)
        {
            if (obj == null)
                return "";

            if (obj is Item)
            {
                Item item = obj as Item;
                return $"Item: itemId - {item.Id}, itemName - {item.itemName}, price - {item.price}";
            }
            else if (obj is Customer)
            {
                Customer customer = obj as Customer;
                return $"Customer: customerId - {customer.customerId}, first name - {customer.First}, last name - {customer.Last}";
            }
            else if(obj is Sales)
            {
                Sales sale = obj as Sales;
                return $"Sale: id - {sale.Id}, itemId - {sale.itemId}, customerId - {sale.customerId}, quentity - {sale.quantity}, date - {sale.Date.ToShortDateString()}";
            }
            else
            {
                SaleWrapper sale = obj as SaleWrapper;
                return $"Sale: id - {sale.Id}, customer - {ObjectToString( sale.customer)}, item - { ObjectToString( sale.item)}, quentity - {sale.quantity}, date - {sale.Date.ToShortDateString()}";
            }
        }

        private async void showButton_Click(object sender, RoutedEventArgs e)
        {
            salesApp.wcfSales.Service1Client proxy = new  salesApp.wcfSales.Service1Client(); ;

            string result = "";

            switch (showBox.SelectedIndex)
            {
                case 0:
                    var allItems = await proxy.ShowAllProductAsync();

                    foreach (Item item in allItems)
                    {
                        result += ObjectToString(item) + "\n";
                    }
                    break;

                case 1:
                    var allCustomers = await proxy.ShowAllCustomerAsync();

                    foreach (Customer customer in allCustomers)
                    {
                        result += ObjectToString(customer) + "\n";
                    }
                    break;

                case 2:
                    var allSales = await proxy.ShowAllSalesAsync();

                    foreach (SaleWrapper sale in allSales)
                    {
                        result += ObjectToString(sale) + "\n";
                    }
                    break;

                case 3:
                    int saleId = int.Parse(Input.Text);
                    result = ObjectToString(await proxy.showSaleByIdAsync(saleId));
                    break;

                case 4:
                    int name = int.Parse(Input.Text);
                    result = ObjectToString(await proxy.ShowProductByIdAsync(name));
                    break;
                case 5:
                    result = ObjectToString(await proxy.AvgQuantityAsync());

                    break;

              /*  case 5:
                    string firstName = Input.Text;
                    var customers = await proxy.GetCustomerByFirstNameAsync(firstName);

                    foreach (Customer customer in customers)
                    {
                        result += ObjectToString(customer) + "\n";
                    }

                    break;

                case 6:
                    int quentity = int.Parse(Input.Text);
                    var sales = await proxy.GetSalesByQuentityAsync(quentity);

                    foreach (Sale sale in sales)
                    {
                        result += ObjectToString(sale) + "\n";
                    }
                    break;

                case 7:
                    result = await proxy.GetCountOfItemsSoldAsync();
                    break;

                case 8:
                    int customerID = int.Parse(Input.Text);
                    result = await proxy.numOfCustomerSalesAsync(customerID);
                    break;*/

            }

            ResultTxt.Text = result;
        }


        

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

     /*   private void showButton_Click(object sender, RoutedEventArgs e)
        {

        }*/
    }
}
