﻿namespace FlashCards.App.Models.Flashcards
{
    public class FlashcardCollection
    {
        public int ID { get; private set; }
        public int CategoryID { get; private set; }
        public int UserDirectoryID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Stars { get; private set; }
        public int Available { get; private set; }
        public string UserInstagram { get; private set; }

        public FlashcardCollection(
            int id, 
            int categoryID, 
            int userDirectoryID,
            string name, 
            string description, 
            int stars, 
            int available, 
            string userInstagram)
        {
            ID = id;
            CategoryID = categoryID;
            UserDirectoryID = userDirectoryID;
            Name = name;
            Description = description;
            Stars = stars;
            Available = available;
            UserInstagram = userInstagram;
        }
    }
}
