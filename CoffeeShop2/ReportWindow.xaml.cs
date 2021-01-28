using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CoffeeShop2.Entities;
using System.Linq;

namespace CoffeeShop2
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private CoffeeShop2Context roffeeShop2Context;
        public ReportWindow()
        {
            InitializeComponent();
            roffeeShop2Context = new CoffeeShop2Context();
            data.SelectedDate = DateTime.Now;
        }
        private void Report_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = 0;
        }
        private void Report_DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int i = 0;
        }

        private void result_Click(object sender, RoutedEventArgs e)
        {

            var r = roffeeShop2Context.Set<Drink>().ToList();

            List<Order> orders = new List<Order> { };

            foreach (var item in r)
            {
                var res_item = roffeeShop2Context.Set<Order>().Where(u => u.DrinkId==item.Id && u.Date==data.SelectedDate ).ToList();
                int suma_count = 0;
                float suma_price = 0;
                foreach (var item1 in res_item)
                {
                    suma_count = item1.Count;
                    suma_price = item1.Price;
                }
                Order order = new Order();
                order.DrinkId = item.Id;
                order.Price = suma_price;
                order.Count = suma_count;
                order.Date = new DateTime();
                orders.Add(order);
            }

            var res = orders.Join
                 (roffeeShop2Context.Set<Drink>(),
                     drinkId1 => drinkId1.DrinkId,
                     drinkId2 => drinkId2.Id,
                     (drinkId1, drinkId2) => new
                     {
                         Name = drinkId2.Name,
                         GlassSize = drinkId2.GlassSize,
                         Count = drinkId1.Count,
                         Price = drinkId1.Price,
                     }
                 ).ToList();
            Report_DataGrid.ItemsSource = res;


        }
    }
}
