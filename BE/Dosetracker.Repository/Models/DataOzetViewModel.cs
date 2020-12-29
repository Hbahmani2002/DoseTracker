using System;
using System.Collections.Generic;
using System.Text;

namespace Dosetracker.Repository.Models
{
    public class DataOzetViewModel
    {
        public string[] HastaneList { get; set; }
        public long OperatorSayisi { get; set; }
        public string EnYuksekSar { get; set; }
        public string EnDusukSar { get; set; }
        public long ToplamData { get; set; }
    }
}
