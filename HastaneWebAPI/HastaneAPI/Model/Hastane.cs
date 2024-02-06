namespace HastaneAPI.Model
{
    public class Hastane : BaseEntity
    {
        public string HastaneAdi { get; set; }
        public string Adres { get; set; }
        public List<Hasta> Hastalar { get; set; }

    }
}
