using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    // Katmanlar arası çoğunlukla Loosely Coupled bir bağlantı tercih ederiz ki bağımlılıkları en aza indirgiyebilelim.
    // Önceki git commit'inde IoC çerçevesinde service kayıtlarımızı gerçekleştirmiş olmamıza rağmen, farklı bir yaklaşım görmek adına;
    // Repository gibi kaynak tüketiminin yoğun olacağını düşündüğümüz nesnelerin instance'larının oluşturulması aşamasında
    // Lazy Loading yaklaşımından yararlanabiliriz.
    // Bu yaklaşımda her ne kadar istemesekte katmanlar arası Tightly Coupled bir bağlantı kuruyoruz.
    public class RepositoryManager : IRepositoryService
    {
        private readonly RepositoryContext _context;

        private readonly Lazy<IProjectRepository> _projectRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            // Lazy Loading yaklaşımı sayesinde RepositoryManager nesnesinin instance'ı alındığıda 'Lazy' sınıfı ile çevrelenmiş nesnelerimizin direk olarak
            // instance'ları üretilmez.
            _projectRepository = new Lazy<IProjectRepository>(() => new ProjectRepository(context));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(context));
        }

        // 'Lazy' sınıfı ile çevrelenmiş nesnelerimizin instance'ları, onlara ne zaman ulaşılmak istenirse o zaman oluşturulurlar.
        public IProjectRepository Project => _projectRepository.Value;
        public IEmployeeRepository Employee => _employeeRepository.Value;

        public void Save() => _context.SaveChanges();

    }
}
