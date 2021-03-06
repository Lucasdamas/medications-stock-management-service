using System;
using System.Collections.Generic;
using System.Linq;
using MedicationsStoreAPI.Database.Context;
using MedicationsStoreAPI.Database.Models;
using MedicationsStoreAPI.Database.Repositories.Interface;

namespace MedicationsStoreAPI.Database.Repositories.Implementations
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly EventDbContext _eventDbContext;

        public MedicationRepository(EventDbContext eventDbContext)
        {
            _eventDbContext = eventDbContext;
        }

        public void InsertMedication(Medication medicationDbo)
        {
            try
            {
                _eventDbContext.MedicationsStore.Add(medicationDbo);
                _eventDbContext.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("insert-event-error");
                throw;
            }
        }

        public List<Medication> GetMedicationsList()
        {
            try
            {
                var MedicationsList = _eventDbContext.MedicationsStore.ToList();
                return MedicationsList;
            }
            catch (Exception)
            {
                Console.WriteLine("get-event-error");
                throw;
            }
        }

        public void DeleteMedication(string name)
        {
            try
            {
                var listEvents = _eventDbContext.MedicationsStore.Where(x => x.Name == name).ToList();
                _eventDbContext.MedicationsStore.RemoveRange(listEvents);
                _eventDbContext.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("delete-event-error");
                throw;
            }
        }
    }
}