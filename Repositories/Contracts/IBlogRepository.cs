using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBlogRepository //Tüm blogların vt de işlem gördüğü interface
    {
        Task<List<Blog>> GetAllAsync();

        Task AddAsync(Blog blog);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Blog blog);


        //IEnumerable => sadece "bu verileri oku/listele" demiş oluruz. Veritabanından gelen saf listeyi korumuş oluruz.

        //Task, bir metodun sonucunun hemen değil, bir süre sonra (veritabanından veri gelince, bir dosya okununca vb.) döneceğini belirtir. Task, "gelecekte tamamlanacak bir işin temsilcisi veya sözüdür."

        //Task olan yerde genellikle bu iki anahtar kelimeyi görürsün:
        //async: Bir metodun içinde asenkron(beklemeli) işlemler yapılacağını belirtir.
        //await: "Burada bir Task var, bu iş bitene kadar bekle ama bu sırada işlemciyi kilitleme, git başka işleri hallet" komutudur.
    }
}
