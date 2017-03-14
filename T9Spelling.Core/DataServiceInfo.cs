using System.Collections.Generic;

namespace T9Spelling.Core
{
    public class DataServiceInfo
    {
        public IDictionary<string, List<string>> Messages { get; set; }
        public string GeneralMessage { get; set; }
    }
}
