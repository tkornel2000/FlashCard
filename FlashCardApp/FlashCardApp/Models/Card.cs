namespace FlashCardApp.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Hungary { get; set; } = null!;
        public string German { get; set; } = null!;
        public int Correct { get; set; }
        public int Incorrect { get; set; }
    }
}
