# ATMTest
Technical Test Solution for testing ATM functionalities. 

The solution uses a project reference called ATM-API, which contains the following services:

- IBalanceEnquiryService.cs
- ICashWithdrawalService.cs
- IPinValidationService.cs

The project reference can be downloaded from the following GitHub project: 

BDD scenarios have been defined within this ATMTest project. Mocks have been defined within ATM.cs class, which call the methods defined within the respective Services.

The test data provided in the problem statement is referenced in the form of Cucumber data tables.

A Specflow runner class has been added to run the tests. However, this needs to be expanded further to generate HTML reports.


