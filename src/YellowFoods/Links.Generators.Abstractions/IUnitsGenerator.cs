namespace YellowFoods.Links.Generators.Abstractions
{
    public interface IUnitsGenerator
    {
        Link GetGetUnitLink(string relationship, int unitId);
        Link GetGetUnitsLink(string relationship);
    }
}