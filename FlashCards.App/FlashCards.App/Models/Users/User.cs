namespace FlashCards.App.Models.Users
{
    public class User : BaseModel
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Instagram { get; private set; }
        public string Interests { get; private set; }
        public string Photo { get; private set; }
        public int Following { get; private set; }
        public int Followers { get; private set; }
        public int Available { get; private set; }
        public int Stars { get; private set; }

        public User(
            int id,
            string name, 
            string instagram, 
            string interests, 
            string photo, 
            int following,
            int followers,
            int available,
            int stars)
        {
            ID = id;
            Name = name;
            Instagram = instagram;
            Interests = interests;
            Photo = photo;
            Following = following;
            Followers = followers;
            Available = available;
            Stars = stars;
        }
    }
}
