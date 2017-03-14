using System.IO;
using T9Spelling.Core.Repository.Interface;

namespace T9Spelling.Core.Repository
{
    public class FileRepository : IFileRepository
    {
        public string[] GetAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

        public void WriteAllLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }
    }
}
