using System;
using System.Collections.Generic;

#nullable disable

namespace Dosetracker.Persistance.Domain.Models
{
    public partial class Dosetracker
    {
        public int Id { get; set; }
        public DateTime Studydate { get; set; }
        public double? Studysar { get; set; }
        public string Studysequence { get; set; }
        public int? Patientage { get; set; }
        public byte? Patientsex { get; set; }
        public int? Patientweight { get; set; }
        public double? Patientsize { get; set; }
        public string Hospitalid { get; set; }
        public double? Vucutkitleendeksi { get; set; }
        public string Operator { get; set; }
    }
}
