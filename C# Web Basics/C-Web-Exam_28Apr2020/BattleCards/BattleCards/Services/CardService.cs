namespace BattleCards.Services
{
    using BattleCards.Data;
    using BattleCards.Models;
    using BattleCards.ViewModels.Cards;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class CardService : ICardService
    {
        private readonly ApplicationDbContext dbContext;

        public CardService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Card> GetAll()
            => this.dbContext
            .Cards
            .Select(c => new Card
            {
                Id = c.Id,
                Name = c.Name,
                ImageUrl = c.ImageUrl,
                Keyword = c.Keyword,
                Attack = c.Attack,
                Health = c.Health,
                Description = c.Description
            })
            .ToArray();

        public void Add(CardAddInputModel cardAddInputModel)
        {
            var card = new Card()
            {
                Name = cardAddInputModel.Name,
                ImageUrl = cardAddInputModel.ImageUrl,
                Keyword = cardAddInputModel.Keyword,
                Attack = cardAddInputModel.Attack,
                Health = cardAddInputModel.Health,
                Description = cardAddInputModel.Description,
            };

            this.dbContext.Cards.Add(card);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<Card> GetAllCollection(string userId)
        {
            var userCards = this.dbContext
             .UserCards
             .Where(uc => uc.UserId == userId)
             .Select(uc => uc.CardId)
             .ToArray();

            List<Card> cards = new List<Card>(); 

            foreach (var cardId in userCards)
            {
                var targetCard = this.dbContext.Cards.Where(c => c.Id == cardId).FirstOrDefault();
                cards.Add(targetCard);
            }

            return cards.ToArray();
        }

        public void AddCardToCollection(int cardId, string userId)
        {
            var targetUser = this.dbContext.Users.FirstOrDefault(x => x.Id == userId);
            var userCard = new UserCard
            {
                UserId = userId,
                CardId = cardId
            };

            if (!this.dbContext.UserCards.Any(ut => ut.CardId == userCard.CardId && ut.UserId == userCard.UserId))
            {
                targetUser.UserCards.Add(userCard);
                dbContext.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            var userCard = this.dbContext.UserCards.Where(uc => uc.CardId == id).FirstOrDefault();
            this.dbContext.UserCards.Remove(userCard);
            this.dbContext.SaveChanges();
        }
    }
}