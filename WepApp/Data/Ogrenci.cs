using Microsoft.Build.Framework;

namespace WepApp.Data
{

    public class Ogrenci : EntityBase<int>
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }

        public int BolumId { get; set; }
        public virtual Bolum? Bolum { get; set; }
    }
}
