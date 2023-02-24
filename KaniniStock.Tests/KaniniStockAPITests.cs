using KaniniStock.API.Controllers;
using KaniniStock.Domain.IRepoInterfaces;
using KaniniStock.Domain.Models.SourceModels;
using Moq;

namespace KaniniStock.Tests
{
    [TestClass]
    public class KaniniStockAPITests
    {
        private  Mock<IKCompany> kcompanyservicemock;
        private  KCompanyController companyController;

        [TestInitialize]
        public void TestInitialize()
        {
            //Initialize Mock 
            this.kcompanyservicemock = new Mock<IKCompany>();

            //Setuo Data
            this.SetupMockData();

            //Initialize subject to Test

            this.companyController = new KCompanyController(this.kcompanyservicemock.Object);

        }

        [TestMethod]
        public void ConstructorTest()
        {
            var controller = new KCompanyController(this.kcompanyservicemock.Object);
            Assert.IsNotNull(controller);

        }

        [TestMethod]
        public async Task GetCompanyDetailsReturns200()
        {
            //Arrange
            var expected = GetCompDetails();
            var companyname = "HDFC";

            //ct
            var response = await this.companyController.GetCompanyDetails(companyname);

            //Assert

            this.kcompanyservicemock.Verify(x => x.GetCompanyDetail(companyname), Times.Once());
         
        }

        private void SetupMockData()
        {
            this.kcompanyservicemock.Setup(x => x.GetCompanyDetail(It.IsAny<string>())).Returns(GetCompDetails);
            this.kcompanyservicemock.Setup(x => x.GetCompaniess(It.IsAny<string>())).Returns(getcompanieslist);
        }

        private KcompanyDetail GetCompDetails()
        {
            return new KcompanyDetail
            {
                Companycode = "CANB",
                Closingshareprice = 100,
                Currenttradingprice = 200,
                Todayshigh = 250,
                TodayslOw = 100,
                _52whigh = 360,
                _52wlow = 70,
                Marketcapitalization = 10000,
                Enterpricevalue = 200000,
                Numberofshares = "1111",
                Dividentyield = 10,
                Cash = 18888888,
                Strength = "Customers",
                Weakness = "market",
                Opportunities = "IT",
                Threats = "COmpetitors",
                Debt = 2000,
                Facevalue = 10,
                Promoterholding = 50000

            };
        }

        private static List<KcompanyPicker> getcompanieslist()
        {
            return new List<KcompanyPicker>
                {
                    new KcompanyPicker
                    {
                        CompanyName="M&M",
                        CompanyCode="1001",
                        ViewCount=5000

                    }

                };
        }
    }
}

