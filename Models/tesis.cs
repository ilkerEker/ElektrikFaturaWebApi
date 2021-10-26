using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElektrikFaturaWebApi.Models
{
    public class tesis
    {
        public long tesisid { get; set; }
        public string tesisad { get; set; }
        public long aboneno { get; set; }
        public long tesisatno { get; set; }
        public long sozlesmehesapno { get; set; }
        public long sayacno { get; set; }
        public long carpan { get; set; }
        public string aboneliktipi { get; set; }
        public string isletmekodu { get; set; }
        public float kuruluguc { get; set; }
        public string tesisturu { get; set; }


    }
}
