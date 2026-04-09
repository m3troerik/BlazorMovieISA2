using Abc.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Infra;

public class MoniesRepo(AbcSoftMoviesContext c = null)
    : EfBaseRepo<AbcSoftMoviesContext, Money>(c), IMoniesRepo
{ }

public class CountryCurrenciesRepo(AbcSoftMoviesContext c = null)
    : EfBaseRepo<AbcSoftMoviesContext, CountryCurrency>(c), ICountryCurrenciesRepo
{ }
public class MoviesRepo(AbcSoftMoviesContext c = null)
    : EfBaseRepo<AbcSoftMoviesContext, Movie>(c), IMoviesRepo
{ }

public class CurrenciesRepo(AbcSoftMoviesContext c = null)
    : EfBaseRepo<AbcSoftMoviesContext, Currency>(c), ICurrenciesRepo
{ }

public class CountriesRepo(AbcSoftMoviesContext c = null)
    : EfBaseRepo<AbcSoftMoviesContext, Country>(c), ICountriesRepo
{ }
