using Abc.Data;
using Abc.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Infra;

public interface IRepo<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetAsync(int id);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity> CreateAsync(TEntity e);
    Task<TEntity> UpdateAsync(TEntity e);
    Task DeleteAsync(int id);
}
public interface IMoviesRepo : IRepo<Movie> { }

public interface ICountriesRepo : IRepo<Country> { }

public interface ICurrenciesRepo : IRepo<Currency> { }
public interface IMoniesRepo : IRepo<Money> { }

public interface ICountryCurrenciesRepo : IRepo<CountryCurrency> { }