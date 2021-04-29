namespace YellowFoods.Api.Links.Generators.Abstractions
{
    public interface INutrientsGenerator
    {
        Link GetGetNutrientLink(string relationship, int nutrientId);
        Link GetGetNutrientsLink(string relationship);
    }
}