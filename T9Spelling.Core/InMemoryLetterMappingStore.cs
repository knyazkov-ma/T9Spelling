using System.Collections.Generic;

namespace T9Spelling.Core
{
    internal class InMemoryLetterMappingStore
    {
        public static IDictionary<char, string> Map = new Dictionary<char, string>()
        {
            { 'a', "2" },
            { 'b', "22" },
            { 'c', "222" },
        };
        
    }
}
