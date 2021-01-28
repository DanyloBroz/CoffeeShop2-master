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
using System.Linq;
using CoffeeShop2.Entities;

namespace CoffeeShop2
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private CoffeeShop2Context roffeeShop2Context;

        private List<Order> list_order;
        public void UpdateButton(List<Button> buttons)
        {
            foreach (var button in buttons)
            {
                string text_button = button.Name;
                var info = text_button.Split('_');
                string name = info[0];
                string size = info[1];
                var res = roffeeShop2Context.Set<Drink>().Where(u => u.Name == name && u.GlassSize == size).ToList();

                if (res.Count == 1)
                {
                    button.Content = res[0].Price;
                }
                else
                {
                    button.Visibility = Visibility.Hidden;
                }
            }
        }
        public OrderWindow()
        {
            InitializeComponent();
            roffeeShop2Context = new CoffeeShop2Context();
            List<Button> buttons = new List<Button> { Espresso_S, Espresso_L, Espresso_XL, Dopio_S, Dopio_L, Dopio_XL, Americano_S, Americano_L, Americano_XL, AmericanoMilk_S, AmericanoMilk_L, AmericanoMilk_XL, Latte_S, Latte_L, Latte_XL, Cocoa_S, Cocoa_L, Cocoa_XL, RafCoffee_S, RafCoffee_L, RafCoffee_XL, Tea_S, Tea_L, Tea_XL };
            UpdateButton(buttons);
            list_order = new List<Order> { };

        }

        public float Suma_Order()
        {
            float suma = 0;
            foreach (var item in list_order)
            {
                suma += item.Price;
            }
            return suma* (100 - float.Parse(dic.Text)) / 100;
        }

        public void updeat_data_grid()
        {
            var res = list_order.Join
                  (roffeeShop2Context.Set<Drink>(),
                      drinkId1 => drinkId1.DrinkId,
                      drinkId2 => drinkId2.Id,
                      (drinkId1, drinkId2) => new
                      {
                          Name = drinkId2.Name,
                          GlassSize = drinkId2.GlassSize,
                          Count = drinkId1.Count,
                          Price = drinkId1.Price
                      }
                  ).ToList();
            order_DataGrid.ItemsSource = res;
            suma.Text = "Suma :" + Suma_Order().ToString()+" ;";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)e.OriginalSource;
            string text_button = button.Name;
            var info = text_button.Split('_');
            string name = info[0];
            string size = info[1];
            Drink drink = roffeeShop2Context.Set<Drink>().Where(u => u.Name == name && u.GlassSize == size).ToList()[0];
            bool flag = false;
            foreach (var ord in list_order)
            {
                if (ord.DrinkId == drink.Id)
                {
                    flag = true;
                    ord.Count += 1;
                    ord.Price += drink.Price;
                    break;
                }
            }
            if (flag == false)
            {
                Order order = new Order();
                order.DrinkId = drink.Id;
                order.Count = 1;
                order.Date =  DateTime.Now.Date;
                order.Price = drink.Price;
                list_order.Add(order);
            }
            updeat_data_grid();

        }

        private void Order_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = 0;
        }
        private void Order_DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int i = 0;
        }

        private void Make_Order_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in list_order)
            {
                item.Price *= (100 - float.Parse(dic.Text))/100 ;
                roffeeShop2Context.Add<Order>(item);   
            }
            roffeeShop2Context.SaveChangesAsync();
           
            Close();

        }

       

        private void DiscountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(DiscountTextBox.Text);
                var res = roffeeShop2Context.Set<Discount>().Where(u => u.Id == id).ToList();
                if (res.Count == 1)
                {
                    dic.Text = res[0].Rebate.ToString();
                  
                }
                else
                {
                    dic.Text = "0";
                }
            }
            catch
            {
                dic.Text = "0";
            }
            suma.Text = "Suma : " + Suma_Order().ToString() + " ;";
        }
    }
}
