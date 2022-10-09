namespace FlashCards.App.Models.Categories
{
    public class Category
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Image { get; private set; }

        public Category(int id, string name, string image)
        {
            ID = id;
            Name = name;
            Image = image;
        }
    }
}
