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

namespace CoffeeShop2
{
    /// <summary>
    /// Interaction logic for AboutWindow1.xaml
    /// </summary>
    public partial class AboutWindow1 : Window
    {
        public AboutWindow1()
        {
            InitializeComponent();
            text1.Text = "Кав'ярня була заснована в 2013 році";
            text2.Text = "Наші зерна вирощують в Ефіопії та Бразилії";
            text3.Text = "Ми одні з перших на ринку хто дозволив відвідування кав'ярні з домашніми улюбленцями";
            text4.Text = "У нашій мережі діє програма лояльності та хороші знижки для постійних гостей";
            text5.Text = "Часто проводимо майстеркласи з приготування кави та інших напоїв";
        }
    }
}
