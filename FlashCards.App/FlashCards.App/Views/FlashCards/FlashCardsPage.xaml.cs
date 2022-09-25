using System.Collections.Generic;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards.App.Views.FlashCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashCardsPage : ContentPage
    {
        public FlashCardsPage()
        {
            InitializeComponent();
            _collection.ItemsSource = GenerateCards(20);
        }

        private List<Card> GenerateCards(int qty)
        {
            var cards = new List<Card>();
            for (var i = 0; i < qty; i++)
            {
                cards.Add(new Card(
                    name: "Card Collection " + i,
                    instagram: "@usuario" + i));
            }

            return cards;
        }

        private void GoToFlashcardPage(object sender, EventArgs e)
        {

        }
    }

    public class Card
    { 
        public string Name { get; private set; }
        public string Instagram { get; private set; }


        public Card(string name, string instagram)
        {
            Name = name;
            Instagram = instagram;
        }
    }
}