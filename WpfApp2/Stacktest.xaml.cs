using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Stacktest.xaml
    /// </summary>
    public partial class Stacktest : Window
    {
         public Stacktest()
        {
            InitializeComponent();
            Switcher.stacktest = this;
            Switcher.Switch(new login3());
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

    }
}
