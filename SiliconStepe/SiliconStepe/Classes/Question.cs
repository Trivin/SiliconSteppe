using SiliconStepe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiliconStepe.Classes
{
    public class Question : INotRealization
    {
        private string _Text = "";
        public string Text
        {
            get => _Text;
            set
            {
                if (_Text != value)
                {
                    _Text = value;
                    OnPropertyChanged("Text");
                }
            }
        }

        private bool _Answer = false;
        public bool Answer
        {
            get => _Answer;
            set
            {
                if (_Answer != value)
                {
                    _Answer = value;
                    OnPropertyChanged("Answer");
                }
            }
        }
    }
}
