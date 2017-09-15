using DataAccessLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for login3.xaml
    /// </summary>
    public partial class login3 : UserControl
    {
        HMSFACTORY hmsfac = new HMSFACTORY();
        public login3()
        {
            InitializeComponent();
        }
        private void login_click(object sender, RoutedEventArgs e)
        {
            String user = txtName.Text;
            String pass = txtpassword.Password;
            User loguser;
            if ((loguser = hmsfac.getUser(user, pass)) != null)
            {
                if (loguser.user_type.Equals("admin"))
                {
                    Switcher.stacktest.Navigate(new admincontrol());
                }
                else if (loguser.user_type.Equals("pharmacist"))
                {
                    Switcher.stacktest.Navigate(new PharmacistPanelUc());
                }
                else if (loguser.user_type.Equals("doctor"))
                {
                    Switcher.stacktest.Navigate(new DoctorPanelUc(loguser,this));
                }
                else if (loguser.user_type.Equals("nurse"))
                {
                    Switcher.stacktest.Navigate(new NursePanelUc(loguser,this));
                }
            }
        }
    }
}
