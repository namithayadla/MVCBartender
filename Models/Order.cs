//Order: Represents an order with attributes like 
//ID, CocktailID, CustomerName, CustomerEmail, and Status.
namespace MVCBartenderApp.Models {
    public class Order {
        public int ID {get; set;}
        public int CocktailID {get; set;}
        public string CocktailName {get; set;}
        public string CustomerName {get; set;}
        public string CustomerEmail {get; set;}
        public string Status {get; set;}
        public Order() { }
    }
}
