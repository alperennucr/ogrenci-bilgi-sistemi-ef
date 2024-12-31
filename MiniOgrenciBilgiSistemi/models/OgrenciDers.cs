using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOgrenciBilgiSistemi.models
{
    public class OgrenciDers
    {
        public int Id { get; set; }
        public int DersId { get; set; }
        public int OgrenciId { get; set; }


        
        public Ogrenci Ogrenci { get; set; }
        public Ders Ders { get; set; }
        
    }
}
