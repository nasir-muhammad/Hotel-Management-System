using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace WpfApp2
{
    class Switcher
    {
        public static Stacktest stacktest;
        public static void Switch(UserControl newPage)
        {
            stacktest.Navigate(newPage);
        }
    }
}
