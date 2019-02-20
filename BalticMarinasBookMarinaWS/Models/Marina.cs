namespace BalticMarinasBookMarinaWS.Models
{
    public class Marina
    {
        public int MarinaId { get; set; }
        public string MarinaName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Depth { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string ZipCodeNumber { get; set; }
        public int TotalBerths { get; set; }
        public int IsToilet { get; set; }
        public int IsShower { get; set; }
        public int IsInternet { get; set; }
        public int IsPharmacy { get; set; }
        public int IsElectricity { get; set; }
        public int IsRepairing { get; set; }
        public int IsStore { get; set; }
        public int IsTelephone { get; set; }
        public int IsHotel { get; set; }
        public int IsCafeteria { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
    }
}
