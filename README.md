# ATMTest
Technical Test Solution for ATM API. The solution uses a project reference called ATMAPI, which contains the following services:

- IBalanceEnquiryService.cs
- ICashWithdrawalService.cs
- IPinValidationService.cs

There is a controller added by the name: ATMController.cs which contains the template methods defined for HttpGet, HttpPut and HttpPost operations.

BDD scenarios have been defined within ATMTest project. Mocks have been defined within ATM.cs class, which call the methods defined within the respective Services.

The test data provided in the problem statement is referenced in the form of Cucumber data tables.

A Specflow runner class has been added to run the tests. However, this needs to be expanded further to generate HTML reports.


