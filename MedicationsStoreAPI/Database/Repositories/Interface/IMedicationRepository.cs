using System.Collections.Generic;
using MedicinesStoreAPI.Database.Models;

namespace MedicinesStoreAPI.Database.Repositories.Interface
{
    public interface IMedicationRepository
    {
        void InsertMedication(Medication medicineDbo);
        List<Medication> GetMedicationsList();
        void DeleteMedication(string name);
    }
}