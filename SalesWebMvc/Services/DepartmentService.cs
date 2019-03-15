﻿using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //O código comentado é o método "FindAll" com chamada síncrona
        //public List<Department> FindAll()
        //{
        //    return _context.Department.OrderBy(x => x.Name).ToList();
        //}


        //abaixo temos o método "FindAll" com chamada assíncrona
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
