using System.Text;
using DevIDE_HW.Task1.expression;

namespace DevIDE_HW.Task1.visitor
{
    public class DumpVisitor : IExpressionVisitor
    {
        private readonly StringBuilder _myBuilder;

        public DumpVisitor()
        {
            _myBuilder = new StringBuilder();
        }

        public void Visit(Literal expression)
        {
            _myBuilder.Append("L(" + expression.Value + ")");
        }

        public void Visit(Variable expression)
        {
            _myBuilder.Append("V(" + expression.Name + ")");
        }

        public void Visit(BinaryExpression expression)
        {
            _myBuilder.Append("B(");
            expression.FirstOperand.Accept(this);
            _myBuilder.Append(expression.Operator);
            expression.SecondOperand.Accept(this);
            _myBuilder.Append(')');
        }

        public void Visit(ParenExpression expression)
        {
            _myBuilder.Append("P(");
            expression.Operand.Accept(this);
            _myBuilder.Append(')');
        }

        public override string ToString()
        {
            return _myBuilder.ToString();
        }
    }
}