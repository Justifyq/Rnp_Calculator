using System.Drawing;
using System.Windows.Forms;

namespace RpnCalculator
{
    public class CalculatorView : Form
    {
        public readonly TextBox Output;
        public readonly TextBox Input;

        public readonly Button CalculateButton;
        
        public CalculatorView()
        {
            Output = new TextBox();
            Input = new TextBox();
            CalculateButton = new Button();
            
            Input.Location = new Point(10, 10);
            Input.Size = new Size(200, 20);
            
            
            Output.Location = new Point(10, 40);
            Output.Size = new Size(270, 20);
            
            Output.ReadOnly = true;
            
            CalculateButton.Location = new Point(210, 10);
            CalculateButton.Size = new Size(60, 20);

            CalculateButton.Text = "=";
            
            Controls.Add(Input);
            Controls.Add(Output);
            Controls.Add(CalculateButton);
        }
    }
}