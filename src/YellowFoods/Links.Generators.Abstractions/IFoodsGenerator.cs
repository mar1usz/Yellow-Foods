namespace YellowFoods.Links.Generators.Abstractions
{
    public interface IFoodsGenerator
    {
        Link GetDeleteFoodLink(string relationship, int foodId);
        Link GetGetFoodLink(string relationship, int foodId);
        Link GetGetFoodsLink(string relationship);
        Link GetPostFoodLink(string relationship);
        Link GetPutFoodLink(string relationship, int foodId);
    }
}