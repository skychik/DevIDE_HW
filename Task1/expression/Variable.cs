using DevIDE_HW.Task1.visitor;

namespace DevIDE_HW.Task1.expression
{
    public class Variable : IExpression
    {
        public Variable(string name)
        {
            Name = name;
        }

        public readonly string Name;

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }

        protected bool Equals(Variable other)
        {
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Variable) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}