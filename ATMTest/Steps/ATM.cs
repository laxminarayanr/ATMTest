using TechTalk.SpecFlow;
using Moq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATMAPI.Services;
using ATMAPI.Controllers;

using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System.Diagnostics;

namespace ATMTest.Steps
{
    [Binding]
    public class ATM
    {
        //TODO: use the ATMController class to call API request and response methods 
        //private ATMController _controller = new ATMController();
        private long _Pin;       
        private double _Balance;
        private double _Amount;
      

        [Given(@"the user with (.*) enters (.*) and selects Balance Enquiry")]
        public void BalanceEnquiry(long AccountNumber, long PinID)
        {
            _Pin = PinID;

            //Arrange
            var pinServiceMock = new Mock<IPinValidationService>();
            var balanceServiceMock = new Mock<IBalanceEnquiryService>();

            //Act
            balanceServiceMock.Object.setAccountNumber(AccountNumber);


            //Assert
            //Assert.IsTrue(_controller.ValidatePin(PinID).Contains("Valid"));

            Assert.IsTrue(pinServiceMock.Object.ValidatePin(PinID));

                 

        }

        [Given(@"the user has entered (.*)")]
        public void GivenTheUserHasEnteredPin(long PinID)
        {
            _Pin = PinID;
        }


        [Then(@"the available Balance is displayed")]
        public void DisplayBalance()
        {
            //create a mock object for the Balance Service present in ATMAPI reference
            //Arrange
            var balanceServiceMock = new Mock<IBalanceEnquiryService>();

            //Act
            Trace.WriteLine(balanceServiceMock.Object.BalanceEnquiry(_Pin));

            //Assert
            Assert.IsFalse(balanceServiceMock.Object.BalanceEnquiry(_Pin).Contains("ERR"));

            
        }

        [Then(@"amount is withdrawn successfully")]
        public void verifyAmountWithdrawal()
        {
            //Arrange
            var CashWithdrawalServiceMock = new Mock<ICashWithdrawalService>();

            //Assert
           //verify if the output of Cash Withdrawal method contains Balance and not an error response code           
           Assert.IsTrue(CashWithdrawalServiceMock.Object.WithdrawAmount(_Pin, _Amount, _Balance).Contains("Balance"));
            
           Logger.LogMessage(CashWithdrawalServiceMock.Object.WithdrawAmount(_Pin, _Amount, _Balance));

                
            
        }

        [When(@"the user withdraws (.*) below (.*) and (.*)")]
        public void WithdrawAmount(double Amount, double Balance, double Overdraft)
        {
            _Amount = Amount;
            _Balance = Balance;

            //Arrange
            var CashWithdrawalServiceMock = new Mock<ICashWithdrawalService>();

            //Act
            //set the overdraft limit based on the data provided in the feature file
            CashWithdrawalServiceMock.Object.setOverDraft(Overdraft);

            //Call the Withdraw Amount using the PIN, Withdrawal amount and the ATM Balance specified
            CashWithdrawalServiceMock.Object.WithdrawAmount(_Pin, Amount, Balance);

        }

    }
}
