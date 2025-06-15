using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLQueryBuilder.Models
{
    public class SQLQuery
    {
        private readonly List<string> _selectFields = new();
        private readonly List<string> _fromTables = new();
        private readonly List<string> _joinClauses = new();
        private readonly List<string> _groupByFields = new();
        private readonly List<string> _orderByFields = new();
        private string? _whereClause;
        private string? _havingClause;
        private int? _limitClause;
        private bool _isDistinct;

        public IReadOnlyList<string> SelectFields => _selectFields;
        public IReadOnlyList<string> FromTables => _fromTables;
        public IReadOnlyList<string> JoinClauses => _joinClauses;
        public IReadOnlyList<string> GroupByFields => _groupByFields;
        public IReadOnlyList<string> OrderByFields => _orderByFields;
        public string? WhereClause => _whereClause;
        public string? HavingClause => _havingClause;
        public int? LimitClause => _limitClause;
        public bool IsDistinct => _isDistinct;

        public void AddSelectField(string field) => _selectFields.Add(field);
        public void AddFromTable(string table) => _fromTables.Add(table);
        public void AddJoinClause(string joinClause) => _joinClauses.Add(joinClause);
        public void SetWhere(string condition) => _whereClause = condition;
        public void AddGroupByField(string field) => _groupByFields.Add(field);
        public void SetHaving(string condition) => _havingClause = condition;
        public void AddOrderByField(string field) => _orderByFields.Add(field);
        public void SetLimit(int limit) => _limitClause = limit;
        public void SetDistinct(bool distinct) => _isDistinct = distinct;

        public bool IsQueryValid()
        {
            return _selectFields.Any() && _fromTables.Any();
        }

        public override string ToString() => ToSQL();

        public string ToSQL()
        {
            if (!IsQueryValid())
                throw new InvalidOperationException("Query must have at least SELECT fields and FROM tables.");

            var sb = new System.Text.StringBuilder();
            sb.Append("SELECT ");
            if (_isDistinct)
                sb.Append("DISTINCT ");
            sb.Append(string.Join(", ", _selectFields));
            sb.Append(" FROM ");
            sb.Append(string.Join(", ", _fromTables));

            if (_joinClauses.Any())
            {
                sb.Append(" ");
                sb.Append(string.Join(" ", _joinClauses));
            }

            if (!string.IsNullOrWhiteSpace(_whereClause))
            {
                sb.Append(" WHERE ");
                sb.Append(_whereClause);
            }

            if (_groupByFields.Any())
            {
                sb.Append(" GROUP BY ");
                sb.Append(string.Join(", ", _groupByFields));
            }

            if (!string.IsNullOrWhiteSpace(_havingClause))
            {
                sb.Append(" HAVING ");
                sb.Append(_havingClause);
            }

            if (_orderByFields.Any())
            {
                sb.Append(" ORDER BY ");
                sb.Append(string.Join(", ", _orderByFields));
            }

            if (_limitClause.HasValue)
            {
                sb.Append(" LIMIT ");
                sb.Append(_limitClause.Value);
            }

            return sb.ToString();
        }
    }
}