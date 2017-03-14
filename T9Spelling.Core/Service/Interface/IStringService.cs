using System.Collections.Generic;

namespace T9Spelling.Core.Service.Interface
{
    public interface IStringService
    {
        string GetT9Code(IDictionary<char, string> map, string message, bool largeInput, int inputLengthConstraint);
        
    }
}
