using InterdisciplinarLTP6.Shared.Entities;

namespace InterdisciplinarLTP6.Domain.Entities
{
    public class Vehicle : Entity
    {
        public Vehicle()
        {

        }
        public Vehicle(string plate, string brand, string color)
        {
            Plate = plate;
            Brand = brand;
            Color = color;
        }

        public string Plate { get; private set; }
        public string Brand { get; private set; }
        public string Color { get; private set; }
    }
}
