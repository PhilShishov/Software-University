namespace MilitaryElite.Contracts
{
    using MilitaryElite.Enums;

    public interface ISpecialisedSoldier: IPrivate
    {
        Corps Corps { get; }
    }
}