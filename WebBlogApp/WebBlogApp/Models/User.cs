namespace WebBlogApp.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(int id, string name, string surname, string email, string phone, string username, string password)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Username = username;
            Password = password;
        }
    }
}