using SiliconStepe.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SiliconStepe.Models
{
    public class ResultQueryInfo
    { 
        public bool HasError { get; set; }
        public List<Message> Messages { get; set; }
    }
}
