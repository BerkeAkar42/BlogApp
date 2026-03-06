using Dapper;
using Entities.Models;
using Microsoft.Data.SqlClient;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Dapper
{
    public class BlogRepository : IBlogRepository
    {
        private readonly string _connectionString;

        public BlogRepository(string connectionString)
        {
            _connectionString = connectionString;
        }



        // var veriler = await depo.tümünüGetir();
        //Bu await, veriler gelene kadar bekle ve veriler e ata.



        // INSERT: Yeni blog ekleme
        public async Task AddAsync(Blog blog)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string sql = @"INSERT INTO Blog (BlogId, Title, Description, Content, ImageUrl, CategoryId, CreateDate, Slug, IsPublished) VALUES (@BlogId, @Title, @Description, Content, @ImageUrl, @CategoryId, @CreateDate, @Slug, @IsPublished)";


                // Dapper, 'blog' nesnesindeki property isimlerini otomatik olarak '@' parametreleriyle eşleştirir.
                await connection.ExecuteAsync(sql,blog);
            }
        }




        // SELECT: Tüm blogları listeleme
        public async Task<List<Blog>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT * FROM Blog";

                // QueryAsync IEnumerable döner, biz List istediğimiz için ToList() yapıyoruz.
                var blogs = await connection.QueryAsync<Blog>(sql);
                return blogs.ToList();
            }
        }



        // DELETE: ID'ye göre silme
        public async Task DeleteAsync(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string sql = @"DELETE FROM Blog WHERE BlogId = @id";
                await connection.ExecuteAsync(sql, new { id });
            }
        }



        // UPDATE: Veri güncelleme
        public async Task UpdateAsync(Blog blog)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string sql = @"UPDATE Blog SET Title = @Title, Description = @Description, ImageUrl = @ImageUrl, CategoryId = @CategoryId, Slug = @Slug, IsPublished = @IsPublished WHERE BlogId = @BlogId";

                //Dapper burada otomatik eşleme yapacak.
                await connection.ExecuteAsync(sql, blog);
            }
        }

    }
}
