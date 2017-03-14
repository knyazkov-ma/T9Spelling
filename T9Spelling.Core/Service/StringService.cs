using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using T9Spelling.Core.Resources;
using T9Spelling.Core.Service.Interface;

namespace T9Spelling.Core.Service
{
    public class StringService: BaseService, IStringService
    {
        public string GetT9Code(IDictionary<char, string> map, string message, bool largeInput, int inputLengthConstraint)
        {
            if (String.IsNullOrWhiteSpace(message))
                setErrorMsg("message", ExceptionMessageResource.EmptyString);
            else
            {
                if (message.Length > inputLengthConstraint)
                    setErrorMsg("message", String.Format(ExceptionMessageResource.MaxLength, message.Length, inputLengthConstraint));
            }
            
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in message)
            {
                if (c != ' ' && !map.ContainsKey(c))
                {
                    setErrorMsg("message", c.ToString());
                    continue;
                }
                
                if (c != ' ')
                    stringBuilder.Append(map[c]);
                else
                    stringBuilder.Append(" ");
            }

            if(errorMessages!= null && errorMessages.Any())
                throw new DataServiceException(ExceptionMessageResource.NotMappedLetter, errorMessages);

            return stringBuilder.ToString();
        }
    }
}
