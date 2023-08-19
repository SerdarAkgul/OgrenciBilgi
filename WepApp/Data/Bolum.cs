namespace WepApp.Data
{
    public class Bolum : EntityBase<int>
    {
        public string Adi { get; set; }

        public virtual List<Ogrenci> Ogrenciler { get; set; }
    }
}
