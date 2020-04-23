using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PocketCook
{
    public class Recipe
    {
        public String recipeName;
        public String recipeDescription;
        public double price;
        public double calories;
        public double available;
        public Recipe(String recipeName, String recipeDescription, double price = 0, double calories = 0, double available=0)
        {
            this.recipeName = recipeName;
            this.recipeDescription = recipeDescription;
            this.price = price;
            this.calories = calories;
            this.available = available;
        }
        public Recipe(Dictionary<string, object> dict)
        {
            object temp;
            this.recipeName = dict.TryGetValue("recipeName", out temp) && temp.ToString() != "" ? (String)temp : "";
            this.recipeDescription = dict.TryGetValue("recipeDescription", out temp) && temp.ToString() != "" ? (String)temp : "";
            this.price = dict.TryGetValue("price", out temp) && temp.ToString() != "" ? (double)temp : 0;
            this.calories = dict.TryGetValue("calories", out temp) && temp.ToString() != "" ? (double)temp : 0;
            this.available = dict.TryGetValue("available", out temp) && temp.ToString() != "" ? (double)temp : 0;
        }

        public object[] all
        {
            get { return new object[] { recipeName, recipeDescription, calories, price, available }; }
            set
            {
                recipeName = (String)value[0];
                recipeDescription = (String)value[1];
                calories = (double)value[2];
                price = (double)value[3];
                available = (double)value[4];
                Program.db.editRecipe(this.recipeName, this.recipeDescription);
            }
        }

        public static List<Recipe> getSuitableRecipes(ref DataManager db)
        {
            var recipes = new List<Recipe>();
            Program.db.getSuitableRecipes().ForEach(dict =>
            {
                recipes.Add(new Recipe(dict));
            });
            return recipes;
        }

        public static void deleteRecipe(String recipeName)
        {
            Program.db.deleteRecipe(recipeName);
        }
    }

    public class Product
    {
        public String productName;
        public double price;
        public double calories;
        public Product(String productName, double price = 0, double calories = 0)
        {
            this.productName = productName;
            this.price = price;
            this.calories = calories;
        }
        public Product(Dictionary<string, object> dict)
        {
            object temp;
            this.productName = dict.TryGetValue("productName", out temp) ? (String)temp : "";
            this.price = dict.TryGetValue("price", out temp) ? (double)temp : 0;
            this.calories = dict.TryGetValue("calories", out temp) ? (double)temp : 0;
        }

        public object[] all
        {
            get { return new object[] { productName, price, calories }; }
            set
            {
                productName = (String)value[0];
                price = (double)value[1];
                calories = (double)value[2];
            }
        }

        public static List<Product> getProducts()
        {
            var products = new List<Product>();
            Program.db.getProducts().ForEach(dict =>
            {
                products.Add(new Product(dict));
            });
            return products;
        }

        public static Product editProduct(String productName, double price, double calories)
        {
            var product = new Product(productName, price, calories);
            Program.db.editProduct(productName, price, calories);
            return product;
        }

        public static Product addProduct(String productName, double price, double calories)
        {
            var product = new Product(productName, price, calories);
            Program.db.addProduct(productName, price, calories);
            return product;
        }

        public static void deleteProduct(String productName)
        {
            Program.db.deleteProduct(productName);
        }
    }

    /// <summary>
    /// Интерфейс менеджера данных для описания стандарта работы
    /// </summary>
    public interface DataManager
    {
        /// <summary>
        /// Метод должен возвращать список всех известных продуктов
        /// </summary>
        /// <returns>Список продуктов</returns>
        List<Dictionary<string, object>> getProducts();

        /// <summary>
        /// Метод должен возвращать списко имен продуктов
        /// </summary>
        /// <returns>Список имен продуктов</returns>
        List<String> getProductNames();

        /// <summary>
        /// Метод должен возвращать список продуктов, которые надо докупить для рецептов
        /// </summary>
        /// <param name="recipeNames">Список названий рецептов</param>
        /// <returns>Список необходимых продуктов</returns>
        List<Dictionary<string, object>> getMissingProducts(string[] recipeNames);

        /// <summary>
        /// Метод должен возвращать продукт по его имени, если продукта нет, выбрасывается исключение
        /// </summary>
        /// <param name="productName">Имя продукта для поиска</param>
        /// <returns>Найденный продукт</returns>
        Dictionary<string, object> getProduct(String productName);

        /// <summary>
        /// Метод должен добавлять продукт в базу данных. Если продукт с таким именем уже есть, то выбрасывается исключение
        /// </summary>
        /// <param name="productName">Имя нового продукта</param>
        /// <param name="calories">Количество калорий на 100г</param>
        /// <param name="price">Цена за 100г</param>
        /// <returns>Созданный продукт</returns>
        Dictionary<string, object> addProduct(String productName, double price, double calories);

        /// <summary>
        /// Метод должен удалять продукт из базы данных по имени
        /// </summary>
        /// <param name="productName">Имя продукта, который нужно удалить</param>
        void deleteProduct(String productName);

        /// <summary>
        /// Редактировать продукт, если продукта с таким именем нет, то выбрасывается исключение
        /// </summary>
        /// <param name="productName">Имя продута</param>
        /// <param name="calories">Количество калорий на 100г</param>
        /// <param name="price">Цена за 100г</param>
        /// <returns>Измененный продукт</returns>
        Dictionary<string, object> editProduct(String productName, double price, double calories);

        /// <summary>
        /// Метод должен возвращать список всех ИМЕЮЩИХСЯ В НАЛИЧИИ продуктов
        /// </summary>
        /// <returns>Список ИМЕЮЩИХСЯ В НАЛИЧИИ продуктов</returns>
        List<Dictionary<string, object>> getAvailableProducts();

        /// <summary>
        /// Метод должен возвращать ИМЕЮЩИЙСЯ В НАЛИЧИИ продукт по его имени, если продукта нет, выбрасывается исключение
        /// </summary>
        /// <param name="productName">Имя продукта для поиска</param>
        /// <returns>Найденный продукт</returns>
        Dictionary<string, object> getAvailableProduct(String productName);

        /// <summary>
        /// Метод должен добавлять информацию о наличии продукта, если добавляется неизвестный продукт, выбрасывается исключение
        /// </summary>
        /// <param name="productName">Имя продукта</param>
        /// <param name="quantity">Количество (г)</param>
        /// <returns>Добавленный продукт</returns>
        Dictionary<string, object> addAvailableProcuct(String productName, Double quantity);

        /// <summary>
        /// Метод должен удалять продукт из базы данных по имени
        /// </summary>
        /// <param name="productName">Имя продукта, который нужно удалить</param>
        void deleteAvailableProduct(String productName);

        /// <summary>
        /// Редактировать продукт, если продукта с таким именем нет в наличии или он неизвестный, то выбрасывается исключение
        /// </summary>
        /// <param name="productName">Имя продута</param>
        /// <param name="quantity">Количество (г)</param>
        /// <returns>Измененный продукт</returns>
        Dictionary<string, object> editAvailableProduct(String productName, Double quantity);

        /// <summary>
        /// Метод должен возвращать все известные рецепты
        /// </summary>
        /// <returns>Список рецептов</returns>
        List<Dictionary<string, object>> getRecipes();

        /// <summary>
        /// Метод должен возвращать ранджированный список рецептов, для которых есть хотя бы половина хотя бы одного продукта
        /// </summary>
        /// <returns>Ранджированный список рецептов</returns>
        List<Dictionary<string, object>> getSuitableRecipes();

        /// <summary>
        /// Метод должен возвращать рецепт по его имени с подсчетом суммарной стоимости и калорийности блюда
        /// </summary>
        /// <param name="recipeName"></param>
        /// <returns></returns>
        Dictionary<string, object> getRecipe(String recipeName);

        /// <summary>
        /// Метод должен позволять добавлять рецепт в базу данных
        /// </summary>
        /// <param name="recipeName">Имя нового рецепта</param>
        /// /// <param name="recipeDescription">Описание нового рецепта</param>
        /// <returns>Созданный рецепт</returns>
        Dictionary<string, object> addRecipe(String recipeName, String recipeDescription);

        /// <summary>
        /// Метод должен позволять изменять информацию о рецепте из базы данных, если рецепта нет, то выбрасывается исключение
        /// </summary>
        /// <param name="recipeName">Имя рецепта</param>
        /// <returns>Обновленный рецепт</returns>
        Dictionary<string, object> editRecipe(String recipeName, String recipeDescription);

        /// <summary>
        /// Метод должен позволять удалять рецепт по имени
        /// </summary>
        /// <param name="recipeName">Имя удаляемого рецепта</param>
        void deleteRecipe(String recipeName);

        /// <summary>
        /// Метод должен возвращать список необходимых для рецепта продуктов, если записей с этим рецептом нет, то выбрасывается исключение
        /// </summary>
        /// <param name="recipeName">Название рецепта</param>
        /// <returns>Список продуктов</returns>
        List<Dictionary<string, object>> getNecessaryProducts(String recipeName);

        /// <summary>
        /// Добавить информацию о необходимом продукте, если рецепта с таким названием нет, то выбрасывается исключение
        /// </summary>
        /// <param name="recipeName">Название рецепта</param>
        /// <param name="productName">Название продукта</param>
        /// <param name="quantity">Количество (г)</param>
        /// <returns>Созданную информацию о необходимом продукте</returns>
        List<Dictionary<string, object>> addNecessaryProduct(String recipeName, String productName, Double quantity);

        /// <summary>
        /// Редактировть информацию о необходимом продукте, если рецепта с таким названием нет, то выбрасывается исключение
        /// </summary>
        /// <param name="recipeName">Название рецепта</param>
        /// <param name="productName">Название продукта</param>
        /// <param name="quantity">Количество (г)</param>
        /// <returns>Обновленную информацию о необходимом продукте</returns>
        List<Dictionary<string, object>> editNecessaryProduct(String recipeName, String productName, Double quantity);

        /// <summary>
        /// Удалить информацию о необходимом в рецепте продукте
        /// </summary>
        /// <param name="recipeName">Название рецепта</param>
        /// <param name="productName">Название продукта</param>
        /// <returns></returns>
        void deleteNecessaryProduct(String recipeName, String productName);
    }

    /// <summary>
    /// Реализация интерфейса DataManager для работы с SQLite базой данных
    /// </summary>
    public class SQLiteDataManager : DataManager
    {
        private SQLiteConnection db;



        private void createProductTable()
        {
            var cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS product(productName VARCHAR(255), price DOUBLE NOT NULL CHECK(price>=0), calories DOUBLE NOT NULL CHECK(calories>=0), PRIMARY KEY(productName));", this.db);
            cmd.ExecuteNonQuery();
        }
        private void createAvailableProductTable()
        {
            var cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS available_product(productName VARCHAR(255), quantity DOUBLE NOT NULL CHECK(quantity>=0), PRIMARY KEY(productName), FOREIGN KEY(productName) REFERENCES product(productName));", this.db);
            cmd.ExecuteNonQuery();
        }
        private void createRecipeTable()
        {
            var cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS recipe(recipeName VARCHAR(255), recipeDescription TEXT NOT NULL, PRIMARY KEY(recipeName));", this.db);
            cmd.ExecuteNonQuery();
        }
        private void createNecessaryProductTable()
        {
            var cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS necessary_product(recipeName VARCHAR(255), productName VARCHAR(255), quantity DOUBLE NOT NULL CHECK(quantity>=0), PRIMARY KEY(productName, recipeName), FOREIGN KEY(productName) REFERENCES product(productName) ON DELETE RESTRICT, FOREIGN KEY(recipeName) REFERENCES recipe(recipeName) ON DELETE CASCADE);", this.db);
            cmd.ExecuteNonQuery();
        }



        public SQLiteDataManager(String dataBaseFilename = "db.sqlite")
        {
            if (!System.IO.File.Exists(dataBaseFilename))
            {
                SQLiteConnection.CreateFile(dataBaseFilename);
            }
            this.db = new SQLiteConnection("Data Source=" + dataBaseFilename);
            this.db.Open();
            var cmd = this.db.CreateCommand();
            cmd.CommandText = "PRAGMA foreign_keys=ON;";
            cmd.ExecuteNonQuery();
            this.createProductTable();
            this.createAvailableProductTable();
            this.createRecipeTable();
            this.createNecessaryProductTable();
        }



        public List<Dictionary<string, object>> getProducts()
        {
            
            var cmd = new SQLiteCommand("SELECT * FROM product;", this.db);
            var reader = cmd.ExecuteReader();
            var data = new List<Dictionary<string, object>>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.Add(Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue));
                }
            }
            
            return data;
        }
        public List<String> getProductNames()
        {

            var cmd = new SQLiteCommand("SELECT productName FROM product;", this.db);
            var reader = cmd.ExecuteReader();
            var data = new List<String>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.Add(reader.GetValue(0).ToString());
                }
            }

            return data;
        }
        public List<Dictionary<string, object>> getMissingProducts(string[] recipeNames)
        {
            var recipesString = "'" + String.Join("', '", recipeNames) + "'";
            var cmdText = "SELECT productName, needed, round((cast(price as real) / 100) * needed, 2) as price " +
                "FROM ( SELECT productName, SUM(quantity) AS needed " +
                "FROM (SELECT productName, SUM(quantity) AS quantity " +
                "FROM (RECIPE JOIN (NECESSARY_PRODUCT JOIN PRODUCT USING (productName)) NP " +
                "ON RECIPE.recipeName = NP.recipeName AND RECIPE.recipeName IN (" + recipesString + ")) " +
                "GROUP BY productName UNION SELECT productName, -quantity AS quantity FROM AVAILABLE_PRODUCT) " +
                "GROUP BY productName HAVING needed > 0 ) " +
                "JOIN PRODUCT USING(productName);";
            var cmd = new SQLiteCommand(cmdText, this.db);
            var reader = cmd.ExecuteReader();
            var data = new List<Dictionary<string, object>>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.Add(Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue));
                }
            }
            
            return data;
        }
        public Dictionary<string, object> getProduct(string productName)
        {
            
            var cmd = new SQLiteCommand("SELECT * FROM product WHERE productName=@productName;", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            var reader = cmd.ExecuteReader();
            var data = new Dictionary<string, object>();
            if (reader.HasRows)
            {
                reader.Read();
                data = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);
            }
            else
            {
                throw new Exception("There is no product with this name");
            }
            
            return data;
        }
        public Dictionary<string, object> addProduct(string productName, double price, double calories)
        {
            
            var cmd = new SQLiteCommand("INSERT INTO product VALUES(@productName, @price, @calories);", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@calories", calories);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch { }
            
            if (result != 1)
            {
                throw new Exception("Product with this name already exists");
            }
            return this.getProduct(productName);
        }
        public Dictionary<string, object> editProduct(string productName, double price, double calories)
        {
            
            var cmd = new SQLiteCommand("UPDATE product SET price=@price, calories=@calories WHERE productName=@productName;", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@calories", calories);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch { }
            
            if (result != 1)
            {
                throw new Exception("There is no product with this name");
            }
            return this.getProduct(productName);
        }
        public void deleteProduct(string productName)
        {
            
            var cmd = new SQLiteCommand("DELETE FROM product WHERE productName=@productName;", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.ExecuteNonQuery();
            
        }
        


        public List<Dictionary<string, object>> getRecipes()
        {
            
            var cmd = new SQLiteCommand("SELECT RECIPE.recipeName, RECIPE.recipeDescription,"
                + "round(sum((PRODUCT.price / 100) * NECESSARY_PRODUCT.quantity), 2) as price, "
                + "round(sum((PRODUCT.calories / 100) * NECESSARY_PRODUCT.quantity), 2) as colories "
                + "FROM RECIPE JOIN (NECESSARY_PRODUCT JOIN PRODUCT USING(productName)) USING(recipeName) "
                + "GROUP BY RECIPE.recipeName;", this.db);
            var reader = cmd.ExecuteReader();
            var data = new List<Dictionary<string, object>>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.Add(Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue));
                }
            }
            
            return data;
        }
        public List<Dictionary<string, object>> getSuitableRecipes()
        {
            
            var cmd = new SQLiteCommand("SELECT * FROM ( " +
                "SELECT RECIPE.recipeName, RECIPE.recipeDescription, " +
                "round(sum((PRODUCT.calories / 100) * NP.quantity), 2) as calories,  " +
                "round(sum((PRODUCT.price / 100) * NP.quantity), 2) as price, " +
                "round(cast(sum((ifnull((SELECT quantity FROM AVAILABLE_PRODUCT WHERE " +
                "AVAILABLE_PRODUCT.productName = NP.productName), 0) / NP.quantity) >= 0.5) AS REAL) / count(NP.productName), 2) AS available " +
                "FROM RECIPE JOIN (PRODUCT JOIN NECESSARY_PRODUCT " +
                "USING(productName)) NP USING(recipeName) GROUP BY RECIPE.recipeName " +
                "UNION " +
                "SELECT RECIPE.recipeName, RECIPE.recipeDescription, NULL AS colories,  " +
                "NULL AS price, NULL AS available " +
                "FROM RECIPE ORDER BY available DESC " +
                ") GROUP BY 1, 2 ORDER BY available DESC;", this.db);
            var reader = cmd.ExecuteReader();
            var data = new List<Dictionary<string, object>>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.Add(Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue));
                }
            }
            
            return data;
        }
        public Dictionary<string, object> getRecipe(string recipeName)
        {
            
            var cmd = new SQLiteCommand("SELECT RECIPE.recipeName, RECIPE.recipeDescription, " +
                "round(sum((PRODUCT.calories / 100) * NECESSARY_PRODUCT.quantity), 2) as calories, " +
                "round(sum((PRODUCT.price / 100) * NECESSARY_PRODUCT.quantity), 2) as price, " +
                "round(cast(sum((ifnull((SELECT quantity FROM AVAILABLE_PRODUCT WHERE " +
                "AVAILABLE_PRODUCT.productName = NP.productName), 0) / NP.quantity) >= 0.5) AS REAL) / count(NP.productName), 2) AS available " +
                "FROM RECIPE JOIN (NECESSARY_PRODUCT JOIN PRODUCT USING(productName)) NP USING(recipeName) " +
                "WHERE RECIPE.recipeName=@recipeName GROUP BY RECIPE.recipeName " +
                "UNION " +
                "SELECT RECIPE.recipeName, RECIPE.recipeDescription, " +
                "NULL AS calories, NULL AS price, NULL AS available " +
                "FROM RECIPE WHERE RECIPE.recipeName=@recipeName;", this.db);
            cmd.Parameters.AddWithValue("@recipeName", recipeName);
            var reader = cmd.ExecuteReader();
            var data = new Dictionary<string, object>();
            if (reader.HasRows)
            {
                reader.Read();
                data = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);
            }
            else
            {
                throw new Exception("There is no recipe with this name");
            }
            
            return data;
        }
        public Dictionary<string, object> addRecipe(string recipeName, string recipeDescription)
        {
            
            var cmd = new SQLiteCommand("INSERT INTO recipe VALUES(@productName, @recipeDescription);", this.db);
            cmd.Parameters.AddWithValue("@productName", recipeName);
            cmd.Parameters.AddWithValue("@recipeDescription", recipeDescription);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch { }
            
            if (result != 1)
            {
                throw new Exception("Recipe with this name already exists");
            }
            return this.getRecipe(recipeName);
        }
        public Dictionary<string, object> editRecipe(string recipeName, string recipeDescription)
        {
            
            var cmd = new SQLiteCommand("UPDATE recipe SET recipeDescription=@recipeDescription WHERE recipeName=@recipeName;", this.db);
            cmd.Parameters.AddWithValue("@recipeName", recipeName);
            cmd.Parameters.AddWithValue("@recipeDescription", recipeDescription);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch { }
            
            if (result != 1)
            {
                throw new Exception("There is no recipe with this name");
            }
            return this.getRecipe(recipeName);
        }
        public void deleteRecipe(string recipeName)
        {
            
            var cmd = new SQLiteCommand("DELETE FROM recipe WHERE recipeName=@recipeName;", this.db);
            cmd.Parameters.AddWithValue("@recipeName", recipeName);
            cmd.ExecuteNonQuery();
            
        }



        public List<Dictionary<string, object>> getAvailableProducts()
        {
            
            var cmd = new SQLiteCommand("SELECT * FROM available_product;", this.db);
            var reader = cmd.ExecuteReader();
            var data = new List<Dictionary<string, object>>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.Add(Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue));
                }
            }
            
            return data;
        }
        public Dictionary<string, object> getAvailableProduct(string productName)
        {
            
            var cmd = new SQLiteCommand("SELECT * FROM available_product WHERE productName=@productName;", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            var reader = cmd.ExecuteReader();
            var data = new Dictionary<string, object>();
            if (reader.HasRows)
            {
                reader.Read();
                data = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);
            }
            else
            {
                throw new Exception("There is no info about this product");
            }
            
            return data;
        }
        public Dictionary<string, object> addAvailableProcuct(string productName, double quantity)
        {
            
            var cmd = new SQLiteCommand("INSERT INTO available_product VALUES(@productName, @quantity);", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch { }
            
            if (result != 1)
            {
                throw new Exception("Info about this product already exists");
            }
            return this.getAvailableProduct(productName);
        }
        public Dictionary<string, object> editAvailableProduct(string productName, double quantity)
        {
            
            var cmd = new SQLiteCommand("UPDATE available_product SET quantity=@quantity WHERE productName=@productName;", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch { }
            
            if (result != 1)
            {
                throw new Exception("There is no info about this product");
            }
            return this.getAvailableProduct(productName);
        }
        public void deleteAvailableProduct(string productName)
        {
            
            var cmd = new SQLiteCommand("DELETE FROM available_product WHERE productName=@productName;", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.ExecuteNonQuery();
            
        }


        
        public List<Dictionary<string, object>> getNecessaryProducts(string recipeName)
        {
            
            var cmd = new SQLiteCommand("SELECT * FROM necessary_product WHERE recipeName=@recipeName;", this.db);
            cmd.Parameters.AddWithValue("@recipeName", recipeName);
            var reader = cmd.ExecuteReader();
            var data = new List<Dictionary<string, object>>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.Add(Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue));
                }
            }
            
            return data;
        }
        public List<Dictionary<string, object>> addNecessaryProduct(string recipeName, string productName, double quantity)
        {
            
            var cmd = new SQLiteCommand("INSERT INTO necessary_product VALUES(@recipeName, @productName, @quantity);", this.db);
            cmd.Parameters.AddWithValue("@recipeName", recipeName);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch { }
            
            if (result != 1)
            {
                throw new Exception("Info about this product in this recipe already exists");
            }
            return this.getNecessaryProducts(productName);
        }
        public List<Dictionary<string, object>> editNecessaryProduct(string recipeName, string productName, double quantity)
        {
            
            var cmd = new SQLiteCommand("UPDATE necessary_product SET quantity=@quantity WHERE productName=@productName AND recipeName=@recipeName;", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@recipeName", recipeName);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch { }
            
            if (result != 1)
            {
                throw new Exception("There is no info about this product");
            }
            return this.getNecessaryProducts(recipeName);
        }
        public void deleteNecessaryProduct(string recipeName, string productName)
        {
            
            var cmd = new SQLiteCommand("DELETE FROM necessary_product WHERE productName=@productName AND recipeName=@recipeName;", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@recipeName", recipeName);
            cmd.ExecuteNonQuery();
            
        }
    }
}
