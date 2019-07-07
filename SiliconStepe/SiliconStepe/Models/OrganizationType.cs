using System;
using System.Collections.Generic;
using System.Text;

namespace SiliconStepe.Models
{
    public class OrganizationType : INotRealization
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
    }
}
