using System;
using System.Collections.Generic;
using System.Text;

namespace SiliconStepe.Models
{
    public class Invite : INotRealization
    {
        private User _Worker;
        public User Worker
        {
            get => _Worker;
            set
            {
                if (value != _Worker)
                {
                    _Worker = value;
                    OnPropertyChanged("Worker");
                }
            }
        }

        private User _Employee;
        public User Employee
        {
            get => _Employee;
            set
            {
                if (value != _Employee)
                {
                    _Employee = value;
                    OnPropertyChanged("Employee");
                }
            }
        }

        private DateTime _DateTime;
        public DateTime DateTime
        {
            get => _DateTime;
            set
            {
                if (value != _DateTime)
                {
                    _DateTime = value;
                    OnPropertyChanged("DateTime");
                }
            }
        }

        private bool _Status;
        public bool Status
        {
            get => _Status;
            set
            {
                if (value != _Status)
                {
                    _Status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        private string _Description;
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
    }
}
