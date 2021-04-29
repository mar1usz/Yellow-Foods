namespace YellowFoods.Api.Links.Generators.Abstractions
{
    public interface INutrientEntriesGenerator
    {
        Link GetDeleteNutrientEntryLink(string relationship, int foodId, int nutrientEntryId);
        Link GetGetNutrientEntriesLink(string relationship, int foodId);
        Link GetGetNutrientEntryLink(string relationship, int foodId, int nutrientEntryId);
        Link GetPostNutrientEntryLink(string relationship, int foodId);
        Link GetPutNutrientEntryLink(string relationship, int foodId, int nutrientEntryId);
    }
}
