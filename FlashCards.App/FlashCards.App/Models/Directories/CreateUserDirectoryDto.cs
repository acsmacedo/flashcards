namespace FlashCards.App.Models.Directories
{
    public class CreateUserDirectoryDto
    {
        public int? ParentID { get; private set; }
        public int UserID { get; private set; }
        public string Name { get; private set; }

        public CreateUserDirectoryDto(
            int? parentID,
            int userID,
            string name)
        {
            ParentID = parentID;
            UserID = userID;
            Name = name;
        }
    }
}
