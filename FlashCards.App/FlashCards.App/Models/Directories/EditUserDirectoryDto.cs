namespace FlashCards.App.Models.Directories
{
    public class EditUserDirectoryDto
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public EditUserDirectoryDto(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
