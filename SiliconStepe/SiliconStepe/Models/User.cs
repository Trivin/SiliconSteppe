using System;
using System.Collections.Generic;
using System.Text;

namespace SiliconStepe.Models
{
    public class User : INotRealization
    {
        public string FIO
        {
            get => $"{SecondName} {FirstName} {MiddleName}";
        }

        public string ShortFIO
        {
            get => (SecondName?.Length > 0 ? SecondName.Substring(0, 1) : "") + (FirstName?.Length > 0 ? FirstName.Substring(0, 1) : "");
        }

        public int Type { get; set; }

        public string Token { get; set; }
        private string _Password { get; set; }
        private string _Description { get; set; }
        private string _Login { get; set; }
        private string _FirstName { get; set; }
        private string _SecondName { get; set; }
        private string _MiddleName { get; set; }
        private Organization _Organization { get; set; }
        public List<Rate> _Rates { get; set; }

        public string Description
        {
            get => _Description;
            set
            {
                if (value != _Description)
                {
                    _Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public int RateCount
        {
            get
            {
                return Rate?.Count ?? 0;
            }
        }

        public decimal AverageRate
        {
            get
            {
                int count = 0;
                decimal res = 0.0M;
                Rate?.ForEach((x) => { count++; res += x.Score; });
                return res/count;
            }
        }

        public List<Rate> Rate
        {
            get => _Rates;
            set
            {
                if (value != _Rates)
                {
                    _Rates = value;
                    OnPropertyChanged("Rate");
                }
            }
        }

        public string Login
        {
            get => _Login;
            set
            {
                if (value != _Login)
                {
                    _Login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public string Password
        {
            get => _Password;
            set
            {
                if (value != _Password)
                {
                    _Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string FirstName
        {
            get => _FirstName;
            set
            {
                if (value != _FirstName)
                {
                    _FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string SecondName
        {
            get => _SecondName;
            set
            {
                if (value != _SecondName)
                {
                    _SecondName = value;
                    OnPropertyChanged("SecondName");
                }
            }
        }

        public string MiddleName
        {
            get => _MiddleName;
            set
            {
                if (value != _MiddleName)
                {
                    _MiddleName = value;
                    OnPropertyChanged("MiddleName");
                }
            }
        }

        public Organization Organization
        {
            get => _Organization;
            set
            {
                if (value != _Organization)
                {
                    _Organization = value;
                    OnPropertyChanged("Organization");
                }
            }
        }
    }
}
