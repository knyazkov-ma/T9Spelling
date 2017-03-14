using System.Collections.Generic;
using T9Spelling.Core.Repository.Interface;

namespace T9Spelling.Core.Repository
{
    public class LetterMappingRepository: ILetterMappingRepository
    {
        public IDictionary<char, string> Get()
        {
            return InMemoryLetterMappingStore.Map;
        }
    }
}
