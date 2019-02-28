using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        private Stack<float> _stack= new Stack<float>();

        public void EnterNumber(float number)
        {
            _stack.Push(number);
        }

        public enum Operations
        {
            Add,
            Subtract,
            Divide,
            Multiply,
            Decimal,
            SquareRoot,
            Squared,
            PowerOf3,
            PlusMinus,
            Fraction
        }

        public enum Status
        {
            Ok,
            DivideByZero
        }

        public Status Calculate(Operations operation)
        {
            Status result = Status.Ok;
            switch (operation)
            {
                case Operations.Divide:
                {
                    var op1 = _stack.Pop();
                    var op2 = _stack.Pop();
                    if (op1 != 0.0f)
                    {
                        op2 /= op1;
                        _stack.Push(op2);
                    }
                    else
                    {
                        result = Status.DivideByZero;
                    }                    
                }
                break;

                case Operations.PlusMinus:
                {
                    var op1 = _stack.Pop();
                    var op2 = _stack.Pop();
                    op1 *= -1;
                    op2 *= -1;
                }
                break;

                case Operations.Fraction:
                {
                    var op1 = _stack.Pop();
                    op1 = (float)((double)1 / op1);
                    _stack.Push(op1);
                }
                break;

                case Operations.SquareRoot:
                {
                    var op1 = _stack.Pop();
                    op1 = (float)Math.Sqrt((double)op1);
                    _stack.Push(op1);
                }
                break;

                case Operations.Squared:
                {
                    var op1 = _stack.Pop();
                    op1 *= op1;
                    _stack.Push(op1);
                }
                break;

                case Operations.PowerOf3:
                {
                    var op1 = _stack.Pop();
                    op1 *= op1 *= op1;
                    _stack.Push(op1);
                }
                break;


                case Operations.Add:
                {
                    var op1 = _stack.Pop();
                    var op2 = _stack.Pop();
                    op1 += op2;
                    _stack.Push(op1);                    
                }
                break;

                case Operations.Subtract:
                {
                    var op1 = _stack.Pop();
                    var op2 = _stack.Pop();
                    op1 -= op2;
                    _stack.Push(op1);
                }
                break;

                case Operations.Multiply:
                {
                    var op1 = _stack.Pop();
                    var op2 = _stack.Pop();
                    op1 *= op2;
                    _stack.Push(op1);
                }
                break;
            }
            return result;
        }

        public float LastResult()
        {
            return _stack.Peek();
        }
    }
}
