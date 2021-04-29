namespace YellowFoods.Api.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSuffix(this string value, string suffix)
        {
            if (value != null && value.EndsWith(suffix))
            {
                int index = value.LastIndexOf(suffix);
                value = value.Remove(index);
            }

            return value;
        }
    }
}
