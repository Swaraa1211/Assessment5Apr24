using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment5Apr24
{
    internal class RecipeAssessment
    {
        public static void Main(string[] args)
        {

        }
    }
}


/*
Console.WriteLine("\t\tWelcome to Recipe Store!!");
            Console.WriteLine("\tPlenty of recipes are available here\n\n");

            //getChoice();


public static void Admin()
{
    int your_choice = 0;
    do
    {
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("\t\tYou wanna do what?: \n");
        Console.WriteLine("\t1. Good food, good mood\n\tBuild On Your Recipe and Put on Your Ingredients\n");
        Console.WriteLine("\t2. There You Go ->\n\tRevise Your Recipe\n");
        Console.WriteLine("\t3. OOPS! Some mistakes?! \n\tRewrite Ingredient");
        Console.WriteLine("\t4. Yummmyyyy Chase the Recipes\n");
        Console.WriteLine("\t5. Search");
        Console.WriteLine("\t6. Done? Take Out the Recipe\n");
        Console.WriteLine("\t7. Exit");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("");


        RecipeManager recipeManager = new RecipeManager();
        RecipeManager ingredientManager = new RecipeManager();

        Console.Write("So.... What's Your Choice?!?!........  ");
        your_choice = Convert.ToInt32(Console.ReadLine());
        switch (your_choice)
        {
            case 1:
                //Create Recipe 
                Console.Write("Title of the Recipe: ");
                string _title = Console.ReadLine();

                Console.Write("Description: ");
                string _description = Console.ReadLine();

                Console.Write("Price: ");
                int _price = Convert.ToInt32(Console.ReadLine());

                Recipe recipe = new Recipe
                {
                    Title = _title,
                    Description = _description,
                    Price = _price
                };

                recipeManager.CreateRecipe(recipe);
                Console.WriteLine("\n\t\tWohooo! Recipe created.\n");

                //Ingredient
                Console.Write("Name of the Ingredients: ");
                string _name = Console.ReadLine();

                Console.Write("Quantity: ");
                int _quantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Unit: ");
                string _unit = Console.ReadLine();

                Ingredient ingredient = new Ingredient
                {
                    Name = _name,
                    Quantity = _quantity,
                    Unit = _unit,
                    RecipeId = recipe.RecipeId
                };
                recipeManager.AddIngredient(ingredient);
                Console.WriteLine("\n\t\tDone! Ingredients Added.\n");
                break;

            case 2:
                //Edit Recipe
                Console.WriteLine("");
                recipeManager.GetAllRecipesWithIngredients();

                Console.Write("\nRecipeId Please!: ");
                int RecipeId = Convert.ToInt32(Console.ReadLine());
                Recipe retrievedRecipe = recipeManager.GetRecipe(RecipeId);

                Console.Write("Title of the Recipe: ");
                string _editTitle = Console.ReadLine();

                Console.Write("Description: ");
                string _editDescription = Console.ReadLine();

                Console.Write("Price: ");
                int _editPrice = Convert.ToInt32(Console.ReadLine());

                retrievedRecipe.Title = _editTitle;
                retrievedRecipe.Description = _editDescription;
                retrievedRecipe.Price = _editPrice;
                recipeManager.UpdateRecipe(retrievedRecipe);

                break;

            case 3:
                //Edit Ingredient
                Console.WriteLine("");
                recipeManager.GetAllRecipesWithIngredients();

                Console.Write("\nIngredientId Please!: ");

                int IngredientId = Convert.ToInt32(Console.ReadLine());
                Ingredient retrievedRecip1 = ingredientManager.GetIngredient(IngredientId);

                Console.Write("Name of the Ingredients: ");
                string _editName = Console.ReadLine();

                Console.Write("Quantity: ");
                int _editQuantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Unit: ");
                string _editUnit = Console.ReadLine();

                retrievedRecip1.Name = _editName;
                retrievedRecip1.Quantity = _editQuantity;
                retrievedRecip1.Unit = _editUnit;

                ingredientManager.UpdateIngredietnt(retrievedRecip1);
                break;
            case 4:
                //View All
                recipeManager.GetAllRecipesWithIngredients();
                break;

            case 5:
                //search
                string searchTerm = "YourSearchTerm";
                Recipe[] recipes = recipeManager.SearchRecipes(searchTerm);

                foreach (Recipe recipeList in recipes)
                {
                    //Console.WriteLine($"Recipe Id: {recipeList.RecipeId}");
                    Console.WriteLine($"Title: {recipeList.Title}");
                    Console.WriteLine($"Description: {recipeList.Description}");
                    Console.WriteLine($"Price: {recipeList.Price}");
                    Console.WriteLine("Ingredients:");

                    foreach (Ingredient ingredientList in recipeList.Ingredients)
                    {
                        //Console.WriteLine($"Ingredient Id: {ingredientList.IngredientId}");
                        Console.WriteLine($"Name: {ingredientList.Name}");
                        Console.WriteLine($"Quantity: {ingredientList.Quantity} {ingredientList.Unit}");
                    }

                    Console.WriteLine("-------------------------------------------");
                }
                break;

            case 6:
                //Delete Recipe
                Console.WriteLine("");
                Console.Write("\nRecipeId Please!: ");

                int RecipeIdToDelete = Convert.ToInt32(Console.ReadLine());
                recipeManager.DeleteRecipe(RecipeIdToDelete);

                Console.WriteLine("Recipe deleted.");
                break;

            case 7:
                Console.WriteLine("Thank You !");
                break;

            default:
                Console.WriteLine("Wrong Choice");
                break;
        }
    } while (your_choice != 7);
}
public static void User()
{

}
public static void login()
{
    string connectionString = "Data Source=5CG7324TYL;Initial Catalog = RecipeDB; Encrypt=False; Integrated Security=True;";
    //only for admin
    Console.Write("Username: ");
    string Username = Console.ReadLine();

    Console.WriteLine("");

    Console.Write("Password: ");
    string Password = Console.ReadLine();

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand("SELECT * FROM AdminTable", connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string _username = Convert.ToString(reader["Username"]);
                    if (Username == _username)
                    {
                        Admin();

                    }
                    else
                    {
                        User();
                    }
                }
            }


        }
    }

}
public static void quit()
{
    Console.WriteLine("Thank You!");
}
public static void validateChoice(int choice)
{
    switch (choice)
    {
        case 1:
            login();
            break;
        case 2:
            User();
            break;
        case 3:
            quit();
            break;
        default:
            Console.WriteLine("Invalid");
            getChoice();
            break;
    }
}
public static void getChoice()
{

    Console.WriteLine("\t Login");
    Console.WriteLine("\t Buy");
    Console.WriteLine("\t Quit");
    int your_choice = 0;

    your_choice = Convert.ToInt32(Console.ReadLine());
    validateChoice(your_choice);
}
*/

