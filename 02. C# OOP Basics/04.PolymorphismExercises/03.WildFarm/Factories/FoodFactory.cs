namespace _03.WildFarm.Factories
{
    public class FoodFactory
    {
        public static Food CreateFood(string[] foodArgs)
        {
            string foodType = foodArgs[0];
            int foodQuantity = int.Parse(foodArgs[1]);

            if (foodType == "Meat")
            {
                return new Meat(foodQuantity);
            }

            return new Vegetable(foodQuantity);
        }
    }
}