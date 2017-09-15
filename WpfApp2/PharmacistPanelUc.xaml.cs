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
    /// Interaction logic for PharmacistPanelUc.xaml
    /// </summary>
    public partial class PharmacistPanelUc : UserControl
    {
        HMSFACTORY hmsfac;
        List<Medicine> medlist;
        Medicine medselected;

        public PharmacistPanelUc()
        {
            InitializeComponent();
            hmsfac = new HMSFACTORY();
        }
        public void LoadData(object sender, DoWorkEventArgs e)
        {
            medlist = hmsfac.getMedicine();
            this.Dispatcher.Invoke(new Action(delegate
            {
                dataGrid_AllMedicines.ItemsSource = medlist;
            }));
        }
        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += LoadData;
            worker.RunWorkerAsync();
        }

        private void fileAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new AddMedicineUc(medlist));
        }

        private void filelogoutPharmacist_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new login3());
        }

        private void medupdate_Btnu_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(medprice_update.Text) && !string.IsNullOrEmpty(medtxt_update.Text))
            {
                String name = medtxt_update.Text;
                int price = int.Parse(medprice_update.Text);
                medselected.med_name = name;
                medselected.med_price = price;

                hmsfac.updateMedicine(medselected);
                dataGrid_AllMedicines.Items.Refresh();
                MessageBox.Show("Record update success!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("All fields are required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void meddelete_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (medselected == null) return;

            MessageBoxResult result = MessageBox.Show("Do you want to delete " + medselected.med_name + "' medicine?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result)) return;
            hmsfac.remove(medselected);
            medlist.Remove(medselected);
            dataGrid_AllMedicines.Items.Refresh();
            medupdate_Btnu.IsEnabled = false;
            meddelete_Btn.IsEnabled = false;
        }

        private void dataGrid_AllMedicines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid_AllMedicines.SelectedIndex == -1 || medlist.Count <= dataGrid_AllMedicines.SelectedIndex) return;
            medselected = (Medicine)dataGrid_AllMedicines.SelectedItem;
            medupdate_Btnu.IsEnabled = true;
            meddelete_Btn.IsEnabled = true;
            medtxt_update.Text = medselected.med_name;
            medprice_update.Text = medselected.med_price.ToString();
        }
    }
}
