namespace FlashCards.App.Models.Directories
{
    public class DeleteUserDirectoryDto
    {
        public int ID { get; private set; }

        public DeleteUserDirectoryDto(int id)
        {
            ID = id;
        }
    }
}
