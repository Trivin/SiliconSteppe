using System;
using System.Collections.Generic;
using System.Text;

namespace SiliconStepe.Models
{
    public class Rate : INotRealization
    {
        public DateTime EventDate
        {
            get => _EventDate;
            set
            {
                if (_EventDate != value)
                {
                    _EventDate = value;
                    OnPropertyChanged("EventDate");
                }
            }
        }
        public User RateUser
        {
            get => _RateUser;
            set
            {
                if (_RateUser != value)
                {
                    _RateUser = value;
                    OnPropertyChanged("RateUser");
                }
            }
        }
        public User FromUser
        {
            get => _FromUser;
            set
            {
                if (_FromUser != value)
                {
                    _FromUser = value;
                    OnPropertyChanged("FromUser");
                }
            }
        }
        public decimal Score
        {
            get => _Score;
            set
            {
                if (_Score != value)
                {
                    _Score = value;
                    OnPropertyChanged("Score");
                }
            }
        }

        DateTime    _EventDate;
        User        _RateUser ;
        User        _FromUser ;
        decimal _Score;
    }
}
