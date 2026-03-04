using Entities.Models;
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

        // var veriler = await depo.tümünüGetir();
        //Bu await, veriler gelene kadar bekle ve veriler e ata.

        public Task AddAsync(Blog blog)
        {
            //Burada sadece veritabanına veri ekleme (INSERT) kodu olacak
            throw new NotImplementedException();
        }

        public Task<List<Blog>> GetAllAsync()
        {
            //Burada sadece veritabanından veri çekme (SELECT) kodu olacak.
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            //Burada sadece veritabanından veri silme (DELETE) kodu olacak
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Blog blog)
        {
            //Burada sadece veritabanından veri güncelleme (UPDATE) kodu olacak
            throw new NotImplementedException();
        }

    }
}
