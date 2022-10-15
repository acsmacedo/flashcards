namespace FlashCards.App.Models.Directories
{
    public class UserDirectoryItem : BaseModel
    {
        public int ID { get; private set; }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public UserDirectoryItem(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public void Change(string name)
        {
            Name = name;
        }
    }
}
