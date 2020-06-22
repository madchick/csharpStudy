using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDotNet;

namespace rTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            REngine.SetEnvironmentVariables(); // <-- May be omitted; the next line would call it.
            REngine engine = REngine.GetInstance();
            // A somewhat contrived but customary Hello World:
            CharacterVector charVec = engine.CreateCharacterVector(new[] { "Hello, R world!, .NET speaking" });
            engine.SetSymbol("greetings", charVec);
            engine.Evaluate("str(greetings)"); // print out in the console
            string[] a = engine.Evaluate("'Hi there .NET, from the R engine'").AsCharacter().ToArray();
            Console.WriteLine("R answered: '{0}'", a[0]);
            Console.WriteLine("Press any key to exit the program");
            engine.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string result;
            string input;
            REngine engine;

            //init the R engine            
            REngine.SetEnvironmentVariables();
            engine = REngine.GetInstance();
            engine.Initialize();

            //input
            Console.WriteLine("Please enter the calculation");
            input = Console.ReadLine();

            //calculate
            CharacterVector vector = engine.Evaluate(input).AsCharacter();
            result = vector[0];

            //clean up
            engine.Dispose();

            //output
            Console.WriteLine("");
            Console.WriteLine("Result: '{0}'", result);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
