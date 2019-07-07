using SiliconStepe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using static SiliconStepe.Views.SettingPage;

namespace SiliconStepe.Classes
{
    public class CustomListViewItem : INotRealization
    {
        private string name = "";
        private string value = "";
        private SettingType type;

        public ICommand TapCommand
        {
            get; set;
        }

        public SettingType Type
        {
            get => type;
            set
            {
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Value
        {
            get => this.value;
            set
            {
                if (value != this.value)
                {
                    this.value = value;
                    OnPropertyChanged("Value");
                }
            }
        }

    }
}
