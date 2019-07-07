using System;
using System.Collections.Generic;
using System.Text;

namespace SiliconStepe.Classes
{
    class CustomException : Exception
    {
        public List<Message> Messages { get; set; }
        public CustomException(string Text) : base(Text)
        {
        }

        public CustomException(List<Message> messages)
        {
            this.Messages = messages;
        }
    }
}
