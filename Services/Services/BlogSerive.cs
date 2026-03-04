using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BlogSerive : IBlogService
    {

        private readonly IBlogRepository repository;

        public BlogSerive(IBlogRepository repository)
        {
            this.repository = repository;
        }

        public Task Add(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Blog>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
