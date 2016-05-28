using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class GamesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GamesContext>
    {
        protected override void Seed(GamesContext context)
        {
            var games = new List<Game>
            {
                new Game() {Title="Arcanum", AgeRate=12,CreatorCompany="Sierra",Year=2001},
                new Game() {Title="Crash Bandicoot", AgeRate=7,CreatorCompany="Radical Entertaiment",Year=1996},
                new Game() {Title="Warcraft 3", AgeRate=12,CreatorCompany="Blizzard",Year=2002}
            };
            games.ForEach(g => context.Games.Add(g));
            context.SaveChanges();

            var stores = new List<Store>
            {
                new Store() {Name="Empik",Address="Kalwaryjska"},
                new Store() {Name = "Media Markt",Address="Pawia 3"}
            };
            stores.ForEach(s => context.Stores.Add(s));
            context.SaveChanges();

            var cardShirts = new List<CardShirt>
            {
                new CardShirt() { Name="CardShirt from outer space" },
                new CardShirt() { Name="Just typical CardShirt" }
            };
            cardShirts.ForEach(c => context.CardShirts.Add(c));
            context.SaveChanges();
        }
    }
}
