using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T9Spelling.Core.Repository;
using T9Spelling.Core.Repository.Interface;
using System.Collections.Generic;
using T9Spelling.Core.Service.Interface;
using T9Spelling.Core.Service;
using Moq;

namespace T9Spelling.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMappingRepository_LetterMapping()
        {
            ILetterMappingRepository letterMappingRepository = new LetterMappingRepository();
            IDictionary<char, string> map = letterMappingRepository.Get();
            Assert.IsTrue(map['a'] == "2");
            Assert.IsTrue(map['b'] == "22");
            Assert.IsTrue(map['c'] == "222");
            Assert.IsTrue(map['d'] == "3");
            Assert.IsTrue(map['e'] == "33");
            Assert.IsTrue(map['f'] == "333");
            Assert.IsTrue(map['g'] == "4");
            //...
        }

        [TestMethod]
        public void TestMessageService_GetOutputs()
        {
            ILetterMappingRepository letterMappingRepository = new LetterMappingRepository();
            ISettingsRepository settingsRepository = new SettingsRepository();
            IFileRepository fileRepository = Mock.Of<IFileRepository>(s => s.GetAllLines("mockPath") == new string[5] 
            {
                "4",
                "hi",
                "yes",
                "foo  bar",
                "hello world"
            });
            IStringService stringService = new StringService();
            IMessageService messageService = new MessageService(letterMappingRepository,
                settingsRepository,
                fileRepository,
                stringService);

            IList<string> outputs = messageService.GetOutputs("mockPath", false);
            Assert.IsTrue(outputs[0] == "Case #1: 44 444");
            Assert.IsTrue(outputs[1] == "Case #2: 999337777");
            Assert.IsTrue(outputs[2] == "Case #3: 333666 6660 022 2777");
            Assert.IsTrue(outputs[3] == "Case #4: 4433555 555666096667775553");
        }

        [TestMethod]
        public void TestStringService_GetT9Code()
        {
            ILetterMappingRepository letterMappingRepository = new LetterMappingRepository();
            ISettingsRepository settingsRepository = new SettingsRepository();
            IStringService stringService = new StringService();
            string output = stringService.GetT9Code(letterMappingRepository.Get(), 
                "hello world", false, settingsRepository.GetSmallInputLengthConstraint());
            Assert.IsTrue(output == "4433555 555666096667775553");
        }
    }
}
