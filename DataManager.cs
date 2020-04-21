using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PocketCook
{
    /// <summary>
    /// Интерфейс менеджера данных для описания стандарта работы
    /// </summary>
    interface DataManager
    {
        /// <summary>
        /// Метод должен возвращать список всех известных продуктов
        /// </summary>
        /// <returns>Список продуктов</returns>
        List<Dictionary<string, object>> getProducts();

        /// <summary>
        /// Метод должен возвращать список продуктов, которые надо докупить для рецепта
        /// </summary>
        /// <param name="recipeName">Название рецепта</param>
        /// <returns>Список необходимых продуктов</returns>
        List<Dictionary<string, object>> getMissingProducts(string recipeName);

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
            var cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS product(productName VARCHAR(255), price DOUBLE NOT NULL CHECK(price>0), calories DOUBLE NOT NULL CHECK(calories>0), PRIMARY KEY(productName));", this.db);
            cmd.ExecuteNonQuery();
        }
        private void createAvailableProductTable()
        {
            var cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS available_product(productName VARCHAR(255), quantity DOUBLE NOT NULL CHECK(quantity>0), PRIMARY KEY(productName), FOREIGN KEY(productName) REFERENCES product(productName));", this.db);
            cmd.ExecuteNonQuery();
        }
        private void createRecipeTable()
        {
            var cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS recipe(recipeName VARCHAR(255), recipeDescription TEXT NOT NULL, PRIMARY KEY(recipeName));", this.db);
            cmd.ExecuteNonQuery();
        }
        private void createNecessaryProductTable()
        {
            var cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS necessary_product(recipeName VARCHAR(255), productName VARCHAR(255), quantity DOUBLE NOT NULL CHECK(quantity>0), PRIMARY KEY(productName, recipeName), FOREIGN KEY(productName) REFERENCES product(productName) ON DELETE RESTRICT, FOREIGN KEY(recipeName) REFERENCES recipe(recipeName) ON DELETE CASCADE);", this.db);
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
            this.createProductTable();
            this.createAvailableProductTable();
            this.createRecipeTable();
            this.createNecessaryProductTable();
            this.db.Close();
            var t = getMissingProducts("Цезарь");
            int a = 1;
        }



        public List<Dictionary<string, object>> getProducts()
        {
            this.db.Open();
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
            this.db.Close();
            return data;
        }
        public List<Dictionary<string, object>> getMissingProducts(string recipeName)
        {
            this.db.Open();
            var cmd = new SQLiteCommand("SELECT PR.productName, case when PR.quantity - IFNULL(AP.quantity, 0) > 0 then PR.quantity - IFNULL(AP.quantity, 0) else 0 end as needed "
                + "FROM (RECIPE JOIN (NECESSARY_PRODUCT JOIN PRODUCT USING (productName)) USING (recipeName)) PR LEFT JOIN AVAILABLE_PRODUCT AP "
                + "ON PR.productName = AP.productName WHERE PR.recipeName=@recipeName AND needed > 0;", this.db);
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
            this.db.Close();
            return data;
        }
        public Dictionary<string, object> getProduct(string productName)
        {
            this.db.Open();
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
            this.db.Close();
            return data;
        }
        public Dictionary<string, object> addProduct(string productName, double price, double calories)
        {
            this.db.Open();
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
            this.db.Close();
            if (result != 1)
            {
                throw new Exception("Product with this name already exists");
            }
            return this.getProduct(productName);
        }
        public Dictionary<string, object> editProduct(string productName, double price, double calories)
        {
            this.db.Open();
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
            this.db.Close();
            if (result != 1)
            {
                throw new Exception("There is no product with this name");
            }
            return this.getProduct(productName);
        }
        public void deleteProduct(string productName)
        {
            this.db.Open();
            var cmd = new SQLiteCommand("DELETE FROM product WHERE productName=@productName;", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.ExecuteNonQuery();
            this.db.Close();
        }
        


        public List<Dictionary<string, object>> getRecipes()
        {
            this.db.Open();
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
            this.db.Close();
            return data;
        }
        public List<Dictionary<string, object>> getSuitableRecipes()
        {
            this.db.Open();
            var cmd = new SQLiteCommand("SELECT RECIPE.recipeName, RECIPE.recipeDescription, "
                + "round(sum((PRODUCT.calories / 100) * NECESSARY_PRODUCT.quantity), 2) as colories, "
                + "round(sum((PRODUCT.price / 100) * NECESSARY_PRODUCT.quantity), 2) as price, "
                + "cast(sum((ifnull((SELECT quantity FROM AVAILABLE_PRODUCT WHERE AVAILABLE_PRODUCT.productName = NECESSARY_PRODUCT.productName), 0) / "
                + "NECESSARY_PRODUCT.quantity) >= 0.5) AS REAL) / count(NECESSARY_PRODUCT.productName) AS available "
                + "FROM RECIPE JOIN(NECESSARY_PRODUCT JOIN PRODUCT USING(productName)) USING(recipeName) "
                + "GROUP BY RECIPE.recipeName ORDER BY available DESC; ", this.db);
            var reader = cmd.ExecuteReader();
            var data = new List<Dictionary<string, object>>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.Add(Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue));
                }
            }
            this.db.Close();
            return data;
        }
        public Dictionary<string, object> getRecipe(string recipeName)
        {
            this.db.Open();
            var cmd = new SQLiteCommand("SELECT RECIPE.recipeName, RECIPE.recipeDescription,"
                + "round(sum((PRODUCT.price / 100) * NECESSARY_PRODUCT.quantity), 2) as price, "
                + "round(sum((PRODUCT.calories / 100) * NECESSARY_PRODUCT.quantity), 2) as colories "
                + "FROM RECIPE JOIN (NECESSARY_PRODUCT JOIN PRODUCT USING(productName)) USING(recipeName) "
                + "WHERE RECIPE.recipeName=@recipeName"
                + "GROUP BY RECIPE.recipeName;", this.db);
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
            this.db.Close();
            return data;
        }
        public Dictionary<string, object> addRecipe(string recipeName, string recipeDescription)
        {
            this.db.Open();
            var cmd = new SQLiteCommand("INSERT INTO recipe VALUES(@productName, @recipeDescription);", this.db);
            cmd.Parameters.AddWithValue("@productName", recipeName);
            cmd.Parameters.AddWithValue("@recipeDescription", recipeDescription);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch { }
            this.db.Close();
            if (result != 1)
            {
                throw new Exception("Recipe with this name already exists");
            }
            return this.getRecipe(recipeName);
        }
        public Dictionary<string, object> editRecipe(string recipeName, string recipeDescription)
        {
            this.db.Open();
            var cmd = new SQLiteCommand("UPDATE recipe SET recipeDescription=@recipeDescription WHERE recipeName=@recipeName;", this.db);
            cmd.Parameters.AddWithValue("@recipeName", recipeName);
            cmd.Parameters.AddWithValue("@recipeDescription", recipeDescription);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch { }
            this.db.Close();
            if (result != 1)
            {
                throw new Exception("There is no recipe with this name");
            }
            return this.getRecipe(recipeName);
        }
        public void deleteRecipe(string recipeName)
        {
            this.db.Open();
            var cmd = new SQLiteCommand("DELETE FROM recipe WHERE recipeName=@recipeName;", this.db);
            cmd.Parameters.AddWithValue("@recipeName", recipeName);
            cmd.ExecuteNonQuery();
            this.db.Close();
        }



        public List<Dictionary<string, object>> getAvailableProducts()
        {
            this.db.Open();
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
            this.db.Close();
            return data;
        }
        public Dictionary<string, object> getAvailableProduct(string productName)
        {
            this.db.Open();
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
            this.db.Close();
            return data;
        }
        public Dictionary<string, object> addAvailableProcuct(string productName, double quantity)
        {
            this.db.Open();
            var cmd = new SQLiteCommand("INSERT INTO available_product VALUES(@productName, @quantity);", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch { }
            this.db.Close();
            if (result != 1)
            {
                throw new Exception("Info about this product already exists");
            }
            return this.getAvailableProduct(productName);
        }
        public Dictionary<string, object> editAvailableProduct(string productName, double quantity)
        {
            this.db.Open();
            var cmd = new SQLiteCommand("UPDATE available_product SET quantity=@quantity WHERE productName=@productName;", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch { }
            this.db.Close();
            if (result != 1)
            {
                throw new Exception("There is no info about this product");
            }
            return this.getAvailableProduct(productName);
        }
        public void deleteAvailableProduct(string productName)
        {
            this.db.Open();
            var cmd = new SQLiteCommand("DELETE FROM available_product WHERE productName=@productName;", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.ExecuteNonQuery();
            this.db.Close();
        }


        
        public List<Dictionary<string, object>> getNecessaryProducts(string recipeName)
        {
            this.db.Open();
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
            this.db.Close();
            return data;
        }
        public List<Dictionary<string, object>> addNecessaryProduct(string recipeName, string productName, double quantity)
        {
            this.db.Open();
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
            this.db.Close();
            if (result != 1)
            {
                throw new Exception("Info about this product in this recipe already exists");
            }
            return this.getNecessaryProducts(productName);
        }
        public List<Dictionary<string, object>> editNecessaryProduct(string recipeName, string productName, double quantity)
        {
            this.db.Open();
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
            this.db.Close();
            if (result != 1)
            {
                throw new Exception("There is no info about this product");
            }
            return this.getNecessaryProducts(recipeName);
        }
        public void deleteNecessaryProduct(string recipeName, string productName)
        {
            this.db.Open();
            var cmd = new SQLiteCommand("DELETE FROM necessary_product WHERE productName=@productName AND recipeName=@recipeName;", this.db);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@recipeName", recipeName);
            cmd.ExecuteNonQuery();
            this.db.Close();
        }
    }
}
