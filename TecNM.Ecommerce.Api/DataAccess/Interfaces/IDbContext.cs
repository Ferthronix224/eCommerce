using System.Data.Common;

namespace TecNM.Ecommerce.Api.DataAccess.Interfaces;

public interface IDbContext
{
    DbConnection Connection { get; }
}