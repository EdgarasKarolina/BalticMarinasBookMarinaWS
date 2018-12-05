using BalticMarinasBookMarinaWS.Models;
using BalticMarinasBookMarinaWS.Utilities;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookMarina.Tests
{
    public class MethodsTests
    {
        [Test]
        public void GetFreeBerths_BerthsAmountEqualsTwo()
        {
            Berth berth1 = new Berth() { BerthId = 1, MarinaId = 1, Price = 300 };
            Berth berth2 = new Berth() { BerthId = 2, MarinaId = 1, Price = 600 };
            Berth berth3 = new Berth() { BerthId = 3, MarinaId = 1, Price = 500 };
            Berth berth4 = new Berth() { BerthId = 4, MarinaId = 1, Price = 200 };

            List<Berth> listOfBerths = new List<Berth>();
            listOfBerths.Add(berth1);
            listOfBerths.Add(berth2);
            listOfBerths.Add(berth3);
            listOfBerths.Add(berth4);

            HashSet<int> reservedBerthsIds = new HashSet<int>();
            reservedBerthsIds.Add(1);
            reservedBerthsIds.Add(2);

            Assert.AreEqual(3, Methods.getFreeBerths(listOfBerths, reservedBerthsIds).Count , "Amount of berths should be equal to 2");
        }
    }
}
