using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOgrenciBilgiSistemi.models
{
    public class Sinif
    {
        public int SinifId { get; set; }
        public string SinifAd { get; set; }
        public byte Kontenjan { get; set; }
 
        public ICollection<Ogrenci> Ogrenciler { get; set; }


        public override string ToString()
        {
            return SinifAd;
        }
    }
}
