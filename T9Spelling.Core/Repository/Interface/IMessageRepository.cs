namespace T9Spelling.Core.Repository.Interface
{
    public interface IMessageRepository
    {
        string[] GetAllLines(string path);
        void WriteAllLines(string path, string[] lines);
    }
}
