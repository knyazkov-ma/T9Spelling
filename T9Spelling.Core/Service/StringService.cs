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
            string prevCode = null;
            string currCode = null;

            foreach (char c in message)
            {
                if (!map.ContainsKey(c))
                {
                    setErrorMsg("message", c.ToString());
                    continue;
                }

                currCode = map[c];

                if (prevCode != null)
                {
                    if (prevCode[prevCode.Length - 1] == currCode[0])
                        stringBuilder.Append(" "); //The space character ' ' should be printed to indicate a pause
                }

                prevCode = currCode;

                stringBuilder.Append(currCode);
            }

            if(errorMessages!= null && errorMessages.Any())
                throw new DataServiceException(ExceptionMessageResource.NotMappedLetter, errorMessages);

            return stringBuilder.ToString();
        }
    }
}
