using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    public class HMSFACTORY
    {
        HMSDATALAYER hmsda;
        public HMSFACTORY()
        {
            hmsda = new HMSDATALAYER();
        }
        public User getUser(String user , String pass)
        {
            return hmsda.getUser(user , pass);
        }
        public User getUser(String user)
        {
            return hmsda.getUser(user);
        }
        public Doctor addDoctor(Doctor doc)
        {
            return hmsda.addDoctor(doc);
        }
        public List<Doctor> getDoctor()
        {
            return hmsda.getDoctor();
        }
        public void addNurse(Nurse nurse)
        {
            hmsda.addNurse(nurse);
        }
        public List<Nurse>getNurse()
        {
            return hmsda.getNurse();
        }
        public List<Category> getCategories()
        {
            return hmsda.getCategories();
        }
        public void addPatient(Patient pat)
        {
            hmsda.addpatient(pat);
        }
        public List<Patient> getPatient()
        {
            return hmsda.getPatient();
        }
        public Doctor getDoctorId(int catid)
        {
            return hmsda.getDoctorId(catid);
        }
        public List<Room> getRoom()
        {
            return hmsda.getRoom();
        }
        public Nurse getNurseByNid(int nid)
        {
            return hmsda.getNurseByNid(nid);
        }
        public void addRoom(Room room)
        {
            hmsda.addRoom(room);
        }
        public void updateDoctor(Doctor doc)
        {
            hmsda.updateDoctor(doc);
        }
        public void remove(Doctor dct)
        {
            hmsda.remove(dct);
        }
        public void updateNurse(Nurse nurs)
        {
            hmsda.updateNurse(nurs);
        }
        public void remove(Nurse nrs)
        {
            hmsda.remove(nrs);
        }
        public void updatePatient(Patient pat)
        {
            hmsda.updatePatient(pat);
        }
        public void remove(Patient patnt)
        {
            hmsda.remove(patnt);
        }
        public void updateRoom(Room rom)
        {
            hmsda.updateRoom(rom);
        }
        public void addMedicine(Medicine med)
        {
            hmsda.addMedicine(med);
        }
        public void addPharmacist(Employee emp)
        {
            hmsda.addPharmacist(emp);
        }
        public List<Medicine> getMedicine()
        {
            return hmsda.getMedicine();
        }
        public void updateMedicine(Medicine med)
        {
            hmsda.updateMedicine(med);
        }
        public void remove(Medicine med)
        {
            hmsda.remove(med);
        }
        public Doctor getDoctorByUid(int uid)
        {
            return hmsda.getDoctorByUid(uid);
        }
        public List<Patient> getMyPatients(Doctor d)
        {
            return hmsda.getMyPatients(d);
        }
        public List<IndoorPatient> getMyOldPatients(Doctor d)
        {
            return hmsda.getMyOldPatients(d);
        }
        public List<Prescription> getMyPrescriptions(Doctor d)
        {
            return hmsda.getMyPrescriptions(d);
        }
        public void addPrescription(Prescription p)
        {
            hmsda.addPrescription(p);
        }
        public void updateIndoor(IndoorPatient indip)
        {
            hmsda.updateIndoor(indip);
        }
        public void addIndoor(IndoorPatient patIndoor)
        {
            hmsda.addIndoor(patIndoor);
        }
        public void updatePrescription(Prescription modified)
        {
            hmsda.updatePrescription(modified);
        }
        public IndoorPatient getIndoorByPid(int pid)
        {
            return hmsda.getIndoorByPid(pid);
        }
        public void remove(IndoorPatient indo)
        {
            hmsda.remove(indo);
        }
        public Nurse getNurseByUid(int uid)
        {
           return hmsda.getNurseByUid(uid);
        }
        public List<IndoorPatient> getMyPatient(Nurse n)
        {
            return hmsda.getMyPatient(n);
        }
        public List<Room> getMyRooms(Nurse n)
        {
            return hmsda.getMyRooms(n);
        }
        public List<Room> getRoom(Room indo)
        {
            return hmsda.getRoom(indo);
        }
        public List<IndoorPatient> getIndoorPatient(IndoorPatient indop)
        {
            return hmsda.getIndoorPatient(indop);
        }
    }
}
