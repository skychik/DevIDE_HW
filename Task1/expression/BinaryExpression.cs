using System;
using DevIDE_HW.Task1.visitor;

namespace DevIDE_HW.Task1.expression
{
    public class BinaryExpression : IExpression
    {
        public readonly IExpression FirstOperand;
        public readonly IExpression SecondOperand;
        public readonly string Operator;

        public BinaryExpression(IExpression firstOperand, IExpression secondOperand, string @operator)
        {
            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            Operator = @operator;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }

        protected bool Equals(BinaryExpression other)
        {
            return Equals(FirstOperand, other.FirstOperand) && Equals(SecondOperand, other.SecondOperand) && Operator == other.Operator;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BinaryExpression) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstOperand, SecondOperand, Operator);
        }
    }
}