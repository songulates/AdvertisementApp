using CommonLayer.Enums;
using DataAccesLayer.Context;
using DataAccesLayer.Interfaces;
using EntitiesLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    //burdaki T entity
    public class Repository<T>:IRepository<T> where T:BaseEntity
        //yine T tipi olacak Irepositoryden implement olacak. Yine T titpi ve burdaki T tipi Bir baseentitydir diycez 
    {
        //bir context alcaz private ile sonra ctro
        private readonly AdvertisementContext _context;
        //contexti uow la. uowden bana context gönderilecek.ctor dependeciy ile ayağa kalkmayacak.
        //uow de dependenciy injection ile ayağa kaldırcaz contexi . sonra repositorye vercez
        public Repository(AdvertisementContext context)
        {
            _context = context;
        }
        //burda metodları yazalım
        //getall bütün veriyi getirme,sıralayarak,filtre ile(bütün veri geliyorsa bu asnotracking)
       public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
            //geriye task dönmemesi için await diyoruz
        }
        //veriyi filtre ile getirme
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }
        //commonuniçine enum ekle
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _context.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync() : await _context.Set<T>().AsNoTracking().OrderByDescending(selector).ToListAsync();
        }
        //hem filtre hem sıralama
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _context.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync() : await _context.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync();
        }
        public async Task<T> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
       

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) : await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            //savechanges kullanmayoz
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        //update async değil void de
        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
