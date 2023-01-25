using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpnCalculator.Model.Implementation
{
    public class ReversePolishNotationCalculator
    {
        public double Calculate(string mathExpression)
        {
            mathExpression = mathExpression.Replace(" ", string.Empty);

            var expression = GetSplittedExpression(mathExpression);
            
            var queue = GetOperationQueue(expression);
            
            var result =  CalculateByRpn(queue);

            Console.WriteLine(result);

            return result;
        }

        private double CalculateByRpn(Queue<string> queue)
        {
            var resultStack = new Stack<double>();
            
            while (queue.Any())
            {
                var currentToken = queue.Dequeue();
                
                if (Token.IsNumber(currentToken))
                {
                    resultStack.Push(double.Parse(currentToken));
                    continue;
                }

                if (Token.Contain(currentToken))
                {
                    var b = resultStack.Pop();
                    var a = resultStack.Pop();
                    var output = Token.MakeOperationByToken(a, b, currentToken);
                    resultStack.Push(output);
                    continue;
                }
            }

            return resultStack.Pop();
        }
        
        private Queue<string> GetOperationQueue(string[] expression)
        {
            var queue = new Queue<string>();
            var operationStack = new Stack<string>();

            foreach (var token in expression)
            {
                if (Token.IsNumber(token))
                {
                    queue.Enqueue(token);
                    continue;
                }
                
                if (Token.IsLeftParenthesis(token))
                {
                    operationStack.Push(token);
                    continue;
                }
                
                if (Token.IsRightParenthesis(token))
                {
                    while (Token.IsLeftParenthesis(operationStack.Peek()) == false) 
                        queue.Enqueue(operationStack.Pop());

                    operationStack.Pop();
                    continue;
                }

                while (operationStack.Any() && (Token.GetOrder(operationStack.Peek()) >= Token.GetOrder(token)))
                {
                    Console.WriteLine($"Token - {operationStack.Peek()} added to queue");
                    queue.Enqueue(operationStack.Pop());
                }
                
                operationStack.Push(token);
            }

            while (operationStack.Count > 0)
                queue.Enqueue(operationStack.Pop());

            return queue;
        }
        
        private string[] GetSplittedExpression(string mathExpression)
        {
            var symbolBuilder = new StringBuilder();
            var numberBuilder = new StringBuilder();
            
            var splittedExpression = new List<string>();
            
            for (var i = 0; i < mathExpression.Length; i++)
            {
                var symbol = mathExpression[i];
                var isToNumber = false;

                if (i == mathExpression.Length - 1 && char.IsDigit(symbol))
                {
                    numberBuilder.Append(symbol);
                    splittedExpression.Add(numberBuilder.ToString());
                    numberBuilder.Clear();
                    break;
                }
                
                if (char.IsDigit(symbol) || Token.IsComma(symbol))
                {
                    if (symbolBuilder.Length > 0)
                    {
                        splittedExpression.Add(symbolBuilder.ToString());
                        symbolBuilder.Clear();
                    }

                    numberBuilder.Append(symbol);
                    continue;
                }
                
                if ((symbol == '-' && i == 0) || (symbol == '-' 
                                                  && char.IsDigit(mathExpression[i - 1]) == false 
                                                  && Token.IsLeftParenthesis(mathExpression[i - 1].ToString())))
                {
                    numberBuilder.Append(symbol);
                    isToNumber = true;
                }
                else
                {
                    symbolBuilder.Append(symbol);
                }


                if (!Token.Contain(symbolBuilder.ToString()) || isToNumber) 
                    continue;
                
                if (numberBuilder.Length > 0)
                {
                    splittedExpression.Add(numberBuilder.ToString());
                    numberBuilder.Clear();
                }

                splittedExpression.Add(symbolBuilder.ToString());
                symbolBuilder.Clear();
            }

            return splittedExpression.ToArray();
        }
        
    }
}