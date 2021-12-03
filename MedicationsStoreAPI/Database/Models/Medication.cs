using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicinesStoreAPI.Database.Models
{
    public class Medication
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}