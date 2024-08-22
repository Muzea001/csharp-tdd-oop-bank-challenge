﻿using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class BankTests
    {

        [Test]

        public void checkIfRegularAccountCreated()
        {
            //Arrange
            Bank bank = new Bank();
            RegularAccount Raccount = new RegularAccount();
            string accountHolder = "Jonh Johnson";
            string type = "Regular";

            //Act
            Raccount.Create(type, accountHolder);
            var account = bank.accounts.OfType<RegularAccount>().FirstOrDefault(x => x.nameOfHolder == accountHolder);

            //Assert
            Assert.IsTrue(bank.accounts.Contains(account));
            bank.accounts.Remove(account);

        }

        public void checkIfSavingsAccountCreated()
        {

            //Arrange 
            Bank bank = new Bank();
            SavingsAccount Saccount = new SavingsAccount();
            string accountHolder = "Mike Smith";
            string type = "Savings";

            //Act
            Saccount.Create(type, accountHolder);
            var account = bank.accounts.OfType<SavingsAccount>().FirstOrDefault(x => x.nameOfHolder == accountHolder);


            //Assert
            Assert.IsTrue(bank.accounts.Contains(account));
            bank.accounts.Remove(account);

        }



        public void checkIfDeposited()
        {

            //Arrange
            Bank bank = new Bank();
            RegularAccount account = new RegularAccount();
            SavingsAccount savingsAccount = new SavingsAccount();
            string receiver = "John Johnson";
            decimal amount = 500;
            var accountToTransferTo = bank.accounts
             .FirstOrDefault(a =>
                (a is RegularAccount && ((RegularAccount)a).nameOfHolder == receiver) ||
                (a is SavingsAccount && ((SavingsAccount)a).nameOfHolder == receiver)
    );

            //Act
            Transaction transaction = new Transaction(savingsAccount, amount, new DateOnly(2024, 12, 24));
            if (accountToTransferTo.GetType() == typeof(RegularAccount))
            {
                account.deposit(amount, accountToTransferTo);
                account.transactionList.Add(transaction);
                Assert.IsTrue(account.transactionList.Contains(transaction));
            }
            else if (accountToTransferTo.GetType() == typeof(SavingsAccount))
            {
                savingsAccount.deposit(amount, accountToTransferTo);
                savingsAccount.transactionList.Add(transaction);
                Assert.IsTrue(savingsAccount.transactionList.Contains(transaction));
            }
        }



        [Test]

        public void checkIfWithdrawn()
        {

            //Arrange
            Bank bank = new Bank();
            RegularAccount account = new RegularAccount();
            SavingsAccount savingsAccount = new SavingsAccount();
            string receiver = "John Johnson";
            decimal amount = -500;
            var accountToTransferTo = bank.accounts
             .FirstOrDefault(a =>
                (a is RegularAccount && ((RegularAccount)a).nameOfHolder == receiver) ||
                (a is SavingsAccount && ((SavingsAccount)a).nameOfHolder == receiver)
    );

            //Act
            Transaction transaction = new Transaction(savingsAccount, amount, new DateOnly(2024, 12, 25));
            if (accountToTransferTo.GetType() == typeof(RegularAccount))
            {
                account.deposit(amount, accountToTransferTo);
                account.transactionList.Add(transaction);
                Assert.IsTrue(account.transactionList.Contains(transaction));
            }
            else if (accountToTransferTo.GetType() == typeof(SavingsAccount))
            {
                savingsAccount.deposit(amount, accountToTransferTo);
                savingsAccount.transactionList.Add(transaction);
                Assert.IsTrue(savingsAccount.transactionList.Contains(transaction));
            }

        }

        [Test]

        public void checkIfRegularBalanceCorrect()
        {

            //Arrange
            Bank bank = new Bank();
            RegularAccount regular = new RegularAccount();
            string accountHodler = "John Johnson";
            decimal expectedSum = 100;
            var account = bank.accounts.OfType<RegularAccount>().FirstOrDefault(x => x.nameOfHolder == accountHodler);
            //Act

            decimal currentBalance= regular.balance(account);
            Assert.AreEqual(expectedSum, currentBalance);
        }


        [Test]

        public void checkIfSavingsBalanceCorrect()
        {

            //Arrange
            Bank bank = new Bank();
            SavingsAccount savings = new SavingsAccount();
            string accountHodler = "John Johnson";
            decimal expectedSum = 100;
            var account = bank.accounts.OfType<SavingsAccount>().FirstOrDefault(x => x.nameOfHolder == accountHodler);
            //Act

            decimal currentBalance = savings.balance(savings);
            Assert.AreEqual(expectedSum, currentBalance);
        }


        [Test]

        public void checkIfBranchCorrect()
        {
            //Arrange

            Bank bank = new Bank();
            CityBranch cityBranch = new CityBranch();
            RemoteBranch remoteBranch = new RemoteBranch();
            RuralBranch ruralBranch = new RuralBranch();
            string accountHodler = "John Johnson";
            var account = bank.accounts.OfType<RegularAccount>().FirstOrDefault(x => x.nameOfHolder == accountHodler);

            //Act
            cityBranch.accounts.Add(account);
            string expectedBranch = "City";
            Assert.AreEqual(cityBranch.getType(account), expectedBranch);
            Assert.IsTrue(cityBranch.accounts.Contains(account));


            
        }
    }
}

    
