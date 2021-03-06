using System.Collections.Generic;
using DevIDE_HW.Task1.expression;
using DevIDE_HW.Task1.visitor;
using NUnit.Framework;

namespace DevIDE_HW.Task1
{
    public static class SimpleParser
    {
        public static IExpression Parse(string text)
        {
            var exprStack = new Stack<IExpression>();
            var operStack = new Stack<char>();
            var isOperNext = false;
            foreach (var ch in text)
            {
                if (!isOperNext)
                {
                    if (ch == '(')
                    {
                        operStack.Push(ch);
                        continue;
                    }

                    isOperNext = true;

                    if (char.IsLetter(ch))
                    {
                        exprStack.Push(new Variable(ch.ToString()));
                        continue;
                    }

                    if (char.IsDigit(ch))
                    {
                        exprStack.Push(new Literal(ch.ToString()));
                        continue;
                    }

                    return null;
                }

                if (ch == ')')
                {
                    while (operStack.TryPeek(out var top1) && top1 != '(')
                    {
                        Collapse(exprStack, operStack);
                    }

                    if (operStack.Count == 0)
                    {
                        return null;
                    }

                    operStack.Pop();
                    exprStack.Push(new ParenExpression(exprStack.Pop()));
                    continue;
                }

                isOperNext = false;

                if (ch == '*' || ch == '/')
                {
                    if (!operStack.TryPeek(out var top) || top == '(' || top == '+' || top == '-')
                    {
                        operStack.Push(ch);
                        continue;
                    }

                    while (operStack.TryPeek(out var top1) && top1 != '(' && top1 != '+' && top1 != '-')
                    {
                        Collapse(exprStack, operStack);
                    }

                    operStack.Push(ch);
                    continue;
                }

                if (ch == '+' || ch == '-')
                {
                    if (!operStack.TryPeek(out var top) || top == '(')
                    {
                        operStack.Push(ch);
                        continue;
                    }

                    while (operStack.TryPeek(out var top1) && top1 != '(')
                    {
                        Collapse(exprStack, operStack);
                    }

                    operStack.Push(ch);
                    continue;
                }

                return null;
            }

            while (operStack.TryPeek(out var top) && top != '(')
            {
                Collapse(exprStack, operStack);
            }

            if (exprStack.Count != 1 || operStack.Count != 0)
            {
                return null;
            }

            return exprStack.Pop();
        }

        private static void Collapse(Stack<IExpression> exprStack, Stack<char> operStack)
        {
            var right = exprStack.Pop();
            var left = exprStack.Pop();
            var oper = operStack.Pop();
            exprStack.Push(new BinaryExpression(left, right, oper.ToString()));
        }
    }

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static string ToString(IExpression expression)
        {
            var visitor = new DumpVisitor();
            expression.Accept(visitor);
            return visitor.ToString();
        }

        [Test]
        public void Test1()
        {
            var visitor = new DumpVisitor();
            new BinaryExpression(new Literal("1"), new Literal("2"), "+").Accept(visitor);
            Assert.AreEqual("B(L(1)+L(2))", visitor.ToString());
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(
                new BinaryExpression(
                    new Literal("4"),
                    new Variable("b"),
                    "+"),
                SimpleParser.Parse("4+b")
            );

            Assert.AreEqual(
                new BinaryExpression(
                    new BinaryExpression(
                        new Literal("4"),
                        new Literal("5"),
                        "+"),
                    new Literal("6"),
                    "+"),
                SimpleParser.Parse("4+5+6")
            );

            Assert.AreEqual(
                new ParenExpression(
                    new BinaryExpression(
                        new Literal("4"),
                        new Literal("5"),
                        "+")
                ),
                SimpleParser.Parse("(4+5)")
            );

            Assert.AreEqual(
                new ParenExpression(
                    new BinaryExpression(
                        new ParenExpression(
                            new Literal("4")
                        ),
                        new ParenExpression(
                            new ParenExpression(
                                new Literal("5")
                            )
                        ),
                        "+")
                ),
                SimpleParser.Parse("((4)+((5)))")
            );

            Assert.AreEqual(
                new BinaryExpression(
                    new BinaryExpression(
                        new BinaryExpression(
                            new BinaryExpression(
                                new BinaryExpression(
                                    new Literal("4"),
                                    new Variable("a"),
                                    "/"),
                                new Literal("3"),
                                "*"),
                            new Literal("3"),
                            "-"),
                        new BinaryExpression(
                            new Literal("5"),
                            new Variable("b"),
                            "*"),
                        "+"),
                    new BinaryExpression(
                        new BinaryExpression(
                            new BinaryExpression(
                                new Literal("0"),
                                new Variable("c"),
                                "/"),
                            new Literal("0"),
                            "/"),
                        new Literal("0"),
                        "/"),
                    "-"),
                SimpleParser.Parse("4/a*3-3+5*b-0/c/0/0")
            );
            
            Assert.Pass();
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual(
                "B(B(B(L(4)/P(B(P(B(V(a)*L(3)))-P(B(B(L(3)+B(L(5)*V(b)))-B(L(0)/V(c)))))))/L(0))/L(0))", 
                ToString(SimpleParser.Parse("4/((a*3)-(3+5*b-0/c))/0/0"))
            );
            
            Assert.Pass();
        }
    }
}