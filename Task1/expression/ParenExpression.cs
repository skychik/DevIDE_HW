using DevIDE_HW.Task1.visitor;

namespace DevIDE_HW.Task1.expression
{
    public class ParenExpression : IExpression
    {
        public ParenExpression(IExpression operand)
        {
            Operand = operand;
        }

        public readonly IExpression Operand;

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }

        protected bool Equals(ParenExpression other)
        {
            return Equals(Operand, other.Operand);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ParenExpression) obj);
        }

        public override int GetHashCode()
        {
            return (Operand != null ? Operand.GetHashCode() : 0);
        }
    }
}