using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using WebApiFinanc.Context;
using WebApiFinanc.Models;
using WebApiFinanc.Repositories.Default;

namespace WebApiFinanc.Repositories.GastoRepository_
{
    public class GastosRepository : IGastosRepository
    {
        private readonly AppDbContext _context;
        public GastosRepository(AppDbContext context) 
        {
            _context = context;
        }

        public IEnumerable<Gastos> Get()
        {
            return _context.Gastos.AsNoTracking().ToList();
        }

        public Gastos? GetObjects(Expression<Func<Gastos, bool>> predicate)
        {
            return _context.Gastos.AsNoTracking().FirstOrDefault(predicate);
        }
    }
}
