﻿using Entities.Models;

namespace Repository.Extensions
{
    public static class RepositoryEmployeeExtensions
    {
        public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee> query, uint minAge, uint maxAge)
        {
            return query.Where(e => minAge <= e.Age && e.Age <= maxAge);
        }

        public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return employees;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return employees.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
