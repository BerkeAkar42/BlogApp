using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBlogService
    {
        // Task çağıran bir metotun kendisi de task olmak zorundadır. Mantık şu, biri bana bir not verecek ama o not bana gelmeden ben sana not veremem bekliyorum demek gibi bir şeydir.
        public Task<IEnumerable<Blog>> GetAll();
        public Task Add(Blog blog);
        public Task Update(Blog blog);
        public Task Delete(Guid id);
    }
}
