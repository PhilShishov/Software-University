namespace Skeleton.Contracts
{
    public interface ITarget
    {
        int Health { get; }

        int GiveExperience();

        void TakeAttack(int attackPoints);

        bool IsDead();

    }
}