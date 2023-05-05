using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Taigate.Core
{
    public class CommandSpec
    {
        public DbContext Context { get; set; }
        public IList<KeyValueListModel> Values  { get; set; }
        public ReturnType ReturnType { get; set; }
        
    }
    public class QuerySpec
    {
        public DbContext Context { get; set; }
        public QueryWhereSpec WhereSpec { get; set; }
        public OrderBy OrderBy { get; set; }
        public ReturnType ReturnType { get; set; }
        public KeyValueModel QueryWhereContainsSpec { get; set; }
        public string[] Includes { get; set; }
    }
    public class QueryWhereSpec
    {
        public string Key { get; set; }
        public Operators Operator { get; set; }
        public string Value { get; set; }
    }
    
    
    public class OrderBy
    {
        public string Key { get; set; }
        public string Type { get; set; }
    }

    public enum Operators
    {
        Equal,
        GreaterThen,
        LessThen
    }
    public enum ReturnType
    {
        List,
        First,
        Last
    }
    public struct Operator
    {
        public Operator(Operators selectedOperator)
        {
            CurrentOperator = selectedOperator;
        }

        public Operators CurrentOperator { get; }

        public override string ToString()
        {
            switch (CurrentOperator)
            {
                case Operators.Equal:
                    return "==";
                case Operators.GreaterThen:
                    return ">";
                case Operators.LessThen:
                    return "<";
                default: return "==";
            }
        }
    }
    public class KeyValueModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class KeyValueListModel
    {
        public KeyValueListModel()
        {
            KeyValues = new List<KeyValueModel>();
        }
        public List<KeyValueModel> KeyValues { get; set; }
    }
}