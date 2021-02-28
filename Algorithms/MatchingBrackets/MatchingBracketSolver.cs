using System;
using System.Collections.Generic;

namespace Algorithms.MatchingBrackets
{
    public class MatchingBracketSolver
    {
        public static void Solve(string expression)
        {
            var stack = new Stack<int>();
            for (int index = 0; index < expression.Length; index++)
            {
            
                if (expression[index] is '(')
                {
                    stack.Push(index);
                }
                else if(expression[index] is ')')
                {
                    int openBracketIndex = stack.Peek();
                    int expressionLength = index + 1 - openBracketIndex;
                    Console.WriteLine(expression.Substring(openBracketIndex, expressionLength));
                    stack.Pop();
                }
            }
        }
    }
}