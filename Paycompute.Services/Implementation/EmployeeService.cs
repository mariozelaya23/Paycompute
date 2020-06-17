﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Serialization;
using Paycompute.Entity;
using Paycompute.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Paycompute.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private decimal SLRate;
        private decimal studentLoanAmount;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Employee newEmployee)
        {
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
        }

        public Employee GetById(int employeeId) => _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

        public async Task Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll() => _context.Employees;

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            var employee = GetById(id);
            if (employee.StudentLoan == StudentLoan.Yes && totalAmount > 0)
            {
                SLRate = .046m;
                studentLoanAmount = (totalAmount * SLRate);
            }
            else
            {
                studentLoanAmount = 0m;
            }
            return studentLoanAmount;
        }

        public decimal UnionFees(int id)
        {
            var employee = GetById(id);
            var fee = employee.UnionMember == UnionMember.Yes ? 10m : 0m;
            return fee;
        }

        public IEnumerable<SelectListItem> GetAllEmployeesForPayroll()
        {
            return GetAll().Select(emp => new SelectListItem()
            { 
                Text = emp.FullName,
                Value = emp.Id.ToString()
            });
        }
    }
}
