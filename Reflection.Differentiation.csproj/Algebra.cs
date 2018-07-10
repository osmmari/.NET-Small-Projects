using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Differentiation
{
   public static class Algebra
    {
        public static Expression<Func<double, double>> Differentiate(Expression<Func<double, double>> func)
        {
            return Expression.Lambda<Func<double, double>>(DiffHelp(func.Body), func.Parameters);
        }

        private static Expression DiffHelp(Expression func)
        {
            if (func is ConstantExpression)
            {
                return Expression.Constant(0.0);
            }
            
            if (func is ParameterExpression)
            {
                return Expression.Constant(1.0);
            }

            if (func is BinaryExpression binExpression)
            {
                var left = binExpression.Left;
                var right = binExpression.Right;

                if (func.NodeType == ExpressionType.Multiply)
                {
                    return Expression.Add(
                        Expression.Multiply(right, DiffHelp(left)),
                        Expression.Multiply(left, DiffHelp(right))
                        );
                }

                if (func.NodeType == ExpressionType.Add)
                {
                    return Expression.Add(DiffHelp(left), DiffHelp(right));
                }
            }

            if (func is MethodCallExpression methodExpression)
            {
                var parameter = methodExpression.Arguments[0];

                if (methodExpression.Method.Name == "Sin")
                {
                    return Expression.Multiply(Expression.Call(typeof(Math).GetMethod("Cos"), parameter), DiffHelp(parameter));
                }

                if (methodExpression.Method.Name == "Cos")
                {
                    return Expression.Negate(Expression.Multiply(Expression.Call(typeof(Math).GetMethod("Sin"), parameter), DiffHelp(parameter)));
                }
            }

            throw new ArgumentException();
        }
    }
}
