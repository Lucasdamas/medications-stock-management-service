using System.Collections.Generic;
using MedicationsStoreAPI.Database.Models;

namespace MedicationsStoreAPI.Database.Repositories.Interface
{
    public interface IMedicationRepository
    {
        void InsertMedication(Medication medicineDbo);
        List<Medication> GetMedicationsList();
        void DeleteMedication(string name);
    }
}