using Company.G02.BLL.Interfaces;
using Company.G02.DAL.Data.Contexts;
using Company.G02.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G02.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        //private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context) : base(context) // Ask the CLR to create object from AppDbContext
        {
            //_context = context;
        }
        //public IEnumerable<Employee> GetAll()
        //{
        //    return _context.Employees.ToList();
        //}

        //public Employee Get(int id)
        //{
        //    return _context.Employees.Find(id);
        //}

        //public int Add(Employee entity)
        //{
        //     _context.Employees.Add(entity);
        //    return _context.SaveChanges();
        //}

        //public int Update(Employee entity)
        //{
        //    _context.Employees.Update(entity);
        //    return _context.SaveChanges();
        //}

        //public int Delete(Employee entity)
        //{
        //    _context.Employees.Remove(entity);
        //    return _context.SaveChanges();
        //}

       

        
    }
}
