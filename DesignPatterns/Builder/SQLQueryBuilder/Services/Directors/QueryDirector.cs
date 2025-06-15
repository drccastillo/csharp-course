using SQLQueryBuilder.Interfaces;
using SQLQueryBuilder.Models;

namespace SQLQueryBuilder.Services.Directors;

public class QueryDirector(ISQLQueryBuilder builder)
{
  private readonly ISQLQueryBuilder _builder = builder ?? throw new ArgumentNullException(nameof(builder));

  public SQLQuery BuildUserListQuery()
  {
    return _builder
      .Select("u.id", "u.username", "u.email", "p.first_name")
      .From("users u")
      .Join("INNER JOIN profiles p ON u.id = p.user_id")
      .Where("u.is_active = 1")
      .OrderBy("u.username ASC")
      .Build();
  }
}