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
    /// Interaction logic for AddMedicineUc.xaml
    /// </summary>
    public partial class AddMedicineUc : UserControl
    {
        List<Medicine> medList;
        HMSFACTORY hmsfac;
        public AddMedicineUc(List<Medicine> medList)
        {
            InitializeComponent();
            this.medList = medList;
            hmsfac = new HMSFACTORY();
        }
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new PharmacistPanelUc());
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(mednametxt.Text) && !string.IsNullOrEmpty(medpricetxt.Text))
            {
                btn_Save.IsEnabled = false;
                String name = mednametxt.Text;
                int price = int.Parse(medpricetxt.Text);

                Medicine med = new Medicine();
                med.med_name = name;
                med.med_price = price;
                hmsfac.addMedicine(med);
                medList.Add(med);

                mednametxt.Text = "";
                medpricetxt.Text = "";
            }
            else
                MessageBox.Show("All fields are required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
