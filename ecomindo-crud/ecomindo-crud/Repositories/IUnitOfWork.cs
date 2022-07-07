using Microsoft.EntityFrameworkCore.Storage;
using ecomindo_crud.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ecomindo_crud.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Company> CompanyRepository { get; }
        IBaseRepository<Employee> EmployeeRepository { get; }
        void Save();
        Task SaveAsync(CancellationToken cancellationToken = default(CancellationToken));
        IDbContextTransaction StartNewTransaction();
        Task<IDbContextTransaction> StartNewTransactionAsync();
        Task<int> ExecuteSqlCommandAsync(string sql, object[] parameters, CancellationToken cancellationToken = default(CancellationToken));
    }
}
