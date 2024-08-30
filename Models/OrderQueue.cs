namespace MVCBartenderApp.Models
{
    public class OrderQueue
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Cocktail> Cocktails { get; set; } = new List<Cocktail>();
    }
}