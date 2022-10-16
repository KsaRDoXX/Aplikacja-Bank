using System;
using System.Collections.Generic;
using System.Text;

namespace Bankomat_X.Models
{
    public class Account : ViewModelBase
    {
		private string accountName;

		public string AccountName
		{
			get { return accountName; }
			set { accountName = value; }
		}


		private User owner;

		public User Owner
		{
			get { return owner; }
			set { owner = value;
				OnPropertyChanged();
			}
		}

		private float balance;

		public float Balance
		{
			get { return balance; }
			set { balance = value;
                OnPropertyChanged();
            }
		}

		private AccountType accountType;

		public Account(string accName, string ownerName, float balance,  AccountType accountType)
		{
			this.AccountName = accName;
			this.Owner = new User(ownerName); 	
			Balance = balance;	
			AccountType = accountType;
		}

        public Account(string accName, User owner, float balance, AccountType accountType)
        {
			this.AccountName = accName;
			this.Owner = owner;
            Balance = balance;
            AccountType = accountType;
        }

        public AccountType AccountType
		{
			get { return accountType; }
			set
			{
				accountType = value;
				OnPropertyChanged();
			}
		}
	}

	public class AccountType : ViewModelBase
	{
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; 
				OnPropertyChanged(); }
		}

		private float multiplier;
		public float Multiplier
		{
			get { return multiplier; }
			set { multiplier = value;
				OnPropertyChanged(); }
		}

		public AccountType(string name, float mult)
		{
			this.Name = name;
			this.Multiplier = mult;
		}
		
	}
}
