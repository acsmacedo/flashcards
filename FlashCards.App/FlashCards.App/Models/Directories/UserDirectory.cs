using FlashCards.App.Models.Flashcards;
using System.Collections.Generic;

namespace FlashCards.App.Models.Directories
{
    public class UserDirectory
    {
        public int ID { get; private set; }
        public int? ParentID { get; private set; }
        public int UserID { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<UserDirectoryItem> Directories { get; private set; }
        public IEnumerable<FlashcardCollection> Cards { get; private set; }

        public UserDirectory(
            int id, 
            int? parentID, 
            int userID,
            string name, 
            IEnumerable<UserDirectoryItem> directories, 
            IEnumerable<FlashcardCollection> cards)
        {
            ID = id;
            ParentID = parentID;
            UserID = userID;
            Name = name;
            Directories = directories;
            Cards = cards;
        }
    }
}