//Console.WriteLine("Hello, World!");

//DatabaseConnection connection = new DatabaseConnection();
//Recipe recipe1 = new Recipe
//{
//    Title = "Spaghetti Bolognese",
//    Description = "Classic Italian pasta dish with meat sauce"
//};
//RecipeManager recipeManager = new RecipeManager();
//recipeManager.CreateRecipe(recipe1);
//Console.WriteLine("Recipe created.");

//// Get a recipe by RecipeId
//Recipe retrievedRecipe = recipeManager.GetRecipe(recipe1.RecipeId);
//Console.WriteLine("Retrieved Recipe:");
//Console.WriteLine($"RecipeId: {retrievedRecipe.RecipeId}");
//Console.WriteLine($"Title: {retrievedRecipe.Title}");
//Console.WriteLine($"Description: {retrievedRecipe.Description}");

//// Update the recipe
//retrievedRecipe.Title = "Spaghetti Carbonara";
//retrievedRecipe.Description = "Italian pasta dish with eggs, cheese, pancetta, and pepper";
//recipeManager.UpdateRecipe(retrievedRecipe);

//// Get the updated recipe
//Recipe updatedRecipe = recipeManager.GetRecipe(recipe1.RecipeId);
//Console.WriteLine("Updated Recipe:");
//Console.WriteLine($"RecipeId: {updatedRecipe.RecipeId}");
//Console.WriteLine($"Title: {updatedRecipe.Title}");
//Console.WriteLine($"Description: {updatedRecipe.Description}");

// Delete the recipe
//recipeManager.DeleteRecipe(recipe1.RecipeId);
//Console.WriteLine("Recipe deleted.");