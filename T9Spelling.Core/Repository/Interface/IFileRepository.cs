namespace T9Spelling.Core.Repository.Interface
{
    public interface IFileRepository
    {
        string[] GetAllLines(string path);
        void WriteAllLines(string path, string[] lines);
    }
}
