using Bankomat_X.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xamarin.Forms;

namespace Bankomat_X
{

    public partial class MainPage : ContentPage
    {
        public void UpdateText()
        {  
            OwnerLabel.Text = selectedAccount.Owner.Name;
            LokataLabel.Text = selectedAccount.AccountType.Name;
            SelectedAccount.Balance = (float)Math.Round(SelectedAccount.Balance,2);
            StanLabel.Text = selectedAccount.Balance.ToString();
            AccPicker.ItemsSource = Accounts;  
        }

        public bool IsValid(string x)
        {
            float zm;
            if (!string.IsNullOrEmpty(x) && float.TryParse(x, out zm)) 
                return true;
            else
                return false;
            
        }
   
        public List<AccountType> accountTypes { get; set; }
        public List<Account> Accounts { get; set; }
        private Account selectedAccount;

        public Account SelectedAccount
        {
            get { return selectedAccount; }
            set { selectedAccount = value; }
        }

        public MainPage()
        {
          
            accountTypes = new List<AccountType>();

            accountTypes.Add(new AccountType("Lokata 10%", 1.1f));
            accountTypes.Add(new AccountType("Lokata 1%", 1.01f));
            accountTypes.Add(new AccountType("Lokata 5%", 1.05f));
            accountTypes.Add(new AccountType("Lokata 2%", 1.02f));

            Accounts = new List<Account>();
            Accounts.Add(new Account("Konto A", new User("Wiktor Kwiecień"), 4.3f, accountTypes[0])) ;
            Accounts.Add(new Account("Konto B", User.UserList[0], 5.5f, accountTypes[1] ));
            Accounts.Add(new Account("Konto C", new User("Krzysztof Niemiecki"), 100.0f, accountTypes[2] ));

            selectedAccount = Accounts[0];

            InitializeComponent();
    
        }

        private void AccountChanged(object sender, EventArgs e)
        {
            selectedAccount = Accounts[AccPicker.SelectedIndex];
            AccountTypePicker.SelectedItem = SelectedAccount.AccountType;
            UpdateText();
        }

        private void Wplac(object sender, EventArgs e)
        {
            if (IsValid(KwotaEntry.Text))
            {
                selectedAccount.Balance += float.Parse(KwotaEntry.Text);
                UpdateText();
            }
            else
            {
                KwotaEntry.Text = "";
                DisplayAlert("Błąd", "Niewłaściwy format kwoty", "OK");
            }


        }

            private void Wyplac(object sender, EventArgs e)
            {

             if (IsValid(KwotaEntry.Text))
             {
                if (SelectedAccount.Balance - float.Parse(KwotaEntry.Text) >= 0)
                {
                    selectedAccount.Balance -= int.Parse(KwotaEntry.Text);
                    UpdateText();
                } else
                {
                    KwotaEntry.Text = "";
                    DisplayAlert("Błąd", "Nie masz tyle pieniędzy", "OK");
                }

             } else
             {
                KwotaEntry.Text = "";
                DisplayAlert("Błąd", "Niewłaściwy format kwoty", "OK");
             }
               
            
           
            }

        private void NaliczOdsetki(object sender, EventArgs e)
        {
            selectedAccount.Balance *= selectedAccount.AccountType.Multiplier;
            UpdateText();
        }

        private void TypeChanged(object sender, EventArgs e)
        {
            selectedAccount.AccountType = (AccountType)AccountTypePicker.SelectedItem;
            UpdateText();
        }

        private void UpdateOwner(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(OwnerEntry.Text))
            {
                selectedAccount.Owner.Name = OwnerEntry.Text;
                UpdateText();
            } else  DisplayAlert("Błąd", "Niepoprawna nazwa użytkownika", "OK");
            
        }
    }
}
