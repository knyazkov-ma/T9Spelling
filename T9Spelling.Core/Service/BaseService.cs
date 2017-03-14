using System.Collections.Generic;
using System.Linq;


namespace T9Spelling.Core.Service
{
    public abstract class BaseService
    {
        
        protected Dictionary<string, List<string>> errorMessages = new Dictionary<string, List<string>>();
        
        protected void setErrorMsg(string key, string msg)
        {
            if (!errorMessages.Keys.Contains(key))
                errorMessages[key] = new List<string>();
            errorMessages[key].Add(msg);
        }
    
    }
}
