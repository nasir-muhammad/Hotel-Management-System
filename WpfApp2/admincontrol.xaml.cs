using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for admincontrol.xaml
    /// </summary>
    public partial class admincontrol : UserControl
    {
        List<Patient> patientList;
        List<Doctor> doctorList;
        List<Nurse> nurseList;
        HMSFACTORY hmsfac;
        List<Room> roomList;
        int indexselected = -1;
        Doctor docselected = null;
        Nurse nurselected = null;
        Patient patselected = null;
        Room roomselected = null;
        public admincontrol()
        {
            InitializeComponent();
            hmsfac = new HMSFACTORY();
            this.firstnametxt_update.Visibility = System.Windows.Visibility.Hidden;
            this.lastnametxt_update.Visibility = System.Windows.Visibility.Hidden;
            this.datepicker_update.Visibility = System.Windows.Visibility.Hidden;
            this.cellno_update.Visibility = System.Windows.Visibility.Hidden;

            this.usernametxt_update.Visibility = System.Windows.Visibility.Hidden;
            this.passwordbox_update.Visibility = System.Windows.Visibility.Hidden;
            this.specialization_update.Visibility = System.Windows.Visibility.Hidden;
            this.salary_update.Visibility = System.Windows.Visibility.Hidden;
            this.datepicker_update.Visibility = System.Windows.Visibility.Hidden;
            this.btn_delete.Visibility = System.Windows.Visibility.Hidden;
            this.btn_update.Visibility = System.Windows.Visibility.Hidden;
            //this.rbFemale_update.Visibility = System.Windows.Visibility.Hidden;
            //this.rbMale_update.Visibility = System.Windows.Visibility.Hidden;

            
        }
        public void LoadData(object sender, DoWorkEventArgs e)
        {
            doctorList = hmsfac.getDoctor();
            nurseList = hmsfac.getNurse();
            patientList = hmsfac.getPatient();
            roomList = hmsfac.getRoom();
            this.Dispatcher.Invoke(new Action(delegate
                {
                    dataGrid_Doctor.ItemsSource = doctorList;
                    dataGrid_Nurse.ItemsSource = nurseList;
                    dataGrid_Patient.ItemsSource = patientList;
                    dataGrid_Room.ItemsSource = roomList;

                    specialization_update.ItemsSource = hmsfac.getCategories();
                    governedbytxt_update.ItemsSource = nurseList;
                }));
        }
        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += LoadData;
            worker.RunWorkerAsync();

        }
        private void AddDoctor_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new AddDoctorUc(doctorList));
            dataGrid_Doctor.Items.Refresh();
        }
        private void AddNurse_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new AddNurseUc(nurseList));
            dataGrid_Nurse.Items.Refresh();
        }

        private void AddPatient_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new AddPatientUc(patientList));
            dataGrid_Doctor.Items.Refresh();
        }

        private void AddRoom_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new AddRoomUc(nurseList,roomList,hmsfac));
            dataGrid_Patient.Items.Refresh();
        }
        private void Logout_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new login3());
        }

        private void AddPharmacist_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new AddPharmacistUc());
        }

        private void dataGrid_Doctor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            this.firstnametxt_update.Visibility = System.Windows.Visibility.Visible;
            this.lastnametxt_update.Visibility = System.Windows.Visibility.Visible;
            this.datepicker_update.Visibility = System.Windows.Visibility.Visible;
            this.cellno_update.Visibility = System.Windows.Visibility.Visible;

            this.usernametxt_update.Visibility = System.Windows.Visibility.Visible;
            this.passwordbox_update.Visibility = System.Windows.Visibility.Visible;
            this.specialization_update.Visibility = System.Windows.Visibility.Visible;
            this.salary_update.Visibility = System.Windows.Visibility.Visible;
            this.datepicker_update.Visibility = System.Windows.Visibility.Visible;
            this.btn_delete.Visibility = System.Windows.Visibility.Visible;
            this.btn_update.Visibility = System.Windows.Visibility.Visible;
            this.rbFemale_update.Visibility = System.Windows.Visibility.Visible;
            this.rbMale_update.Visibility = System.Windows.Visibility.Visible;
            this.indexselected = dataGrid_Doctor.SelectedIndex;
            if (indexselected == -1 || doctorList.Count <= indexselected)
            {
                docselected = null;
                this.btn_delete.IsEnabled = false;
                this.btn_update.IsEnabled = false;
                return;
            }
            this.btn_update.IsEnabled = true;
            this.btn_update.IsEnabled = true;
            docselected = (Doctor)dataGrid_Doctor.SelectedItem;

            this.firstnametxt_update.Text = docselected.Employee.emp_firstname;
            this.lastnametxt_update.Text = docselected.Employee.emp_lastname;
            this.usernametxt_update.Text = docselected.Employee.User.user_name;
            this.passwordbox_update.Password = docselected.Employee.User.user_password;
            this.specialization_update.Text = docselected.Category.cat_name;
            this.cellno_update.Text = docselected.Employee.emp_phone;
            this.salary_update.Text = docselected.Employee.emp_salary.ToString();
            this.datepicker_update.Text = docselected.Employee.emp_dob.ToString();
            if (docselected.Employee.emp_gender.Equals("female"))
            {
                rbFemale_update.IsChecked = true;
            }
            else
            {
                rbMale_update.IsChecked = true;
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (docselected == null)
            {
                return;
            }

            String updated_firstname = firstnametxt_update.Text;
            String updated_lastname = lastnametxt_update.Text;
            String updated_username = usernametxt_update.Text;
            String updated_password = passwordbox_update.Password;
            String updated_cellno = cellno_update.Text;
            int updated_salary = int.Parse(salary_update.Text);
            DateTime dob = new DateTime();
            dob = (DateTime)datepicker_update.SelectedDate;
            int catid = int.Parse(specialization_update.SelectedValue.ToString());
            String type = "doctor";
            String gender = "male";
            if (rbFemale_update.IsChecked ?? false)
            {
                gender = "female";
            }

            docselected.Employee.emp_firstname = updated_firstname;
            docselected.Employee.emp_lastname = updated_lastname;
            docselected.Employee.emp_phone = updated_cellno;
            docselected.Employee.emp_gender = gender;
            docselected.Employee.emp_salary = updated_salary;
            docselected.Employee.emp_dob = dob;
            docselected.cat_id = catid;

            docselected.Employee.User.user_type = type;
            docselected.Employee.User.user_password = updated_password;
            docselected.Employee.User.user_name = updated_username;

            hmsfac.updateDoctor(docselected);
            dataGrid_Doctor.Items.Refresh();
            patientList = hmsfac.getPatient();
            dataGrid_Patient.Items.Refresh();

            this.btn_update.IsEnabled = false;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (docselected == null)
            {
                return;
            }
            MessageBoxResult result = MessageBox.Show("Do you want to delete " + docselected.Employee.emp_firstname + "'s record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result))
            {
                return;
            }
            hmsfac.remove(docselected);
            doctorList.Remove(docselected);
            dataGrid_Doctor.Items.Refresh();
        }
        private void dataGrid_Nurse_SelectionChanged(object sender, RoutedEventArgs e)
        {
            this.indexselected = dataGrid_Nurse.SelectedIndex;
            if (indexselected == -1 || nurseList.Count <= indexselected)
            {
                nurselected = null;
                this.nurse_btnDelete.IsEnabled = false;
                this.nurse_btnUpdate.IsEnabled = false;
                return;
            }
            this.nurse_btnDelete.IsEnabled = true;
            this.nurse_btnUpdate.IsEnabled = true;
            nurselected = (Nurse)dataGrid_Nurse.SelectedItem;

            this.fnametxt_nurseUpdate.Text = nurselected.Employee.emp_firstname;
            this.lnametxt_nurseUpdate.Text = nurselected.Employee.emp_lastname;
            this.unametxt_nurseUpdate.Text = nurselected.Employee.User.user_name;
            this.passtxt_nurseUpdate.Password = nurselected.Employee.User.user_password;
            this.spectxt_nurseUpdate.Text = nurselected.nurse_experience;
            this.cellno_nurseUpdate.Text = nurselected.Employee.emp_phone;
            this.saltxt_nurseUpdate.Text = nurselected.Employee.emp_salary.ToString();
            this.datepicker_nurseUpdate.Text = nurselected.Employee.emp_dob.ToString();

        }

        private void btn_UpdateNurse_Click(object sender, RoutedEventArgs e)
        {
            if (nurselected == null)
            {
                return;
            }

            String firstname = fnametxt_nurseUpdate.Text;
            String lastname = lnametxt_nurseUpdate.Text;
            String username = unametxt_nurseUpdate.Text;
            String password = passtxt_nurseUpdate.Password;
            String experience = spectxt_nurseUpdate.Text;
            String phone = cellno_nurseUpdate.Text;
            DateTime dob = (DateTime)datepicker_nurseUpdate.SelectedDate;
            int salary = int.Parse(saltxt_nurseUpdate.Text);
            String gender = "female";
            String type = "nurse";
            nurselected.Employee.emp_firstname = firstname;
            nurselected.Employee.emp_lastname = lastname;
            nurselected.Employee.emp_phone = phone;
            nurselected.Employee.emp_salary = salary;
            nurselected.Employee.emp_gender = gender;
            nurselected.Employee.emp_dob = dob;

            nurselected.Employee.User.user_name = username;
            nurselected.Employee.User.user_password = password;
            nurselected.Employee.User.user_type = type;

            hmsfac.updateNurse(nurselected);
            dataGrid_Nurse.Items.Refresh();
            roomList = hmsfac.getRoom();
            dataGrid_Room.ItemsSource = roomList;

        }

        private void btn_Nursedelete_Click(object sender, RoutedEventArgs e)
        {
            if (nurselected == null) return;

            MessageBoxResult result = MessageBox.Show("Do you want to delete " + nurselected.Employee.emp_firstname + "'s record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result)) return;
            hmsfac.remove(nurselected);
            nurseList.Remove(nurselected);
            dataGrid_Nurse.Items.Refresh();
        }
        private void dataGrid_Patient_SelectionChanged(object sender, RoutedEventArgs e)
        {
            this.indexselected = dataGrid_Patient.SelectedIndex;
            if (indexselected == -1 || patientList.Count <= indexselected)
            {
                patselected = null;
                this.nurse_btnDelete.IsEnabled = false;
                this.nurse_btnUpdate.IsEnabled = false;
                return;
            }
            patselected = (Patient)dataGrid_Patient.SelectedItem;
            this.patnametxt_update.Text = patselected.pat_name;
            this.patdatepicker_update.Text = patselected.pat_dob.ToString();
            this.patcombobox_update.Text = patselected.pat_type;
            if (patselected.pat_gender.Equals("female"))
                patrbfemale_update.IsChecked = true;
            else
                patrbmale_update.IsChecked = true;
        }

        private void patbtn_update_Click(object sender, RoutedEventArgs e)
        {
            if (patselected == null) return;



            String fullname = patnametxt_update.Text;
            DateTime dob = (DateTime)patdatepicker_update.SelectedDate;
            String gender = "male";
            if (((patrbfemale_update.IsChecked ?? false) || (patrbfemale_update.IsChecked ?? false))
                && !string.IsNullOrEmpty(patdatepicker_update.Text))
            {
                if (patrbfemale_update.IsChecked ?? false)
                    gender = "female";
            }

            patselected.pat_name = fullname;
            patselected.pat_dob = dob;
            patselected.pat_gender = gender;
            patselected.pat_type = patcombobox_update.Text;

            hmsfac.updatePatient(patselected);


            MessageBox.Show("Record updated success.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            dataGrid_Patient.Items.Refresh();
        }

        private void patbtn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (patselected == null)
            {
                return;
            }


            MessageBoxResult result = MessageBox.Show("Do you want to delete " + patselected.pat_name + "'s record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result)) return;
            hmsfac.remove(patselected);
            patientList.Remove(patselected);
            dataGrid_Patient.Items.Refresh();
            //IndoorList = hms.getIndoors();
            dataGrid_IndoorPatients.Items.Refresh();
            
        }

        private void dataGrid_Room_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.indexselected = dataGrid_Room.SelectedIndex;
            if (indexselected == -1 || roomList.Count <= indexselected)
            {
                roomselected = null;
                roombtn_delete.IsEnabled = false;
                roombtn_update.IsEnabled = false;
                return;
            };


            roombtn_delete.IsEnabled = true;
            roombtn_update.IsEnabled = true;
            //roomSelected = (room)RoomList.ElementAt<room>(dataGrid_Room.SelectedIndex);
            roomselected = (Room)dataGrid_Room.SelectedItem;

            noofbedstxt_update.Text = roomselected.totalbeds.ToString();
            governedbytxt_update.Text = roomselected.Nurse.Employee.emp_firstname;

        }

        private void roombtn_update_Click(object sender, RoutedEventArgs e)
        {
            if (roomselected == null) return;

            String TotalBeds = noofbedstxt_update.Text;
            String strNid;
            if (!string.IsNullOrEmpty(TotalBeds) && !string.IsNullOrEmpty(governedbytxt_update.Text))
            {
                strNid = governedbytxt_update.SelectedValue.ToString();

                try
                {

                    int newBeds = int.Parse(TotalBeds);
                    int nid = int.Parse(strNid);
                    int prevBeds = roomselected.totalbeds;
                    int diffBeds = newBeds - prevBeds;
                    roomselected.totalbeds = newBeds;
                    roomselected.availbeds += diffBeds;
                    roomselected.nurse_id = nid;
                    hmsfac.updateRoom(roomselected);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was some error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBox.Show("Record updated success.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                dataGrid_Room.Items.Refresh();

            }
        }

    }

}
