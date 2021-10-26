using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElektrikFaturaWebApi.Models
{
    public class fatura
    {
        public long faturaid { get; set; }
        public DateTime sonodemetarihi { get; set; }
        public int donem { get; set; }
        public DateTime ilkokumatarihi { get; set; }
        public DateTime sonokumatarihi { get; set; }
        public string tesisid { get; set; }
        public double tekzamanlituketim { get; set; }
        public double t1zamanlituketim { get; set; }
        public double t2zamanlituketim { get; set; }
        public double t3zamanlituketim { get; set; }
        public double toplamtuketim { get; set; }
        public double faturabedeli { get; set; }
        public long faturano { get; set; }
        public float birimfiyat { get; set; }
        public int ilkendeks { get; set; }
        public int sonendeks { get; set; }


    }
}
