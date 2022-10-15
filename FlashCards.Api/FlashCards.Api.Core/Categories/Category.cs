using FlashCards.Api.Core.FlashCards;

namespace FlashCards.Api.Core.Categories;

public class Category
{
    public const int NameMaxLength = 80;
    public const int ImageMaxLength = 1000;

    public int ID { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Image { get; private set; } = string.Empty;

    public IReadOnlyCollection<FlashCardCollection> FlashCardCollections { get; private set; }
        = new List<FlashCardCollection>();

    public Category(int id, string name, string image)
    {
        ID = id;
        Name = name;
        Image = image;
    }

    public Category(string name, string image)
    {
        Name = name;
        Image = image;
    }

    public void Edit(string name, string image)
    {
        Name = name;
        Image = image;
    }
}
