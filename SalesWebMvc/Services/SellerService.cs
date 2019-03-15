using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //O código comentado é o método "FindAll" com chamada síncrona
        //public List<Seller> FindAll()
        //{
        //    return _context.Seller.ToList();
        //}


        //abaixo temos o método "FindAll" com chamada assíncrona
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        //abaixo temos o método "Insert" com chamada assíncrona
        public async Task InsertAsync (Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        
        //abaixo temos o método "FindAllById" com chamada assíncrona
        public async Task<Seller> FindByIdAsync(int id)
        {   
            //a função "Include" faz a junção (join) entre duas tabelas
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        //abaixo temos o método "Remove" com chamada assíncrona
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        
    }
}