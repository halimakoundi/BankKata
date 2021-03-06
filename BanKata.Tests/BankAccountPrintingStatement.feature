﻿Feature: BankAccountPrintingStatement
	In order to have an overview of my account
	As a owner of a bank account
	I want to see the transactions made into my account and its balance

@mytag
Scenario: Print statement
	Given A client makes a deposit of 1000.00 on 10/01/2012
	And a deposit of 2000.00 on 13/01/2012
	And a withdrawal of 500.00 on 14/01/2012
	When the client prints the bank statement
	Then the client would see "date || credit || debit || balance\n14/01/2012 || || 500.00 || 2500.00\n13/01/2012 || 2000.00 || || 3000.00\n10/01/2012 || 1000.00 || || 1000.00"
	 