using System;
using SQLQueryBuilder.Models;
using SQLQueryBuilder.Services.Builder;
using Xunit;

namespace SQLQueryBuilder.Tests.Services
{
    public class StandardSQLQueryBuilderTests
    {
        [Fact]
        public void Select_WithValidFields_BuildsSelectClause()
        {
            var builder = new StandardSQLQueryBuilder();
            var query = builder.Select("a", "b").From("t").Build();
            Assert.Equal(new[] { "a", "b" }, query.SelectFields);
        }

        [Fact]
        public void Select_WithNoFields_ThrowsArgumentException()
        {
            var builder = new StandardSQLQueryBuilder();
            Assert.Throws<ArgumentException>(() => builder.Select().Build());
        }

        [Fact]
        public void From_WithValidTable_BuildsFromClause()
        {
            var builder = new StandardSQLQueryBuilder();
            var query = builder.Select("col").From("table").Build();
            Assert.Equal(new[] { "table" }, query.FromTables);
        }

        [Fact]
        public void From_WithNoTables_ThrowsArgumentException()
        {
            var builder = new StandardSQLQueryBuilder();
            Assert.Throws<ArgumentException>(() => builder.Select("col").From().Build());
        }

        [Fact]
        public void BuildUserListQuery_ReturnsExpectedSql()
        {
            var builder = new StandardSQLQueryBuilder();
            var director = new SQLQueryBuilder.Services.Directors.QueryDirector(builder);
            var query = director.BuildUserListQuery();
            var expected = "SELECT u.id, u.username, u.email, p.first_name FROM users u INNER JOIN profiles p ON u.id = p.user_id WHERE u.is_active = 1 ORDER BY u.username ASC";
            Assert.Equal(expected, query.ToSQL());
        }
    }
}