Feature: Feature file to test various transactions that can be performed using an ATM machine

@BalanceEnquiry
Scenario Outline: Balance Enquiry
	Given the user with <AccountNumber> enters <Pin> and selects Balance Enquiry	
	Then the available Balance is displayed

	Examples: 
	| Pin  | AccountNumber |
	| 1234 | 12345678      |


@CashWithdrawal
Scenario Outline: Cash Withdrawal

Given the user has entered <Pin>
When the user withdraws <Amount> below <Account Balance> and <Overdraft>
Then amount is withdrawn successfully

Examples:
| Pin  | Amount | Account Balance | Overdraft |
| 1234 | 8000    | 500             | 100       |

 