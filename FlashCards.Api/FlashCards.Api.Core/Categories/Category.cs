using FlashCards.Api.Core.FlashCards;

namespace FlashCards.Api.Core.Categories;

public class Category
{
    public const int NameMaxLength = 80;

    public int ID { get; private set; }
    public string Name { get; private set; } = string.Empty;
    //public IReadOnlyCollection<FlashCardCollection> FlashCardCollections { get; private set; }
    //    = new List<FlashCardCollection>();

    public Category(string name)
    {
        Name = name;
    }

    public void Edit(string name)
    {
        Name = name;
    }

    public static Category Empty => new(string.Empty);
}
