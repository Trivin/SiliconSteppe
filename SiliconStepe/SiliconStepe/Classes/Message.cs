using System;
using System.Collections.Generic;
using System.Text;

namespace SiliconStepe.Classes
{
    public class Message
    {
        public string Text { get; set; }
        public MessageType Type { get; set; }
    }
    public enum MessageType
    {
        Info = 0,
        Warning,
        Error
    }
}
