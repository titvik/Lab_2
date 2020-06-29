using System;
namespace lab2.Models
{
    public class CalcModel
    {
        public int FirstValue {get; set;}
        public int SecondValue {get; set;}
        public string Op {get; set;}

        public int result {get; set;}

        public bool DivisionByZeroException = false;

        public CalcModel()
        {
            FirstValue = 0;
            SecondValue = 0;
            Op = "";
            result = 0;
        }
        public CalcModel(int fv, string op, int sv)
        {
            FirstValue = fv;
            Op = op;
            SecondValue = sv;
            Calculate();
        }
        public void Calculate()
        {
            switch (Op)
            {
                case "+":
                    result = FirstValue + SecondValue;
                    break;
                
                case "-":
                    result = FirstValue - SecondValue;
                    break;

                case "*":
                    result = FirstValue * SecondValue;
                    break;

                case "/":
                    try {
                        result = FirstValue / SecondValue;
                    }
                    catch(DivideByZeroException)
                    {
                        DivisionByZeroException = true;
                    }
                    break;

            }
        }

    }
}