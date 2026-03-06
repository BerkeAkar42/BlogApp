using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Services.BlogService
{
    public class BlogService : IBlogService
    {

        private readonly IBlogRepository _repository;

        public BlogService(IBlogRepository _repository)
        {
            this._repository = _repository;
        }



        public async Task Add(Blog blog)
        {

            // 1. Validasyonlar (Zeka Katmanı)
            if (string.IsNullOrWhiteSpace(blog.Title))
                throw new Exception("Lütfen başlık giriniz!");

            if (blog.Title.Length > 200)
                throw new Exception("Başlık 200 karakterden fazla olamaz!");

            if (string.IsNullOrWhiteSpace(blog.Description))
                throw new Exception("Lütfen açıklama giriniz!");

            if (blog.Description.Length > 500)
                throw new Exception("Açıklama 500 karakterden fazla olamaz!");


            // 2. Slug Üretimi
            var slug = GenerateSlug(blog.Title);

            if (!string.IsNullOrWhiteSpace(slug)) // Boş değilse ata!
                blog.Slug = slug;


            await _repository.AddAsync(blog);
        }



        //Frontent tarafında js ile slug otomatik oluşturulabilir.
        private string GenerateSlug(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return string.Empty;

            // 1. Küçük harfe çevir (İngilizce kültüre göre 'I' -> 'i' olması için Invariant kullanılır)
            string slug = title.ToLowerInvariant();

            // 2. Türkçe karakterleri İngilizce karşılıklarıyla değiştir
            slug = slug.Replace('ı', 'i')
                       .Replace('ğ', 'g')
                       .Replace('ü', 'u')
                       .Replace('ş', 's')
                       .Replace('ö', 'o')
                       .Replace('ç', 'c');

            // 3. Geçersiz karakterleri temizle (Regex: Sadece harf, rakam ve boşluk kalsın)
            // ?, *, :, !, @, # gibi tüm özel karakterleri bu satır temizler.
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");

            // 4. Boşlukları ve alt çizgileri tireye (-) çevir
            slug = Regex.Replace(slug, @"[\s_]+", "-");

            // 5. Birden fazla yan yana gelen tireyi teke indir (Örn: "test---slug" -> "test-slug")
            slug = Regex.Replace(slug, @"-+", "-");

            // 6. Başındaki ve sonundaki tireleri temizle
            return slug.Trim('-');

        }



        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<Blog>> GetAll()
        {
            //test API
            var blogs = await _repository.GetAllAsync();

            if (blogs is null)
                throw new Exception("Veriler Getirilirken Hata Oluştu!");

            return blogs;
        }


        public Task Update(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
