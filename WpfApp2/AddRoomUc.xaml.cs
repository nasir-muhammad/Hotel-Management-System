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
    /// Interaction logic for AddRoomUc.xaml
    /// </summary>
    public partial class AddRoomUc : UserControl
    {
        List<Room> roomlist;
        List<Nurse> nurselist;
        HMSFACTORY hmsfac;
        public AddRoomUc(List<Nurse> nlist,List<Room> rlist,HMSFACTORY hms)
        {
            this.roomlist = rlist;
            InitializeComponent();
            this.hmsfac = hms;
            this.nurselist = nlist;
            cboGovernedBy.ItemsSource = nlist;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Save_Btn.IsEnabled = false;
            this.Cancel_Btn.IsEnabled = false;
            String beds = noofbedstxt.Text;
            String nurid = cboGovernedBy.SelectedValue.ToString();
            int Totalbeds = int.Parse(beds);
            int nid = int.Parse(nurid);

            Nurse n = hmsfac.getNurseByNid(nid);
            Room r = new Room();
            r.Nurse = n;
            r.availbeds = Totalbeds;
            r.totalbeds = Totalbeds;

            String Nursename = cboGovernedBy.Text;
            hmsfac.addRoom(r);
            roomlist.Add(r);

            this.noofbedstxt.Text =" ";
            this.cboGovernedBy.Text =" ";

        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new login3());
        }

    }
}
