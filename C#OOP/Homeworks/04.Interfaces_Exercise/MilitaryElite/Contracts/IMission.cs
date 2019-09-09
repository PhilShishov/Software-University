using MilitaryElite.Enums;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}