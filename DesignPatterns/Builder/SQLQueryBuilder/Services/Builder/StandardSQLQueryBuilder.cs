using System;
using System.Linq;
using SQLQueryBuilder.Interfaces;
using SQLQueryBuilder.Models;

namespace SQLQueryBuilder.Services.Builder;

public class StandardSQLQueryBuilder : SQLQueryBuilder
{
    public override ISQLQueryBuilder From(params string[] tables)
    {
        if (tables == null || tables.Length == 0)
            throw new ArgumentException("At least one table is required for FROM");

        foreach (var table in tables)
        {
            if (string.IsNullOrWhiteSpace(table))
                throw new ArgumentException("Table cannot be null or whitespace");

            _query.AddFromTable(table.Trim());
        }

        return this;
    }

    public override ISQLQueryBuilder GroupBy(params string[] fields)
    {
        if (fields == null || fields.Length == 0)
            throw new ArgumentException("At least one field is required for GROUP BY");

        foreach (var field in fields)
        {
            if (string.IsNullOrWhiteSpace(field))
                throw new ArgumentException("GroupBy field cannot be null or whitespace");

            _query.AddGroupByField(field.Trim());
        }

        return this;
    }

    public override ISQLQueryBuilder Having(string condition)
    {
        if (string.IsNullOrWhiteSpace(condition))
            throw new ArgumentException("HAVING condition cannot be null or whitespace");

        _query.SetHaving(condition.Trim());
        return this;
    }

    public override ISQLQueryBuilder Join(string joinClause)
    {
        if (string.IsNullOrWhiteSpace(joinClause))
            throw new ArgumentException("JOIN clause cannot be null or whitespace");

        _query.AddJoinClause(joinClause.Trim());
        return this;
    }

    public override ISQLQueryBuilder Limit(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Limit must be non-negative");

        _query.SetLimit(count);
        return this;
    }

    public override ISQLQueryBuilder OrderBy(params string[] fields)
    {
        if (fields == null || fields.Length == 0)
            throw new ArgumentException("At least one field is required for ORDER BY");

        foreach (var field in fields)
        {
            if (string.IsNullOrWhiteSpace(field))
                throw new ArgumentException("OrderBy field cannot be null or whitespace");

            _query.AddOrderByField(field.Trim());
        }

        return this;
    }

    public override ISQLQueryBuilder Select(params string[] fields)
    {
        if (fields == null || fields.Length == 0)
            throw new ArgumentException("At least one field is required for SELECT");

        foreach (var field in fields)
        {
            if (string.IsNullOrWhiteSpace(field))
                throw new ArgumentException("Field cannot be null or whitespace");

            _query.AddSelectField(field.Trim());
        }

        return this;
    }

    public override ISQLQueryBuilder Where(string condition)
    {
        if (string.IsNullOrWhiteSpace(condition))
            throw new ArgumentException("WHERE condition cannot be null or whitespace");

        _query.SetWhere(condition.Trim());
        return this;
    }
}