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
    /// Interaction logic for AddNurseUc.xaml
    /// </summary>
    public partial class AddNurseUc : UserControl
    {
        HMSFACTORY hmsfac;
        List<Nurse> nurselist;
        public AddNurseUc(List<Nurse> nurselist)
        {
            InitializeComponent();
            this.hmsfac = new HMSFACTORY();
            this.nurselist = nurselist;
        }
        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Save_btn.IsEnabled = false;
            String firstname = firstnametxt.Text;
            String lastname = lastnametxt.Text;
            String username = usernametxt.Text;
            String password = passwordbox.Password;
            String phone = cellno.Text;
            String type = "nurse";
            String gender = "female";
            int payment = Convert.ToInt32(paymenttxt.Text);
            String experience = experty.Text;
            DateTime dob = new DateTime();
            if (datepicker.SelectedDate != null)
            {
                dob = (DateTime)datepicker.SelectedDate;
            }
            if (hmsfac.getUser(username) != null)
            {
                MessageBox.Show("Username already exists!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            User u = new User();
            u.user_name = username;
            u.user_password = password;
            u.user_type = type;

            Employee emp = new Employee();

            emp.emp_firstname = firstname;
            emp.emp_lastname = lastname;
            emp.emp_phone = phone;
            emp.emp_salary = payment;
            emp.emp_dob = dob;
            emp.emp_gender = gender;
            emp.User = u;

            Nurse nurse = new Nurse();
            nurse.nurse_experience = experience;
            nurse.Employee = emp;

            hmsfac.addNurse(nurse);
            nurselist.Add(nurse);

            firstnametxt.Text = "";
            lastnametxt.Text = "";
            usernametxt.Text = "";
            passwordbox.Password = "";
            cellno.Text = "";
            paymenttxt.Text = "";
            experty.Text = "";
            this.Save_btn.IsEnabled = true;
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new admincontrol());
        }
    }
}
