namespace BattleCards.Services
{
    using BattleCards.Models;
    using BattleCards.ViewModels.Cards;
    using System.Collections.Generic;

    public interface ICardService
    {
        IEnumerable<Card> GetAll();

        void Add(CardAddInputModel CardAddInputModel);

        IEnumerable<Card> GetAllCollection(string userId);

        void AddCardToCollection(int cardId, string userId);

        void DeleteById(int id);
    }
}