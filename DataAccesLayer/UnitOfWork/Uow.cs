using DataAccesLayer.Context;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Repositories;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.UnitOfWork
{
    public class Uow:IUow
    {
        private readonly AdvertisementContext _context;
        //İLGİLİ REPOSİTORYLERİ tek bir contextle ilgili requeste gittiğinden emin olmak

        public Uow(AdvertisementContext context)
        {
            _context = context;
        }
        //IRepository dönen metod yazıyoruz. herhangi bir T tipinden GetRepository adında bir method yazıyoduk.
       
        //generic bir medot olduğu  için T yi belirt. T aslında baseentiy. return ile repository dön.T cinsinden
        
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            //burdaki dependenciy injection ile ayağa kalkan conetxi buraya yazıyoruz.Repositoryde DI yok burdaki örneği-
            // contexi repositorye dönüyor
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
