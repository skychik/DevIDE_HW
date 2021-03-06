using DevIDE_HW.Task1.visitor;

namespace DevIDE_HW.Task1.expression
{
    public class Literal : IExpression
    {
        public Literal(string value)
        {
            Value = value;
        }

        public readonly string Value;

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }

        protected bool Equals(Literal other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Literal) obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }
    }
}