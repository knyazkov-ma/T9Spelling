using System.Collections.Generic;

namespace T9Spelling.Core.Service.Interface
{
    public interface IMessageService
    {
        IList<string> GetOutputs(string path, bool largeInput);
        void SaveOutputs(string path, IList<string> outputs);
    }
}
