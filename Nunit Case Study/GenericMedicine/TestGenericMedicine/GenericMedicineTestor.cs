using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericMedicine;
using NUnit.Framework;

namespace TestGenericMedicine
{
    [TestFixture]
    public class GenericMedicineTestor
    {
        Program program;
        Medicine medicine;
        [SetUp]
        public void Setup()
        {
            program = new Program();
             medicine = new Medicine()
            {
                Name = "Cetirizine",
                GenericMedicineName = "Cetirizine 10mg",
                Composition = "cetirizine hydrochloride",
                ExpiryDate = DateTime.Parse("02-02-2030"),
                PricePerStrip = 50
            };
    }



        //ExpireDate Less Than Date Today

        [Test]
        [TestCase("Cetirizine", "Cetirizine 10mg", "cetirizine hydrochloride", "2/2/2021", 50, "Incorrect expiry date. Please provide valid value")]
        public void MedicineCheck_ExpiryDateCheck_ThrowException(string name, string genericMedicineName, string composition, string expirydate, double pricePerStrip, string expectedresult)
        {
            DateTime datetime = DateTime.Parse(expirydate);
            var result = Assert.Throws<Exception>(() => program.CreateMedicineDetail(name, genericMedicineName, composition, datetime, pricePerStrip));

            Assert.AreEqual(result.Message, expectedresult);

        }


        // //Price Less than 0
        [Test]

        [TestCase("Cetirizine", "Cetirizine 10mg", "cetirizine hydrochloride", "02/02/2030", 0, "Incorrect value for Medicine price per strip. Please provide valid value")]
        public void MedicineCheck_PriceLessThanZero_ThrowException(string name, string genericMedicineName, string composition, string expirydate, double pricePerStrip, string expectedresult)
        {
                DateTime datetime = DateTime.Parse(expirydate);
            var result = Assert.Throws<Exception>(() => program.CreateMedicineDetail(name, genericMedicineName, composition, datetime, pricePerStrip));

            Assert.AreEqual(result.Message, expectedresult);

        }


         //medicine composition cannot be empty
         [Test]
         [TestCase("cetirizine", "cetirizine 10mg", "", "02/02/2030", 20, "Medicine composition cannot be empty. Please provide valid value")]
         public void medicinecheck_nullcompositionname_throwexception(string name, string genericmedicinename, string composition, string expirydate, double priceperstrip, string expectedresult)
         {
              DateTime datetime = DateTime.Parse(expirydate);
        var result = Assert.Throws<Exception>(() => program.CreateMedicineDetail(name, genericmedicinename, composition, datetime, priceperstrip));

        Assert.AreEqual(result.Message, expectedresult);

         }


        // //Generic Name can't be null
        [Test]
        [TestCase("Cetirizine", "", "cetirizine hydrochloride", "02/02/2030", 20, "Generic Medicine name cannot be empty. Please provide valid value")]
         public void MedicineCheck_NullGenericName_ThrowException(string name, string genericMedicineName, string composition, string expirydate, double pricePerStrip, string expectedresult)
         {
            DateTime datetime = DateTime.Parse(expirydate);
            var result = Assert.Throws<Exception>(() => program.CreateMedicineDetail(name, genericMedicineName, composition, datetime, pricePerStrip));

            Assert.AreEqual(result.Message, expectedresult);

        }


        //Medicine Name shouldn't be Null
        [Test]
        [TestCase(null, "Cetirizine 10mg", "cetirizine hydrochloride", "02/02/2030", 20, "Medicine name cannot be empty. Please provide valid value")]
        public void MedicineCheck_NullName_ThrowException(string name, string genericMedicineName, string composition, string expirydate, double pricePerStrip, string expectedresult)
        {
            DateTime datetime = DateTime.Parse(expirydate);
            var result = Assert.Throws<Exception>(() => program.CreateMedicineDetail(name, genericMedicineName, composition, datetime, pricePerStrip));

            Assert.AreEqual(result.Message, expectedresult);

        }

