using System;
using System.Linq;
using System.Collections.Generic;
using T9Spelling.Core.Repository.Interface;
using T9Spelling.Core.Resources;
using T9Spelling.Core.Service.Interface;

namespace T9Spelling.Core.Service
{
    public class MessageService : BaseService, IMessageService
    {
        private readonly ISettingsRepository settingsRepository;
        private readonly ILetterMappingRepository letterMappingRepository;
        private readonly IFileRepository fileRepository;
        private readonly IStringService stringService;

        public MessageService(ILetterMappingRepository letterMappingRepository,
            ISettingsRepository settingsRepository,
            IFileRepository fileRepository,
            IStringService stringService)
        {
            this.letterMappingRepository = letterMappingRepository;
            this.settingsRepository = settingsRepository;
            this.fileRepository = fileRepository;
            this.stringService = stringService;
        }

        public IList<string> GetOutputs(string path, bool largeInput)
        {
            string[] messages = fileRepository.GetAllLines(path);

            if (messages == null || !messages.Any())
                return null;
            
            if(messages.Length < 2)
                setErrorMsg("messages", ExceptionMessageResource.NotCorrectFileFormat_CountRow);

            int maxN = 0;
            Int32.TryParse(messages[0], out maxN);

            if (maxN == 0)
                setErrorMsg("messages", ExceptionMessageResource.NotCorrectFileFormat_FirstRow);

            int inputLengthConstraint = 0;
            if (largeInput)
                inputLengthConstraint = settingsRepository.GetLargeInputLengthConstraint();
            else
                inputLengthConstraint = settingsRepository.GetSmallInputLengthConstraint();

            IDictionary<char, string> map = letterMappingRepository.Get();
            IList<string> outputs = new List<string>();
            int N = 0;
            for (int i = 1; i <= maxN && i < messages.Length; i++)
                if (!String.IsNullOrEmpty(messages[i]))
                {
                    N++;
                    outputs.Add(String.Format("Case #{0}: {1}", N,
                        stringService.GetT9Code(map, messages[i], largeInput, inputLengthConstraint)));
                }

            return outputs;
        }

        public void SaveOutputs(string path, IList<string> outputs)
        {
            fileRepository.WriteAllLines(path, outputs.ToArray());
        }


    }
}
