//Cocktail: Represents a cocktail with 
//attributes like ID, Name, Ingredients, and Price.
namespace MVCBartenderApp.Models
{
    public class Cocktail {
        public int ID {get; set;}
        public string Name {get; set;}
        public string Ingredients {get; set;}
        public decimal Price {get; set;}
        public Cocktail() { }
    }
}