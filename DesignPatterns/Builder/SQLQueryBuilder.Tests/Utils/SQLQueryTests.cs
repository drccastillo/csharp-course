using SQLQueryBuilder.Models;
using System;
using Xunit;

namespace SQLQueryBuilder.Tests.Utils
{
    public class SQLQueryTests
    {
        [Fact]
        public void ToSQL_WithoutSelectOrFrom_ThrowsInvalidOperationException()
        {
            var query = new SQLQuery();
            Assert.Throws<InvalidOperationException>(() => query.ToSQL());
        }

        [Fact]
        public void ToSQL_CompleteQuery_GeneratesCorrectSql()
        {
            var query = new SQLQuery();
            query.AddSelectField("col1");
            query.AddFromTable("tbl");
            query.SetWhere("col1 = 1");
            var sql = query.ToSQL();
            Assert.Contains("SELECT col1 FROM tbl WHERE col1 = 1", sql);
        }
    }
}