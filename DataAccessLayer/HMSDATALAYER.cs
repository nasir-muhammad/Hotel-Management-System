using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class HMSDATALAYER
    {
        HospitalManagementSystemEntities db;
        public HMSDATALAYER()
        {
            db = new HospitalManagementSystemEntities();
        }

        public User getUser(String user, String pass)
        {
            return db.Users.Where(x => (x.user_name == user && x.user_password == pass)).FirstOrDefault();
        }
        public User getUser(String user)
        {
            return db.Users.Where(x => (x.user_name == user)).FirstOrDefault();
        }
        public Doctor addDoctor(Doctor doc)
        {
            db.Doctors.Add(doc);
            db.SaveChanges();
            Doctor doct = db.Doctors.Where(x=>x.doc_id == doc.doc_id).FirstOrDefault();
            return doct;
        }
        public List<Doctor> getDoctor()
        {
            return db.Doctors.ToList();
        }
        public List<Nurse> getNurse()
        {
            return db.Nurses.ToList();
        }
        public void addNurse(Nurse nurse)
        {
            db.Nurses.Add(nurse);
            db.SaveChanges();
        }
        public List<Category> getCategories()
        {
            return db.Categories.ToList();
        }
        public void addpatient(Patient pat)
        {
            db.Patients.Add(pat);
            db.SaveChanges();
        }
        public List<Patient> getPatient()
        {
            return db.Patients.ToList();
        }
        public Doctor getDoctorId(int catid)
        {
            return db.Doctors.Where(x=>(x.cat_id == catid)).FirstOrDefault();
        }
        public List<Room> getRoom()
        {
            return db.Rooms.ToList();
        }
        public Nurse getNurseByNid(int nid)
        {
            return db.Nurses.Where(x => x.nurse_id == nid).FirstOrDefault();
        }
        public void addRoom(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
        }
        public void updateDoctor(Doctor doc)
        {
            Doctor curr_doc = db.Doctors.Where(x=>(x.doc_id == doc.doc_id)).FirstOrDefault();
            Employee curr_emp = db.Employees.Where(x=>(x.emp_id == doc.emp_id)).FirstOrDefault();
            User curr_user = db.Users.Where(x=>(x.user_id == doc.Employee.User.user_id)).FirstOrDefault();

            db.Entry(curr_doc).CurrentValues.SetValues(doc);
            db.Entry(curr_emp).CurrentValues.SetValues(doc.Employee);
            db.Entry(curr_user).CurrentValues.SetValues(doc.Employee.User);

            db.SaveChanges();
        }
        public void remove(Doctor dct)
        {
            User us = db.Users.Where(x=>(x.user_id == dct.Employee.user_id)).FirstOrDefault();
            db.Users.Remove(us);
            db.SaveChanges();
        }
        public void updateNurse(Nurse nur)
        {
            Nurse curr_nur = db.Nurses.Where(x => (x.nurse_id == nur.nurse_id)).FirstOrDefault();
            Employee curr_emp = db.Employees.Where(x => (x.emp_id == nur.emp_id)).FirstOrDefault();
            User curr_user = db.Users.Where(x => (x.user_id == nur.Employee.User.user_id)).FirstOrDefault();

            db.Entry(curr_nur).CurrentValues.SetValues(nur);
            db.Entry(curr_nur).CurrentValues.SetValues(nur.Employee);
            db.Entry(curr_nur).CurrentValues.SetValues(nur.Employee.User);

            db.SaveChanges();
        }
        public void remove(Nurse nrs)
        {
            User use = db.Users.Where(x=>(x.user_id == nrs.Employee.User.user_id)).FirstOrDefault();
            db.Users.Remove(use);
            db.SaveChanges();
        }
        public void updatePatient(Patient pat)
        {
            Patient currPat = db.Patients.Where(x => pat.pat_id == x.pat_id).FirstOrDefault();
            db.Entry(currPat).CurrentValues.SetValues(pat);
            db.SaveChanges();
        }
        public void remove(Patient patnt)
        {
            Patient pat = db.Patients.Where(x => (x.pat_id == patnt.pat_id)).FirstOrDefault();
            db.Patients.Remove(pat);
            db.SaveChanges();
        }
        public void updateRoom(Room rom)
        {
            Room curr_room = db.Rooms.Where(x => x.room_id ==  rom.room_id).FirstOrDefault();
            db.Entry(curr_room).CurrentValues.SetValues(rom);
            db.SaveChanges();
        }
        public void addMedicine(Medicine med)
        {
            db.Medicines.Add(med);
            db.SaveChanges();
        }
        public void addPharmacist(Employee emp)
        {
           db.Employees.Add(emp);
           db.SaveChanges();
        }
        public List<Medicine> getMedicine()
        {
           return db.Medicines.ToList();
        }
        public void updateMedicine(Medicine med)
        {
            Medicine currMed = db.Medicines.Where(x => x.med_id == med.med_id).FirstOrDefault();
            db.Entry(currMed).CurrentValues.SetValues(med);
            db.SaveChanges();
        }
        public void remove(Medicine med)
        {
            Medicine m = db.Medicines.Where(x => x.med_id == med.med_id).FirstOrDefault();
            db.Medicines.Remove(m);
            db.SaveChanges();
        }
        public Doctor getDoctorByUid(int uid)
        {
            return db.Doctors.Where(x => x.emp_id == (db.Employees.Where(y => y.user_id == uid).FirstOrDefault().emp_id)).FirstOrDefault();
        }
        public List<Patient> getMyPatients(Doctor d)
        {
            return db.Patients.Where(x => (x.cat_id == d.cat_id && x.pat_type.Equals("In process"))).ToList();
        }
        public List<IndoorPatient> getMyOldPatients(Doctor d)
        {
            return db.IndoorPatients.Where(x => (x.Patient.doc_id == d.doc_id)).ToList();
        }
        public List<Prescription> getMyPrescriptions(Doctor d)
        {
            return db.Prescriptions.Where(x => x.doc_id == d.doc_id).ToList();
        }
        public void addPrescription(Prescription p)
        {
            db.Prescriptions.Add(p);
            db.SaveChanges();
        }
        public void updateIndoor(IndoorPatient indip)
        {
            IndoorPatient currIndoor = db.IndoorPatients.Where(x => x.indpat_id == indip.indpat_id ).FirstOrDefault();
            db.Entry(currIndoor).CurrentValues.SetValues(indip);
            db.SaveChanges();
        }
        public void addIndoor(IndoorPatient patIndoor)
        {
            db.IndoorPatients.Add(patIndoor);
            db.SaveChanges();
        }
        public void updatePrescription(Prescription modified)
        {
            Prescription currPres = db.Prescriptions.Where(x => x.presc_id == modified.presc_id).FirstOrDefault();
            db.Entry(currPres).CurrentValues.SetValues(modified);
            db.SaveChanges();
        }
        public IndoorPatient getIndoorByPid(int pid)
        {
            return db.IndoorPatients.Where(x => x.pat_id == pid).FirstOrDefault();
        }
        public void remove(IndoorPatient indo)
        {
            IndoorPatient ip = db.IndoorPatients.Where(x => x.indpat_id == indo.indpat_id).FirstOrDefault();
            db.IndoorPatients.Remove(ip);
            db.SaveChanges();
        }
        public Nurse getNurseByUid(int uid)
        {
            return (from n in db.Nurses
                    from emp in db.Employees
                    where emp.user_id == uid && emp.emp_id == n.emp_id
                    select n
                    ).FirstOrDefault(first => first != null);
        }
        public List<IndoorPatient> getMyPatient(Nurse n)
        {
            List<IndoorPatient> patients = db.IndoorPatients.ToList();
            List<IndoorPatient> indoors = new List<IndoorPatient>();

            foreach (IndoorPatient indo in patients)
            {
                if (indo.Room != null && indo.Room.nurse_id == n.nurse_id)
                    indoors.Add(indo);
            }

            return indoors;
        }
        public List<Room> getMyRooms(Nurse n)
        {
            return db.Rooms.Where(x => x.nurse_id == n.nurse_id).ToList();
        }
        public List<Room> getRoom(Room indo)
        {
            return db.Rooms.Where(x=>(x.room_id == indo.room_id)).ToList();
        }
        public List<IndoorPatient> getIndoorPatient(IndoorPatient indop)
        {
            return db.IndoorPatients.Where(x=>(x.Patient.pat_gender == indop.Patient.pat_gender)).ToList();
        }
    }
}
