public class FoodFactory
{
    public Food CreateFood(string arg)
    {
        Food food;

        switch (arg.ToLower())
        {
            case "apple":
                food = new Apple(1);
                break;

            case "cram":
                food = new Cram(2);
                break;

            case "honeycake":
                food = new HoneyCake(5);
                break;

            case "lembas":
                food = new Lembas(3);
                break;

            case "melon":
                food = new Melon(1);
                break;

            case "mushrooms":
                food = new Mushrooms(-10);
                break;

            default:
                food = new OtherFood(-1);
                break;
        }

        return food;
    }
}