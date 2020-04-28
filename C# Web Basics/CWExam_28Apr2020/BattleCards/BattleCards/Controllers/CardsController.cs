namespace BattleCards.Controllers
{
    using BattleCards.Models;
    using BattleCards.Services;
    using BattleCards.ViewModels.Cards;

    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CardsController : Controller
    {
        private const int MinValue = 0;
        private const int MinNameLength = 5;
        private const int MaxNameLength = 15;
        private const int MaxDescriptionLength = 200;

        private readonly ICardService cardsService;

        public CardsController(ICardService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View(this.cardsService.GetAll(), "All");
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CardAddInputModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.View();
            }

            if (inputModel.Name.Length < MinNameLength || inputModel.Name.Length > MaxNameLength || string.IsNullOrWhiteSpace(inputModel.Name))
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(inputModel.ImageUrl) || string.IsNullOrWhiteSpace(inputModel.Keyword))
            {
                return this.View();
            }

            if (inputModel.Attack < MinValue || inputModel.Health < MinValue)
            {
                return this.View();
            }

            if (inputModel.Description.Length > MaxDescriptionLength || string.IsNullOrWhiteSpace(inputModel.Description))
            {
                return this.View();
            }

            this.cardsService.Add(inputModel);
            return this.Redirect("/Cards/All");
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.Request.SessionData["UserId"];
            IEnumerable<Card> collection = this.cardsService.GetAllCollection(userId);
            return this.View(collection);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.Request.SessionData["UserId"];
            this.cardsService.AddCardToCollection(cardId, userId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            this.cardsService.DeleteById(cardId);

            return this.Redirect("/Cards/Collection");
        }
    }
}