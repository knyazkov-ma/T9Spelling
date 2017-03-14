using System;
using System.Collections.Generic;

namespace T9Spelling.Core
{
    public class DataServiceException : Exception
    {
        public DataServiceInfo DataServiceExceptionData { get; private set; }
        
        
        public DataServiceException(string message, Dictionary<string, List<string>> messages)
            : base(message)
        {
            DataServiceExceptionData = new DataServiceInfo();

            DataServiceExceptionData.GeneralMessage = message;
            DataServiceExceptionData.Messages = messages;
        }
        
    }
}
