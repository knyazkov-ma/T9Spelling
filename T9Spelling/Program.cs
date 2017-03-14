using System;
using System.Collections.Generic;
using T9Spelling.Core.Service.Interface;

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
            string path;
            Console.WriteLine("Введите полный путь до файла с сообщениями");
            path = Console.ReadLine();
            IList<string> outputs = messageService.GetOutputs(path, false);

            string outPath = path + ".out";
            messageService.SaveOutputs(outPath, outputs);
            Console.WriteLine("Закодированный файл: " + outPath);
        }
    }
}
