using JudoSystem.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.SQL.Interfaces
{
    public interface ICategorySql
    {
        List<CategoryDao> getCategories();
        CategoryDao getCategoryById(int id);
        void insertCategory(CategoryDao newCategory);
        void updateCategory(CategoryDao newCategory);
        void deleteCategory(int id);
    }
}
