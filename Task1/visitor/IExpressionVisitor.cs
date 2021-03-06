using DevIDE_HW.Task1.expression;

namespace DevIDE_HW.Task1.visitor
{
    public interface IExpressionVisitor
    {
        void Visit(Literal expression);
        void Visit(Variable expression);
        void Visit(BinaryExpression expression);
        void Visit(ParenExpression expression);
    }
}