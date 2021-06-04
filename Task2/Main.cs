using System;
using Antlr4.Runtime;
using NUnit.Framework;
using static PascalLexer;

namespace DevIDE_HW.Task2
{
    public class Tests
    {
        [Test]
        public void TestEmptyProgram()
        {
            const string emptyProgram = @"
program p;
begin
end.
";
            OutputResult(emptyProgram);
        }
        
        [Test]
        public void TestHelloWorld()
        {
            const string input = @"
program hello;
begin
  println('Hello, World!');  // оператор вывода строки 
end.";
            OutputResult(input);
        }
        
        [Test]
        public void TestAmountOfEvenNumbers()
        {
            const string input = @"
var n,i,k,a:integer;
begin
writeln('введите количество чисел');
readln(n);
a:=0;
for i:=1 to n do begin
                 writeln('введите ',i:1,'-е число');
                 readln(a);
                 if a mod 2=0 then k:=k+1;
                 end;
writeln('кол-во четных чисел ',k);
readln;
end.";
            OutputResult(input);
        }
    
        private static void OutputResult(string prog) {
            var stream = CharStreams.fromString(prog);
            var lexer = new PascalLexer(stream);
            var tokens = lexer.GetAllTokens();
            foreach (var token in tokens)
            {
                var type = token.Type switch
                {
                    RESERVED_WORD => "RESERVED_WORD",
                    SEPARATOR => "SEPARATOR",
                    COMMENT => "COMMENT",
                    IDENTIFIER => "IDENTIFIER",
                    // NUMBER => "NUMBER",
                    // UNSIGNED_NUMBER => "UNSIGNED_NUMBER",
                    SIGNED_NUMBER => "SIGNED_NUMBER",
                    // UNSIGNED_INTEGER => "UNSIGNED_INTEGER",
                    // UNSIGNED_REAL => "UNSIGNED_REAL",
                    CHARACTER_STRING => "CHARACTER_STRING",
                    // QUOTE => "QUOTE",
                    PLUS => "PLUS",
                    MINUS => "MINUS",
                    MUL => "MUL",
                    SLASH => "SLASH",
                    DIV => "DIV",
                    EQ => "EQ",
                    LT => "LT",
                    MT => "MT",
                    SBRACE_OPEN => "SBRACE_OPEN",
                    SBRACE_CLOSE => "SBRACE_CLOSE",
                    DOT => "DOT",
                    COMMA => "COMMA",
                    PARENTH_OPEN => "PARENTH_OPEN",
                    PARENTH_CLOSE => "PARENTH_CLOSE",
                    COLON => "COLON",
                    CAP => "CAP",
                    AT => "AT",
                    LT_DOUBLE => "LT_DOUBLE",
                    MT_DOUBLE => "MT_DOUBLE",
                    POW => "POW",
                    NE => "NE",
                    CHINEE => "CHINEE",
                    ASSIGN_LT => "ASSIGN_LT",
                    ASSIGN_MT => "ASSIGN_MT",
                    ASSING => "ASSING",
                    ASSING_PLUS => "ASSING_PLUS",
                    ASSING_MINUS => "ASSING_MINUS",
                    ASSING_MUL => "ASSING_MUL",
                    ASSING_DIV => "ASSING_DIV",
                    SEP => "SEP",
                    LABELV => "LABELV",
                    _ => "UNDEFINED" + token.Type
                };
                Console.WriteLine($"tkn={type}, text={token.Text}, start={token.StartIndex}, end={token.StopIndex}");
            }
        }
    }
}