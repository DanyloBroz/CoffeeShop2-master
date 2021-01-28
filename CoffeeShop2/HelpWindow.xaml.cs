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
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
            text.Text = "Ця програма створена по типу роботи звичайної кав'ярні.В основному вікні можна побачити чотири клавіші за допомогою яких користувач має змогу:\n1) зробити замовлення;\n2) подивитись усю інформацію стосовно прибутку та кількості проданих кав за той чи інший день;\n3) ознайомитись з функціоналом програми;\n4) ознайомитись з історією заснуваня кав'ярні.\nТакож користувач має можливість отримати знижку на каву при наявності клубної карти.\n";
        }
    }
}
