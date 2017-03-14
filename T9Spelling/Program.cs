using System;
using System.Collections.Generic;
using T9Spelling.Core.Service.Interface;
using T9Spelling.Resources;

namespace T9Spelling
{
    class Program
    {
        private readonly IMessageService messageService;

        public Program(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public void Run()
        {
            Console.WriteLine(ConsoleMessageResource.EnterPathToInputFile);
            string path = Console.ReadLine();

            Console.WriteLine(ConsoleMessageResource.IsLongMessages);
            string yes = Console.ReadLine();

            IList<string> outputs = messageService.GetOutputs(path, yes == "y");
            
            string outPath = path + ".out";
            messageService.SaveOutputs(outPath, outputs);

            Console.WriteLine(ConsoleMessageResource.OutputFile + outPath);
        }
    }
}
