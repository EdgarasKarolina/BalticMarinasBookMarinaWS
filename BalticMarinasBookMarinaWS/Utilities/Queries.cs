namespace BalticMarinasBookMarinaWS.Utilities
{
    public static class Queries
    {
        #region Marina queries

        public const string GetAllMarinas = "Select marina.MarinaId, marina.MarinaName, marina.Phone, marina.Email, marina.Depth, city.CityName, city.Country, zipcode.ZipCodeNumber, marina.TotalBerths, marina.IsToilet, marina.IsShower, marina.IsInternet\n" +
                    "from marina\n" +
                    "JOIN cityzipcode ON marina.CityZipCodeId=cityzipcode.CityZipCodeId\n" +
                    "JOIN city ON city.CityName=cityzipcode.City\n" +
                    "JOIN zipcode ON zipcode.ZipCodeId=cityzipcode.ZipCodeId;";

        public const string GetMarinaById = "Select marina.MarinaId, marina.MarinaName, marina.Phone, marina.Email, marina.Depth, city.CityName, city.Country, zipcode.ZipCodeNumber, marina.TotalBerths, marina.IsToilet, marina.IsShower, marina.IsInternet\n" +
                    "from marina\n" +
                    "JOIN cityzipcode ON marina.CityZipCodeId=cityzipcode.CityZipCodeId\n" +
                    "JOIN city ON city.CityName=cityzipcode.City\n" +
                    "JOIN zipcode ON zipcode.ZipCodeId=cityzipcode.ZipCodeId\n" +
                    "WHERE MarinaId = @id";

        public const string GetAllMarinasByCountry = "Select marina.MarinaId, marina.MarinaName, marina.Phone, marina.Email, marina.Depth, city.CityName, city.Country, zipcode.ZipCodeNumber, marina.TotalBerths, marina.IsToilet, marina.IsShower, marina.IsInternet\n" +
                    "from marina\n" +
                    "JOIN cityzipcode ON marina.CityZipCodeId=cityzipcode.CityZipCodeId\n" +
                    "JOIN city ON city.CityName=cityzipcode.City\n" +
                    "JOIN zipcode ON zipcode.ZipCodeId=cityzipcode.ZipCodeId\n" +
                    "WHERE city.Country = @country";

        #endregion

        #region Berth queries

        public const string GetAllBerths = "select * from berth";

        public const string GetAllBerthsByMarinaId = "select * from berth where MarinaId = @id";

        public const string GetBerthByIdAndMarinaId = "select * from berth where MarinaId = @marinaId and BerthId = @berthId";

        public const string GetReservedBerthsByMarinaIdAndDates = "Select berth.BerthId, berth.MarinaId, berth.Price\n" +
                    "from berth\n" +
                    "JOIN marina ON berth.MarinaId=marina.MarinaId\n" +
                    "JOIN cityzipcode ON marina.CityZipCodeId=cityzipcode.CityZipCodeId\n" +
                    "JOIN city ON city.CityName=cityzipcode.City\n" +
                    "JOIN zipcode ON zipcode.ZipCodeId=cityzipcode.ZipCodeId\n" +
                    "JOIN reservation ON berth.BerthId=reservation.BerthId\n" +
                    "WHERE (berth.MarinaId = @marinaId AND berth.BerthId = reservation.BerthId\n" +
                    "AND @checkIn BETWEEN reservation.CheckIn and reservation.CheckOut\n" +
                    "OR @checkOut BETWEEN reservation.CheckIn and reservation.CheckOut\n" +
                    "OR @checkIn < reservation.CheckIn and @checkOut > reservation.CheckOut)";
        #endregion

        #region Reservation queries

        public const string GetAllReservationsByCustomerId = "select * from reservation where CustomerId = @customerId";

        public const string CreateReservation = "INSERT INTO reservation (BerthId, CustomerId, CheckIn, CheckOut, IsPaid)\n" +
                    "VALUES (@berthId, @customerId, @checkIn, @checkOut, 1);";

        #endregion
    }
}
