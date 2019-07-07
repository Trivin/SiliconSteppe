using System;
using System.Collections.Generic;
using System.Text;

namespace SiliconStepe.Models
{
    public class Organization : INotRealization
    {
        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string _FullName;
        public string FullName
        {
            get => _FullName;
            set
            {
                if (_FullName != value)
                {
                    _FullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        private string _INN;
        public string INN
        {
            get => _INN;
            set
            {
                if (_INN != value)
                {
                    _INN = value;
                    OnPropertyChanged("INN");
                }
            }
        }

        private OrganizationType _OrganizationType;
        public OrganizationType OrganizationType
        {
            get => _OrganizationType;
            set
            {
                if (_OrganizationType != value)
                {
                    _OrganizationType = value;
                    OnPropertyChanged("OrganizationType");
                }
            }
        }
    }
}
