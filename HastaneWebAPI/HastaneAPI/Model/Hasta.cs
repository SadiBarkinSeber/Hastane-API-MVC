namespace HastaneAPI.Model
{
    public class Hasta : BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Klinik { get; set; }
        public DateTime MuayeneTarihi { get; set; } = DateTime.Now;
        public int HastaneId { get; set; }
        public Hastane Hastane { get; set; }    
    }
}
