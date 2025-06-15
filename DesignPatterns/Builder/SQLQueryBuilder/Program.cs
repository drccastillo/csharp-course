using SQLQueryBuilder.Services.Builder;
using SQLQueryBuilder.Services.Directors;

// Demonstrate the Builder pattern for constructing SQL queries
var builder = new StandardSQLQueryBuilder();
var director = new QueryDirector(builder);
var query = director.BuildUserListQuery();

Console.WriteLine("Generated Query:");
Console.WriteLine(query.ToSQL());
