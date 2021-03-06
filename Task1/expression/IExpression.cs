using DevIDE_HW.Task1.visitor;

namespace DevIDE_HW.Task1.expression
{
    public interface IExpression
    {
        void Accept(IExpressionVisitor visitor);
    }
    
}