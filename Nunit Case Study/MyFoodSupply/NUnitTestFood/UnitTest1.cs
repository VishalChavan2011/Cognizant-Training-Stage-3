using MyFoodSupply;
using NUnit.Framework;
using System;
using static MyFoodSupply.FoodDetail;

namespace NUnitTestFood
{
    [TestFixture]
    public class Tests
    {
        Program program;
        FoodDetail fd;

        [SetUp]
        public void Setup()
        {
            program = new Program();
            fd = program.CreateFoodDetail("PaneerTikka", 1, DateTime.Parse("2021/12/2"), 50);
        }



        //FoodName Can't be Null
        [Test]
        [TestCase("", 2, "2022/02/12", 50, "Dish name cannot be empty. Please provide valid value")]

        public void FoodDetails_FoodNameCheck_ThrowException(string name, int dishtype, string expirydate, double price, string expected)
        {
            DateTime temp = DateTime.Parse(expirydate);
            var result = Assert.Throws<Exception>(() => program.CreateFoodDetail(name, dishtype, temp, price));


            Assert.AreEqual(result.Message, expected);

        }

        //Expiry Date Less Than Current Date
        [Test]
        [TestCase("IceCream", 3, "2020/12/02", 40, "Incorrect expiry date. Please provide valid value")]

        public void FoodDetails_ExpiryDateCheck_ThrowExpection(string name, int dishtype, string expirydate, double price, string expectedresult)
        {
            DateTime temp = DateTime.Parse(expirydate);
            var result = Assert.Throws<Exception>(() => program.CreateFoodDetail(name, dishtype, temp, price));

            Assert.AreEqual(result.Message, expectedresult);
        }


        // //Price Less Than Zero
        [Test]
        [TestCase("SandWich", 2, "2021/04/05", -15, "Incorrect value for dish price. Please provide valid value")]

        public void FoodDetails_PriceZeroOrLessThanZero_ThrowExpection(string name, int dishtype, string expirydate, double price, string expectedresult)
        {
            DateTime temp = DateTime.Parse(expirydate);
            var result = Assert.Throws<Exception>(() => program.CreateFoodDetail(name, dishtype, temp, price));

            Assert.AreEqual(result.Message, expectedresult);
        }

        // //Object Create SuccessFully
        [Test]

        [TestCase("PaneerTikka", 1, "2021/12/2", 50)]
        public void FoodDetails_CreatedObject_CreatedSuccessFully(string name, int dishtype, string expirydate, double price)
        {
            var food = program.CreateFoodDetail(name, dishtype, DateTime.Parse(expirydate), price);


            Assert.AreEqual(food.Name, fd.Name);

            Assert.AreEqual(food.DishType, fd.DishType);
            Assert.AreEqual(food.ExpiryDate, fd.ExpiryDate);
            Assert.AreEqual(food.Price, fd.Price);
        }






        ////Requested Date Greater Than Expired Date

        [Test]
        [TestCase(2, "2022/03/02", "Ajay", 30, "Request date greater than expiry date. Please check")]
        public void SupplyDetails_RequestDateAndExpiryDateCheck_ThrowException(int foodItemCount, string requestdate, string sellerName, double packingCharge, string expectedresult)
        {
            DateTime datetime = DateTime.Parse(requestdate);
            var result = Assert.Throws<Exception>(() => program.CreateSupplyDetail(foodItemCount, datetime, sellerName, packingCharge, fd));
            Assert.AreEqual(result.Message, expectedresult);
        }

        // //Requested Date Less Than Today

        [Test]
        [TestCase(2, "2021/03/02", "Ajay", 30, "Incorrect food request date. Please provide valid value")]
        public void SupplyDetails_RequestDateCheck_ThrowException(int foodItemCount, string requestdate, string sellerName, double packingCharge, string expectedresult)
        {
            DateTime datetime = DateTime.Parse(requestdate);
            var result = Assert.Throws<Exception>(() => program.CreateSupplyDetail(foodItemCount, datetime, sellerName, packingCharge, fd));
            Assert.AreEqual(result.Message, expectedresult);
        }






        // Food Count zero or less than zero

        [Test]
        [TestCase(0, "2021/03/20", "Rahul", 10, "Incorrect food item count. Please check")]
        public void SupplyDetails_FoodCountCheck_ThrowExpection(int foodItemCount, string requestdate, string sellerName, double packingCharge, string expectedresult)
        {
            DateTime datetime = DateTime.Parse(requestdate);
            var result = Assert.Throws<Exception>(() => program.CreateSupplyDetail(foodItemCount, datetime, sellerName, packingCharge, fd));
            Assert.AreEqual(result.Message, expectedresult);
        }




        //Object Creation
        [Test]
        [TestCase(3, "2021/03/22", "Nikhil", 10)]


        public void SupplyDetails_CreateObject_CreatedSuccessFully(int foodItemCount, string requestdate, string sellerName, double packingCharge)
        {

            DateTime datetime = DateTime.Parse(requestdate);
            var supplydetails = program.CreateSupplyDetail( foodItemCount, datetime, sellerName, packingCharge, fd);
            Assert.AreEqual(supplydetails.SellerName, sellerName);
            Assert.AreEqual(supplydetails.Count, foodItemCount);
            Assert.AreEqual(supplydetails.SellerName, sellerName);
                

        }

        




    }
}