        [Test]
        [TestCase("Cetirizine", "Cetirizine 10mg", "cetirizine hydrochloride", "02/02/2030", 50)]
        public void Medicine_CreateObject_CreatedSucessfully(string name, string genericMedicineName, string composition, string expirydate, double pricePerStrip)
        {
            DateTime datetime = DateTime.Parse(expirydate);
            var result = program.CreateMedicineDetail(name, genericMedicineName, composition, datetime, pricePerStrip);
            Assert.AreEqual(result.Name, medicine.Name);
            Assert.AreEqual(result.GenericMedicineName, medicine.GenericMedicineName);
            Assert.AreEqual(result.Composition, medicine.Composition);
            Assert.AreEqual(result.ExpiryDate, medicine.ExpiryDate);
            Assert.AreEqual(result.PricePerStrip, medicine.PricePerStrip);

        }





        // //Incorrect Retail Address

        [Test]
        [TestCase(5, "02/02/2022", "", "Incorrect retailer address. Please check")]
        public void Carton_IncorrectRetailAddress_CreatedSucessfully(int medicineStripCount, string launchDate, string retailerAddress, string expectedresult)
        {
            DateTime datetime = DateTime.Parse(launchDate);
            
            var result = Assert.Throws<Exception>(()=>program.CreateCartonDetail(medicineStripCount, datetime, retailerAddress, medicine));
            
            Assert.AreEqual(result.Message, expectedresult);
        }


    // //Launch Date Greater Than Expiry Date

     [Test]
     [TestCase(10, "02/02/2021", "Mumbai", "Launch date greater than expiry date. Please check")]
     public void Carton_LaunchDateGreaterThanExpiry_CreatedSucessfully(int medicineStripCount, string launchDate, string retailerAddress, string expectedresult)
     {
        DateTime datetime = DateTime.Parse(launchDate);
            var result = Assert.Throws<Exception>(() => program.CreateCartonDetail(medicineStripCount, datetime, retailerAddress, medicine));

            Assert.AreEqual(result.Message, expectedresult);

        }


    // //Launch Date Less Than Today

     [Test]
     [TestCase(10, "02/02/2021", "Mumbai", "Incorrect launch date. Please provide valid value")]
     public void Carton_LaunchDateCheck_CreatedSucessfully(int medicineStripCount, string launchDate, string retailerAddress, string expectedresult)
    {
            DateTime datetime = DateTime.Parse(launchDate);
            var result = Assert.Throws<Exception>(() => program.CreateCartonDetail(medicineStripCount, datetime, retailerAddress, medicine));

            Assert.AreEqual(result.Message, expectedresult);

        }


        // //Incorrect Strip Count

        [Test]
         [TestCase(0, "02/02/2022", "Mumbai", "Incorrect strip count. Please check")]
         public void Carton_StripCountLessThanZero_CreatedSucessfully(int medicineStripCount, string launchDate, string retailerAddress, string expectedresult)
         {

        DateTime datetime = DateTime.Parse(launchDate);
        var result = Assert.Throws<Exception>(() => program.CreateCartonDetail(medicineStripCount, datetime, retailerAddress, medicine));

        Assert.AreEqual(result.Message, expectedresult);
     }

        //Create Object 

        [Test]
        [TestCase(5, "02/02/2022", "Mumbai")]
        public void Carton_ObjectCheck_CreatedSucessfully(int medicineStripCount, string launchDate, string retailerAddress)
        {
            DateTime datetime = DateTime.Parse(launchDate);
            var result = program.CreateCartonDetail(medicineStripCount, datetime, retailerAddress, medicine);
            Assert.AreEqual(result.MedicineStripCount, medicineStripCount);
            Assert.AreEqual(result.LaunchDate, datetime);
            Assert.AreEqual(result.RetailerAddress, retailerAddress);
        }

    }
}
