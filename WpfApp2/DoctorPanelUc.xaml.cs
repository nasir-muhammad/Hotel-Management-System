using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for DoctorPanelUc.xaml
    /// </summary>
    public partial class DoctorPanelUc : UserControl
    {
        login3 login;
        User user;
        HMSFACTORY hmsfac;
        int indexSelected = -1;
        Patient patSelected = null;
        IndoorPatient oldPatSelected = null;
        Prescription presSelected = null;
        List<Patient> NewPatientList;
        List<IndoorPatient> OldPatientList;
        List<Medicine> medicineList;
        List<Prescription> presList;
        Doctor docOwner;
        public DoctorPanelUc(User u, login3 login)
        {
            hmsfac = new HMSFACTORY();
            InitializeComponent();
            this.login = login;
            user = u;
            docOwner = hmsfac.getDoctorByUid(user.user_id);
            NewPatientList = hmsfac.getMyPatients(docOwner);
            OldPatientList = hmsfac.getMyOldPatients(docOwner);
            medicineList = hmsfac.getMedicine();
            presList = hmsfac.getMyPrescriptions(docOwner);

            patmed_doc.ItemsSource = medicineList;
            patmed1_doc.ItemsSource = medicineList;
            patmed2_doc.ItemsSource = medicineList;
            oldpatmed_doc.ItemsSource = medicineList;
            mypresc_med.ItemsSource = medicineList;

            patmed_doc.SelectedValuePath = "med_id";
            patmed_doc.DisplayMemberPath = "med_name";
            patmed1_doc.SelectedValuePath = "med_id";
            patmed1_doc.DisplayMemberPath = "med_name";
            patmed2_doc.DisplayMemberPath = "med_name";
            patmed2_doc.SelectedValuePath = "med_id";
            oldpatmed_doc.SelectedValuePath = "med_id";
            mypresc_med.DisplayMemberPath = "med_name";

            dataGrid_NewPatient.ItemsSource = NewPatientList;
            dataGrid_MyPrescriptions.ItemsSource = presList;
            dataGrid_OldPatient.ItemsSource = OldPatientList;
        }

        private void dataGrid_NewPatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.indexSelected = dataGrid_NewPatient.SelectedIndex;
            if (indexSelected == -1 || NewPatientList.Count <= indexSelected)
            {
                patSelected = null;
                submit_presc.IsEnabled = false;
                return;
            };


            submit_presc.IsEnabled = true;
            //patSelected = (patient)patientList.ElementAt<patient>(dataGrid_NewPatient.SelectedIndex);
            patSelected = (Patient)dataGrid_NewPatient.SelectedItem;

            if (patSelected.pat_type != "In process")
                pattypecombo_doc.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(patSelected.pat_type);

        }

        private void fileAddDoctor_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new login3());
        }

        private void submit_presc_Click(object sender, RoutedEventArgs e)
        {
            if (patSelected == null) return;

            if (string.IsNullOrEmpty(pattypecombo_doc.Text))
            {
                MessageBox.Show("Please select patient type.", "Reminder", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }


            if (pattypecombo_doc.Text.Equals("Indoor"))
            {
                if (string.IsNullOrEmpty(patdisease_doc.Text))
                {
                    MessageBox.Show("Please enter a diease", "Reminder", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                IndoorPatient patIndoor = new IndoorPatient();
                DateTime admitdate = DateTime.Today;
                patIndoor.indpat_disease = patdisease_doc.Text;
                patIndoor.Patient = patSelected;
                patIndoor.admit_date = admitdate;
                patIndoor.indpat_status = "admitted";
                hmsfac.addIndoor(patIndoor);
                patSelected.pat_type = "indoor";
            }
            else
            {
                patSelected.pat_type = "outdoor";
            }


            if (!string.IsNullOrEmpty(patmed_doc.Text))
            {

                int mid1 = int.Parse(patmed_doc.SelectedValue.ToString());

                string dosage1 = patdosage_doc.Text;

                Prescription p1 = new Prescription();
                p1.med_id = mid1;
                p1.presc_dosage = dosage1;
                p1.pat_id = patSelected.pat_id;
                p1.doc_id = docOwner.doc_id;
                hmsfac.addPrescription(p1);
                presList.Add(p1);


                if (!string.IsNullOrEmpty(patmed1_doc.Text))
                {
                    Prescription p2 = new Prescription();
                    p2.med_id = int.Parse(patmed1_doc.SelectedValue.ToString());
                    p2.presc_dosage = patdosage1_doc.Text;
                    p2.pat_id = patSelected.pat_id;
                    p2.doc_id = docOwner.doc_id;
                    hmsfac.addPrescription(p2);
                    presList.Add(p2);
                }

                if (!string.IsNullOrEmpty(patmed2_doc.Text.ToString()))
                {
                    Prescription p3 = new Prescription();
                    p3.med_id = int.Parse(patmed2_doc.SelectedValue.ToString());
                    p3.presc_dosage = patdosage2_doc.Text;
                    p3.pat_id = patSelected.pat_id;
                    p3.doc_id = docOwner.doc_id;
                    hmsfac.addPrescription(p3);
                    presList.Add(p3);
                }

                patSelected.doc_id = docOwner.doc_id;
                hmsfac.updatePatient(patSelected);
                NewPatientList.Remove(patSelected);
                dataGrid_NewPatient.Items.Refresh();
                dataGrid_MyPrescriptions.Items.Refresh();
                MessageBox.Show("Prescription submisson success.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                dataGrid_OldPatient.ItemsSource = hmsfac.getMyOldPatients(docOwner);
                dataGrid_OldPatient.Items.Refresh();

            }
            else
            {
                MessageBox.Show("At least one medicine is required for prescription", "Reminder", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        private void dataGrid_OldPatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            oldPatSelected = (IndoorPatient)dataGrid_OldPatient.SelectedItem;
            addpresc_doc.IsEnabled = true;
            changestatus_doc.IsEnabled = true;
        }

        private void addpresc_doc_Click(object sender, RoutedEventArgs e)
        {
            String MedName = oldpatmed_doc.Text;
            String Dosage = oldpatmed_dosage.Text;

            if (!string.IsNullOrEmpty(MedName) && !string.IsNullOrEmpty(Dosage))
            {
                Prescription p = new Prescription();
                p.med_id = int.Parse(oldpatmed_doc.SelectedValue.ToString());
                p.presc_dosage = Dosage;
                p.pat_id = oldPatSelected.pat_id;
                p.doc_id = docOwner.doc_id;
                hmsfac.addPrescription(p);
                presList.Add(p);
            }
            else
            {
                MessageBox.Show("All fields are required.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBox.Show("Prescription added successfully!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            dataGrid_MyPrescriptions.Items.Refresh();

        }

        private void changestatus_doc_Click(object sender, RoutedEventArgs e)
        {
            if (oldPatSelected.indpat_status.ToLower().Equals("admitted"))
            {
                oldPatSelected.indpat_status = "discharged";
                Room r = oldPatSelected.Room;
                r.availbeds++;
                hmsfac.updateRoom(r);
                MessageBox.Show("Patient status changed to discharged!", "Operation Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {
                oldPatSelected.indpat_status = "admitted";
                Room r = oldPatSelected.Room;
                if (r.availbeds == 0)
                {
                    MessageBox.Show("No bed available in the current room.", "Reminder", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                r.availbeds--;
                hmsfac.updateRoom(r);
                MessageBox.Show("Patient status changed to admitted!", "Operation Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            hmsfac.updateIndoor(oldPatSelected);
            dataGrid_OldPatient.Items.Refresh();

        }

        private void patmed_doc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patmed1_doc.IsEnabled = true;
            patdosage1_doc.IsEnabled = true;
        }

        private void patmed1_doc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patmed2_doc.IsEnabled = true;
            patdosage2_doc.IsEnabled = true;
        }

        private void pattypecombo_doc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pattypecombo_doc.SelectedValue.ToString().Equals("Indoor"))
                patdisease_doc.IsEnabled = true;
            else
                patdisease_doc.IsEnabled = false;
        }

        private void dataGrid_MyPrescriptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.indexSelected = dataGrid_MyPrescriptions.SelectedIndex;
            if (indexSelected == -1 || presList.Count <= indexSelected)
            {
                presSelected = null;
                updteBtn_pres.IsEnabled = false;
                return;
            };


            updteBtn_pres.IsEnabled = true;
            //presSelected = (prescription)presList.ElementAt<prescription>(dataGrid_Pres.SelectedIndex);
            presSelected = (Prescription)dataGrid_MyPrescriptions.SelectedItem;

            if (presSelected.Patient.pat_type != null)
                mypresc_pattype.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(presSelected.Patient.pat_type);
            if (presSelected.Patient.pat_type.Equals("outdoor"))
                mypresc_disease.IsEnabled = false;
            else if (presSelected.Patient.pat_type.Equals("indoor"))
            {
                IndoorPatient indo = hmsfac.getIndoorByPid(presSelected.pat_id);
                mypresc_disease.IsEnabled = true;
                mypresc_disease.Text = indo.indpat_disease;
            }

            mypresc_med.Text = presSelected.Medicine.med_name;
            mypresc_dosage.Text = presSelected.presc_dosage;

        
        }

        private void updteBtn_pres_Click(object sender, RoutedEventArgs e)
        {
            if (presSelected == null) return;



            String patType = mypresc_pattype.Text;
            int mid = int.Parse(mypresc_med.SelectedValue.ToString());
            String Dosage = mypresc_dosage.Text;
            String disease = null;

            if (string.IsNullOrEmpty(patType) || string.IsNullOrEmpty(Dosage))
            {
                MessageBox.Show("Please make sure all attributes are compelted.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            string prevType = presSelected.Patient.pat_type;
            presSelected.Patient.pat_type = patType.ToLower();
            presSelected.med_id = mid;
            presSelected.presc_dosage = Dosage;



            disease = mypresc_disease.Text;

            IndoorPatient indo = hmsfac.getIndoorByPid(presSelected.pat_id);
            if (patType.ToLower().Equals("indoor") && prevType.Equals("outdoor"))
            {
                if (!String.IsNullOrEmpty(disease))
                {

                    IndoorPatient indpat = new IndoorPatient();
                    indpat.indpat_disease = disease;
                    indpat.pat_id = presSelected.pat_id;
                    indpat.indpat_status = "admitted";
                    hmsfac.addIndoor(indpat);
                }
                else
                {
                    MessageBox.Show("Please enter a diesease.");
                    return;
                }
            }
            else if (patType.ToLower().Equals("outdoor"))
            {

                if (indo != null)
                    hmsfac.remove(indo);
            }
            else
            {
                indo.indpat_disease = disease;
                hmsfac.updateIndoor(indo);
            }



            hmsfac.updatePrescription(presSelected);


            MessageBox.Show("Record updated success.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            dataGrid_MyPrescriptions.Items.Refresh();
            NewPatientList = hmsfac.getPatient();
            dataGrid_NewPatient.Items.Refresh();

        }

    }
}
