namespace T9Spelling.Core.Repository.Interface
{
    public class SettingsRepository: ISettingsRepository
    {
        public int GetLargeInputLengthConstraint()
        {
            return 1000;
        }
        public int GetSmallInputLengthConstraint()
        {
            return 15;
        }
    }
}
