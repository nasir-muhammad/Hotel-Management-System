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
    /// Interaction logic for NursePanelUc.xaml
    /// </summary>
    public partial class NursePanelUc : UserControl
    {
        login3 login;
        Nurse owner;
        HMSFACTORY hmsfac = new HMSFACTORY();
        List<IndoorPatient> patList;
        List<Room> roomList;

        public NursePanelUc(User ownerUser,login3 login)
        {
            InitializeComponent();
            this.owner = hmsfac.getNurseByUid(ownerUser.user_id);
            this.login = login;
            patList = hmsfac.getMyPatient(owner);
            roomList = hmsfac.getMyRooms(owner);

            dataGrid_MyRoom.ItemsSource = roomList;
            dataGrid_MyPatient.ItemsSource = patList;
        }

        private void filelogoutnurse_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new login3());
        }

        private void searchpattxt_nurse_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;

            String filter = t.Text;
            if (filter == "")
            {
                if (searchpatcombo_nurse.SelectedValue != null)
                {
                    IndoorPatient indo = new IndoorPatient();
                    String selected = searchpatcombo_nurse.SelectedValue.ToString().ToLower();
                    if (selected.Equals("name"))
                    {
                        indo.Patient.pat_name = filter;
                        patList = hmsfac.getIndoorPatient(indo);
                    }
                    else if (selected.Equals("gender"))
                    {
                        indo.Patient.pat_gender = filter;
                        patList = hmsfac.getIndoorPatient(indo);
                    }
                    else if (selected.Equals("room no"))
                    {
                        indo.room_id = int.Parse(filter);
                        patList = hmsfac.getIndoorPatient(indo);
                    }
                }
                else return;
            }
            else
                return;
        }

        private void searchroomtxt_nurse_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;

            String filter = t.Text;
            int filt;
            bool result = Int32.TryParse(filter,out filt);
            if (result)
            {
                if (searchroomcombo_nurse.SelectedValue != null)
                {
                    Room indo = new Room();
                    String selected = searchroomcombo_nurse.SelectedValue.ToString().ToLower();
                    if (selected.Equals("available beds"))
                    {
                        indo.availbeds = filt;
                        roomList = hmsfac.getRoom(indo);
                    }
                    else if (selected.Equals("total beds"))
                    {
                        indo.totalbeds = filt;
                        roomList = hmsfac.getRoom(indo);
                    }
                    else if (selected.Equals("room no"))
                    {
                        indo.room_id = filt;
                        roomList = hmsfac.getRoom(indo);
                    }
                }
                else return;
            }
            else
                return;
            /*Console.WriteLine(filter);
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_MyRoom.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Room indo = o as Room;
                    if (searchroomcombo_nurse.SelectedValue != null)
                    {
                        String selected = searchroomcombo_nurse.SelectedValue.ToString().ToLower();
                        Console.WriteLine(selected);
                        if (selected.Equals ("available beds"))
                        {
                            Console.WriteLine("write here");
                            return (indo.room_id.ToString().StartsWith(filter.ToLower()));
                        }
                        else if (selected == "total beds")
                        {
                            Console.WriteLine("write here 2");
                            return (indo.totalbeds.ToString().StartsWith(filter.ToLower()));
                        }
                        else if (selected == "room no")
                            return (indo.room_id.ToString().ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    return false;
                };
            }*/
        }
    }
}
