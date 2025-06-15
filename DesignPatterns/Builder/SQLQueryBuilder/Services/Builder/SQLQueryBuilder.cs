using SQLQueryBuilder.Interfaces;
using SQLQueryBuilder.Models;

namespace SQLQueryBuilder.Services.Builder;

public abstract class SQLQueryBuilder : ISQLQueryBuilder
{
  protected SQLQuery _query = new();

  public void Reset()
  {
    _query = new SQLQuery();
  }

  public abstract ISQLQueryBuilder Select(params string[] fields);
  public abstract ISQLQueryBuilder From(params string[] tables);
  public abstract ISQLQueryBuilder Where(string condition);
  public abstract ISQLQueryBuilder Join(string joinClause);
  public abstract ISQLQueryBuilder GroupBy(params string[] fields);
  public abstract ISQLQueryBuilder Having(string condition);
  public abstract ISQLQueryBuilder OrderBy(params string[] fields);
  public abstract ISQLQueryBuilder Limit(int count);

  public SQLQuery Build()
  {
    var result = _query;
    Reset();

    return result;
  }
}