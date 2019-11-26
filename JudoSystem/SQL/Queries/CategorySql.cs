using Dapper;
using JudoSystem.Models;
using JudoSystem.Models.Dao;
using JudoSystem.SQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.SQL.Queries
{
    public class CategorySql : DataAccess, ICategorySql
    {
        public List<CategoryDao> getCategories()
        {
            List<CategoryDao> ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM categories";

                ret = db.Query<CategoryDao>(sql, commandType: CommandType.Text).ToList();
            }
            return ret;
        }
        public CategoryDao getCategoryById(int id)
        {
            CategoryDao ret;
            using (var db = getConnection())
            {
                const string sql = @"SELECT * FROM categories where id = @id";

                ret = db.Query<CategoryDao>(sql, new { id }, commandType: CommandType.Text).FirstOrDefault();
            }
            return ret;
        }
        public void insertCategory(CategoryDao newCategory)
        {
            using (var db = getConnection())
            {
                const string sql = @"INSERT INTO categories (Title, GroupID)
                                        VALUES (@Title, @GroupID)";

                db.Execute(sql, new
                {
                    newCategory.Title,
                    newCategory.GroupID
                },
                      commandType: CommandType.Text);
            }
        }
        public void updateCategory(CategoryDao newCategory)
        {
            using (var db = getConnection())
            {
                const string sql = @"UPDATE categories SET Title = @Title, GroupID = @GroupID WHERE id = @id";

                db.Execute(sql, new
                {
                    newCategory.Title,
                    newCategory.GroupID,
                    newCategory.Id,
                },
                    commandType: CommandType.Text);
            }
        }
        public void deleteCategory(int id)
        {
            using (var db = getConnection())
            {
                const string sql = @"DELETE FROM categories WHERE id = @id";

                db.Execute(sql, new { id }, commandType: CommandType.Text);
            }
        }
    }
}

