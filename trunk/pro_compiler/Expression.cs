using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pro_compiler
{
    public abstract class Expression
    {
    }

    public class StringLiteral : Expression
    {
        public string Value;
    }

    public class IntegerLiteral : Expression
    {
        public int Value;
    }

    public class Variable : Expression
    {
        public string Name;
    }

    public class Arithmetic : Expression
    {
        public Expression Left;
        public Expression Right;
        public Expression BinOp;
    }

    public enum ArithOper
    {
        Add,
        Sub,
        Mul,
        Div
    }
}
