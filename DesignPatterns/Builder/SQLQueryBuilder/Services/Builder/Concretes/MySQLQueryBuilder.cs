using SQLQueryBuilder.Interfaces;
using SQLQueryBuilder.Services.Builder;

namespace SQLQueryBuilder.Services.Builder.Concretes;

public class MySQLQueryBuilder : StandardSQLQueryBuilder
{
  public ISQLQueryBuilder LeftJoin(string table, string condition)
  {
    return Join($"LEFT JOIN {table} ON {condition}");
  }

  public ISQLQueryBuilder RightJoin(string table, string condition)
  {
    return Join($"RIGHT JOIN {table} ON {condition}");
  }

  public ISQLQueryBuilder InnerJoin(string table, string condition)
  {
    return Join($"INNER JOIN {table} ON {condition}");
  }
}