using System;
using RpnCalculator.Model.Implementation;

namespace RpnCalculator
{
    public class CalculatorController
    {
        private readonly CalculatorView _view;
        private readonly ReversePolishNotationCalculator _model;

        public CalculatorController(CalculatorView view, ReversePolishNotationCalculator model)
        {
            _view = view;
            _model = model;
            _view.CalculateButton.Click += CalculateButtonClicked;
        }

        private void CalculateButtonClicked(object sender, EventArgs e)
        {
            var result = string.Empty;
            
            try
            {
                result = _model.Calculate(_view.Input.Text).ToString();
            }
            catch (Exception ex)
            {
                result = "Выражение составлено некорректно";
            }
            
            _view.Output.Text = result;
        }
    }
}