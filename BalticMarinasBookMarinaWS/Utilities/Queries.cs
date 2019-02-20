namespace BalticMarinasBookMarinaWS.Utilities
{
    public static class Queries
    {
        #region Marina queries

        public const string CreateMarina = "CALL create_marina(@marinaName, @phone, @email, @depth, @cityName, @country, @zipCodeNumber, @totalBerths, @isToilet, @isShower, @isInternet, @isPharmacy, @isElectricity, @isRepairing, @isStore, @isTelephone, @isHotel, @isCafeteria, @description, @latitude, @longtitude);";

        public const string GetAllMarinas = "SELECT marina.MarinaId, marina.MarinaName, marina.Phone, marina.Email, marina.Depth, city.CityName, city.Country, zipcode.ZipCodeNumber, marina.TotalBerths, marina.IsToilet, marina.IsShower, marina.IsInternet, marina.IsPharmacy, marina.IsElectricity, marina.IsRepairing, marina.IsStore, marina.IsTelephone, marina.IsHotel, marina.IsCafeteria, marina.Description, marina.Latitude, marina.Longtitude\n" +
                    "FROM marina\n" +
                    "JOIN cityzipcode ON marina.CityZipCodeId=cityzipcode.CityZipCodeId\n" +
                    "JOIN city ON city.CityName=cityzipcode.City\n" +
                    "JOIN zipcode ON zipcode.ZipCodeId=cityzipcode.ZipCodeId;";

        public const string GetMarinaById = "SELECT marina.MarinaId, marina.MarinaName, marina.Phone, marina.Email, marina.Depth, city.CityName, city.Country, zipcode.ZipCodeNumber, marina.TotalBerths, marina.IsToilet, marina.IsShower, marina.IsInternet, marina.IsPharmacy, marina.IsElectricity, marina.IsRepairing, marina.IsStore, marina.IsTelephone, marina.IsHotel, marina.IsCafeteria, marina.Description, marina.Latitude, marina.Longtitude\n" +
                    "FROM marina\n" +
                    "JOIN cityzipcode ON marina.CityZipCodeId=cityzipcode.CityZipCodeId\n" +
                    "JOIN city ON city.CityName=cityzipcode.City\n" +
                    "JOIN zipcode ON zipcode.ZipCodeId=cityzipcode.ZipCodeId\n" +
                    "WHERE MarinaId = @id";

        public const string GetAllMarinasByCountry = "SELECT marina.MarinaId, marina.MarinaName, marina.Phone, marina.Email, marina.Depth, city.CityName, city.Country, zipcode.ZipCodeNumber, marina.TotalBerths, marina.IsToilet, marina.IsShower, marina.IsInternet, marina.IsPharmacy, marina.IsElectricity, marina.IsRepairing, marina.IsStore, marina.IsTelephone, marina.IsHotel, marina.IsCafeteria, marina.Description, marina.Latitude, marina.Longtitude\n" +
                    "FROM marina\n" +
                    "JOIN cityzipcode ON marina.CityZipCodeId=cityzipcode.CityZipCodeId\n" +
                    "JOIN city ON city.CityName=cityzipcode.City\n" +
                    "JOIN zipcode ON zipcode.ZipCodeId=cityzipcode.ZipCodeId\n" +
                    "WHERE city.Country = @country";

        public const string GetAllMarinasNames = "SELECT marina.MarinaName FROM marina;";

        public const string GetMarinaIdByMarinaName = "SELECT marina.MarinaId FROM marina WHERE MarinaName = @marinaName;";

        public const string DeleteMarina = "DELETE FROM marina WHERE MarinaId = @marinaId;";

        #endregion

        #region Berth queries

        public const string CreateBerth = "INSERT INTO berth (MarinaId, Price)\n" +
                    "VALUES (@marinaId, @price);";

        public const string GetAllBerths = "SELECT * FROM berth";

        public const string GetAllBerthsByMarinaId = "SELECT * FROM berth WHERE MarinaId = @id";

        public const string GetBerthByIdAndMarinaId = "SELECT * FROM berth WHERE MarinaId = @marinaId AND BerthId = @berthId";

        public const string GetReservedBerthsByMarinaIdAndDates = "SELECT berth.BerthId, berth.MarinaId, berth.Price\n" +
                    "FROM berth\n" +
                    "JOIN marina ON berth.MarinaId=marina.MarinaId\n" +
                    "JOIN cityzipcode ON marina.CityZipCodeId=cityzipcode.CityZipCodeId\n" +
                    "JOIN city ON city.CityName=cityzipcode.City\n" +
                    "JOIN zipcode ON zipcode.ZipCodeId=cityzipcode.ZipCodeId\n" +
                    "JOIN reservation ON berth.BerthId=reservation.BerthId\n" +
                    "WHERE (berth.MarinaId = @marinaId AND berth.BerthId = reservation.BerthId\n" +
                    "AND @checkIn BETWEEN reservation.CheckIn AND reservation.CheckOut\n" +
                    "OR @checkOut BETWEEN reservation.CheckIn AND reservation.CheckOut\n" +
                    "OR @checkIn < reservation.CheckIn AND @checkOut > reservation.CheckOut)";

        public const string DeleteBerth = "DELETE FROM berth WHERE BerthId = @berthId;";

        #endregion

        #region Reservation queries

        public const string GetIfReservationExists = "SELECT COUNT(*) FROM reservation WHERE ReservationId = @reservationId;";

        public const string GetAllReservationsByCustomerId = "SELECT * FROM reservation WHERE CustomerId = @customerId";

        public const string GetReservationId = "SELECT ReservationId FROM reservation\n" +
                    "WHERE BerthId = @berthId\n" +
                    "AND CustomerId = @customerId\n" +
                    "AND CheckIn = @checkIn\n" +
                    "AND CheckOut = @checkOut;";

        public const string CreateReservation = "INSERT INTO reservation (BerthId, CustomerId, CheckIn, CheckOut, IsPaid)\n" +
                    "VALUES (@berthId, @customerId, @checkIn, @checkOut, 0);";

        public const string UpdateReservation = "UPDATE reservation SET IsPaid = 1 WHERE ReservationId = @reservationId";

        public const string DeleteNotPaidReservation = "CALL delete_reservation(@reservationId);";

        #endregion

        #region Comment queries

        public const string GetAllCommentsByMarinaId = "SELECT * FROM comment WHERE MarinaId = @marinaId";

        public const string CreateComment = "INSERT INTO comment (TimePlaced, Body, UserName, MarinaId)\n" +
                    "VALUES (@timePlaced, @body, @userName, @marinaId);";

        #endregion
    }
}
