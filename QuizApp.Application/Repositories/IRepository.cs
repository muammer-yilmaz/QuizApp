using Microsoft.EntityFrameworkCore;
using QuizApp.Domain.Common;

namespace QuizApp.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}
