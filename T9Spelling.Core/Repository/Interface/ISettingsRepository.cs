namespace T9Spelling.Core.Repository.Interface
{
    public interface ISettingsRepository
    {
        int GetLargeInputLengthConstraint();
        int GetSmallInputLengthConstraint();
    }
}
