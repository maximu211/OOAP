using System;
using System.Collections.Generic;
using System.Globalization;

namespace DateInterpreter
{
    abstract class DateExpression
    {
        public abstract DateTime Interpret(string expression);
    }

    class MMDDYYYYExpression : DateExpression
    {
        public override DateTime Interpret(string expression)
        {
            return DateTime.ParseExact(expression, "MM-dd-yyyy", CultureInfo.InvariantCulture);
        }
    }

    class DDMMYYYYExpression : DateExpression
    {
        public override DateTime Interpret(string expression)
        {
            return DateTime.ParseExact(expression, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }
    }

    class YYYYMMDDExpression : DateExpression
    {
        public override DateTime Interpret(string expression)
        {
            return DateTime.ParseExact(expression, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }

    class DateContext
    {
        private Dictionary<string, DateExpression> _expressions;

        public DateContext()
        {
            _expressions = new Dictionary<string, DateExpression>
            {
                { "MM-DD-YYYY", new MMDDYYYYExpression() },
                { "DD-MM-YYYY", new DDMMYYYYExpression() },
                { "YYYY-MM-DD", new YYYYMMDDExpression() }
            };
        }

        public DateTime Interpret(string format, string expression)
        {
            if (!_expressions.ContainsKey(format))
            {
                throw new ArgumentException("Invalid date format.");
            }

            return _expressions[format].Interpret(expression);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DateContext context = new DateContext();

            string format1 = "MM-DD-YYYY";
            string expression1 = "01-31-2022";
            DateTime date1 = context.Interpret(format1, expression1);
            Console.WriteLine($"Date in format '{format1}': {date1}");

            string format2 = "DD-MM-YYYY";
            string expression2 = "31-01-2022";
            DateTime date2 = context.Interpret(format2, expression2);
            Console.WriteLine($"Date in format '{format2}': {date2}");

            string format3 = "YYYY-MM-DD";
            string expression3 = "2022-01-31";
            DateTime date3 = context.Interpret(format3, expression3);
            Console.WriteLine($"Date in format '{format3}': {date3}");
        }
    }
}
