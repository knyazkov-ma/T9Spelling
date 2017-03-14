namespace T9Spelling
{
    class ProgramEntry
    {
        static void Main(string[] args)
        {
            var container = UnityConfig.GetConfiguredContainer();
            var program = (Program)container.Resolve(typeof(Program), "Program");
            program.Run();
        }
    }
}
