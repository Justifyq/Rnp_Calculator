using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RpnCalculator.Model.Implementation;

namespace RpnCalculator
{
    public static class CalculatorStartup
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            
            var view = new CalculatorView();
            var model = new ReversePolishNotationCalculator();
            var controller = new CalculatorController(view, model);
            
            Application.EnableVisualStyles();
            Application.Run(view);
        }
    }
}