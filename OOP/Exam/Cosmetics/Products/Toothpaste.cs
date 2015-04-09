namespace Cosmetics.Products
{
    using System.Collections.Generic;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    internal class Toothpaste : Product, IToothpaste
    {
        private const int IngredientNameMaxLength = 12;

        private const int IngredientNameMinLength = 4;

        private const string EachIngredientNameSLengthShouldBeBetweenAndSymbolsInclusive = "Each ingredient name’s length should be between {0} and {1} symbols, inclusive";

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.ValidateIngredients(ingredients);
            this.Ingredients = string.Join(", ", ingredients);
        }

        public void ValidateIngredients(IList<string> ingredientsList)
        {
            Validator.CheckIfNull(ingredientsList);
            foreach (var ingredient in ingredientsList)
            {
                Validator.CheckIfStringIsNullOrEmpty(ingredient);
                Validator.CheckIfStringLengthIsValid(ingredient, IngredientNameMaxLength, IngredientNameMinLength, 
                    string.Format(EachIngredientNameSLengthShouldBeBetweenAndSymbolsInclusive, IngredientNameMinLength, IngredientNameMaxLength));
            }
        }

        public string Ingredients { get; private set; }

        public override string Print()
        {
            return base.Print() + string.Format("  * Ingredients: {0}", this.Ingredients);
        }
    }
}