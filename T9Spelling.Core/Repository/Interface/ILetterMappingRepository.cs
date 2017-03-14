using System.Collections.Generic;

namespace T9Spelling.Core.Repository.Interface
{
    public interface ILetterMappingRepository
    {
        IDictionary<char, string> Get();
    }
}
