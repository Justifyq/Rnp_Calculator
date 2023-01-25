using System.Collections.Generic;

namespace RpnCalculator.Model.Implementation
{
    public static class Token
    {
        private static readonly Dictionary<string, int> Tokens = new Dictionary<string, int>()
        {
            {"+" , 1},
            {"-" , 1},
            {"*", 2},
            {"/", 2},
            {"^", 3},
            
        };

        public static bool IsParenthesis(string symbol) => IsLeftParenthesis(symbol) || IsRightParenthesis(symbol);

        public static bool Contain(string token) => Tokens.ContainsKey(token) || (token != string.Empty && IsParenthesis(token));
        
        public static bool IsRightParenthesis(string token) => token == ")";

        public static bool IsComma(char token) => token == ',';

        public static bool IsLeftParenthesis(string symbol) => symbol == "(";

        public static int GetOrder(string symbol) => Tokens.ContainsKey(symbol) ? Tokens[symbol] : 0;

        public static bool IsNumber(string token) => double.TryParse(token, out _);

        public static double MakeOperationByToken(double a, double b, string token)
        {
            switch (token)
            {
                case  "+" : 
                    return a + b;
                case "-" :
                    return a - b;
                case "*" :
                    return a * b;
                case "/" :
                    return a / b;
                default:
                    return 0;
            }
        }
    }
}