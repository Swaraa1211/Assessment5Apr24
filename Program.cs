using Assessment5Apr24;
using Microsoft.Data.SqlClient;

namespace Assessment5Apr24
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string? Name { get; set; }
        public decimal Quantity { get; set; }
        public string? Unit { get; set; }
        public int RecipeId { get; set; }
    }
    public class RecipeManager
    {
        public string connectionString = "Data Source=5CG7324TYL;Initial Catalog = RecipeDB; Encrypt=False; Integrated Security=True;";

        public void GetAllRecipesWithIngredients()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Recipe; SELECT * FROM Ingredient;", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Recipes:");
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe
                            {
                                RecipeId = Convert.ToInt32(reader["RecipeId"]),
                                Title = Convert.ToString(reader["Title"]),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Description = Convert.ToString(reader["Description"])
                            };

                            Console.WriteLine($"RecipeId: {recipe.RecipeId}, Title: {recipe.Title}, Description: {recipe.Description}, Price {recipe.Price}");
                        }

                        Console.WriteLine("\nIngredients:");
                        while (reader.Read())
                        {
                            Ingredient ingredient = new Ingredient
                            {
                                IngredientId = Convert.ToInt32(reader["IngredientId"]),
                                Name = Convert.ToString(reader["Name"]),
                                Quantity = Convert.ToDecimal(reader["Quantity"]),
                                Unit = Convert.ToString(reader["Unit"]),
                                RecipeId = Convert.ToInt32(reader["RecipeId"])
                            };

                            Console.WriteLine($"IngredientId: {ingredient.IngredientId}, Name: {ingredient.Name}, Quantity: {ingredient.Quantity}, Unit: {ingredient.Unit}, RecipeId: {ingredient.RecipeId}");
                        }
                    }
                }
            }
        }
        public void CreateRecipe(Recipe recipe)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Recipe (Title, Description, Price) VALUES (@Title, @Description, @Price); SELECT SCOPE_IDENTITY();", connection))
                {
                    command.Parameters.AddWithValue("@Title", recipe.Title);
                    command.Parameters.AddWithValue("@Description", recipe.Description);
                    command.Parameters.AddWithValue("@Price", recipe.Price);
                    recipe.RecipeId = Convert.ToInt32(command.ExecuteScalar());
                }
                
            }
        }
        public void AddIngredient(Ingredient ingredient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Ingredient (Name, Quantity, Unit,RecipeId) VALUES (@Name, @Quantity, @Unit,@RecipeId); SELECT SCOPE_IDENTITY();", connection))
                {
                    command.Parameters.AddWithValue("@Name", ingredient.Name);
                    command.Parameters.AddWithValue("@Quantity", ingredient.Quantity);
                    command.Parameters.AddWithValue("@Unit", ingredient.Unit);
                    command.Parameters.AddWithValue("@RecipeId", ingredient.RecipeId);
                    ingredient.RecipeId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        public Recipe GetRecipe(int recipeId)
        {
            Recipe recipe = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Recipe WHERE RecipeId = @RecipeId", connection))
                {
                    command.Parameters.AddWithValue("@RecipeId", recipeId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            recipe = new Recipe
                            {
                                RecipeId = Convert.ToInt32(reader["RecipeId"]),
                                Title = Convert.ToString(reader["Title"]),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Description = Convert.ToString(reader["Description"])
                            };
                        }
                    }
                }
            }
            return recipe;
        }
        public Ingredient GetIngredient(int recipeId)
        {
            Ingredient ingredient = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Ingredient WHERE RecipeId = @RecipeId", connection))
                {
                    command.Parameters.AddWithValue("@RecipeId", recipeId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ingredient = new Ingredient
                            {
                                IngredientId = Convert.ToInt32(reader["IngredientId"]),
                                Name = Convert.ToString(reader["Name"]),
                                Quantity = Convert.ToDecimal(reader["Quantity"]),
                                Unit = Convert.ToString(reader["Unit"]),
                                RecipeId = Convert.ToInt32(reader["RecipeId"])
                            };
                        }

                    }

                }
            }
            return ingredient;
        }
        public string UpdateRecipe(Recipe recipe)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Recipe SET Title = @Title, Description = @Description, @Price = Price WHERE RecipeId = @RecipeId", connection))
                {
                    command.Parameters.AddWithValue("@Title", recipe.Title);
                    command.Parameters.AddWithValue("@Description", recipe.Description);
                    command.Parameters.AddWithValue("@Price", recipe.Price);
                    command.Parameters.AddWithValue("@RecipeId", recipe.RecipeId);
                    command.ExecuteNonQuery();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return "Updated";
                    }
                    else
                    {
                        return "Id not available";

                    }
                }
            }
        }
        public string UpdateIngredietnt(Ingredient ingredient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Ingredient SET Name = @Name, Quantity = @Quantity, Unit = @Unit WHERE IngredientId = @IngredientId", connection))
                {
                    command.Parameters.AddWithValue("@IngredientId", ingredient.IngredientId);
                    command.Parameters.AddWithValue("@Name", ingredient.Name);
                    command.Parameters.AddWithValue("@Quantity", ingredient.Quantity);
                    command.Parameters.AddWithValue("@Unit", ingredient.Unit);
                    command.Parameters.AddWithValue("@RecipeId", ingredient.RecipeId);
                    command.ExecuteNonQuery();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return "Updated!";
                    }
                    else
                    {
                        return "Id not available";

                    }
                }
            }
        }
        public string DeleteRecipe(int recipeId)
        {
            try { 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Recipe WHERE RecipeId = @RecipeId", connection))
                {
                    command.Parameters.AddWithValue("@RecipeId", recipeId);
                    int rowsAffected = command.ExecuteNonQuery();
                        if(rowsAffected > 0)
                        {
                            return "Deleted";
                        }
                        else
                        {
                            return "Id not available";

                        }
                }
            }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
        public Recipe[] SearchRecipes(string searchTerm)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Recipe WHERE Title LIKE @SearchTerm OR Description LIKE @SearchTerm", connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe
                            {
                                RecipeId = Convert.ToInt32(reader["RecipeId"]),
                                Title = Convert.ToString(reader["Title"]),
                                Description = Convert.ToString(reader["Description"]),
                                Price = Convert.ToDecimal(reader["Price"])
                            };

                            recipes.Add(recipe); 
                        }
                    }
                }
            }
            return recipes.ToArray(); 
        }

    }
    internal class Program
    {
        public static void AddRecipe()
        {
           
            RecipeManager recipeManager = new RecipeManager();
            try
            {
                //recipe
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
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void EditRecipe()
        {
            RecipeManager recipeManager = new RecipeManager();
            RecipeManager ingredientManager = new RecipeManager();
            try
            {
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
                string updated = recipeManager.UpdateRecipe(retrievedRecipe);
                Console.WriteLine(updated);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void EditIngredient()
        {
            RecipeManager recipeManager = new RecipeManager();
            RecipeManager ingredientManager = new RecipeManager();

            try
            {
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

                string updated = ingredientManager.UpdateIngredietnt(retrievedRecip1);
                Console.WriteLine(updated);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Search()
        {
            RecipeManager recipeManager = new RecipeManager();
            RecipeManager ingredientManager = new RecipeManager();
            try
            {
                Console.Write("Search Item: ");
                string searchTerm = Console.ReadLine();
                Recipe[] recipes = recipeManager.SearchRecipes(searchTerm);

                foreach (Recipe recipeList in recipes)
                {
                    //Console.WriteLine($"Recipe Id: {recipeList.RecipeId}");
                    Console.WriteLine($"Title: {recipeList.Title}");
                    Console.WriteLine($"Description: {recipeList.Description}");
                    Console.WriteLine($"Price: {recipeList.Price}");

                    Console.WriteLine("-------------------------------------------");
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);

            }
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("\t\tWelcome to Recipe Store!!");
            Console.WriteLine("\tPlenty of recipes are available here\n");

            int your_choice = 0;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("\t\tYou wanna do what?: \n");
                Console.WriteLine("\t1. Good food, good mood\n\tBuild On Your Recipe and Put on Your Ingredients\n");
                Console.WriteLine("\t2. There You Go ->\n\tRevise Your Recipe\n");
                Console.WriteLine("\t3. OOPS! Some mistakes?! \n\tRewrite Ingredient\n");
                Console.WriteLine("\t4. Yummmyyyy Chase the Recipes\n");
                Console.WriteLine("\t5. Search\n");
                Console.WriteLine("\t6. Done? Take Out the Recipe\n");
                Console.WriteLine("\t7. Exit");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");

                RecipeManager recipeManager = new RecipeManager();

                Console.Write("So.... What's Your Choice?!?!........  ");
                your_choice = Convert.ToInt32(Console.ReadLine());
                switch (your_choice)
                {
                    case 1:
                        //Create Recipe 
                        AddRecipe();
                        break;

                    case 2:
                        //Edit Recipe
                        EditRecipe();
                        break;

                    case 3:
                        //Edit Ingredient
                        EditIngredient();
                        break;
                    case 4:
                        //View All
                        recipeManager.GetAllRecipesWithIngredients();
                        break;

                    case 5:
                        //search
                        Search();
                        break;

                    case 6:
                        //Delete Recipe
                        try
                        {
                            Console.WriteLine("");
                            Console.Write("\nRecipeId Please!: ");

                            int RecipeIdToDelete = Convert.ToInt32(Console.ReadLine());
                            string deleted = recipeManager.DeleteRecipe(RecipeIdToDelete);

                            Console.WriteLine(deleted);
                        } catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 7:
                        Console.WriteLine("Thank You !");
                        break;

                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }
            } while (your_choice != 7);


            //Console.ReadLine();

        }
    }
   
}
