namespace ReversePolishNotation;

public class ReversePolishNotationReader
{
    public static int ReadPolishNotation(string str)
    {
        //if num -> save to stack
        //if operand -> perform between two top nums

        string[] instructions = str.Split();
        Stack<int> numbers = new Stack<int>();

        foreach (var op in instructions)
        {
            //is num or operand?
            InstructionType instructionType = GetInstructionType(op);
            //if num
            if (instructionType == InstructionType.Number)
            {
                if (int.TryParse(op,out int num))
                {
                    numbers.Push(num);
                    continue;
                }
                throw new ArgumentException("Input must be a number");
            }
            //if operand
            int n1 = numbers.Pop();
            int n2 = numbers.Pop();
           
            switch (instructionType)
            {
                case InstructionType.Add:
                    numbers.Push(n1 + n2);
                    break;
                case InstructionType.Subtract:
                    numbers.Push(n2 - n1);
                    break;
                case InstructionType.Multiply:
                    numbers.Push(n1 * n2);
                    break;
                case InstructionType.Divide:
                    numbers.Push(n2 / n1);
                    break;
            }
        }
        return numbers.Pop();
    }


    private static InstructionType GetInstructionType(string c)
    {
        switch (c)
        {
            case "*":
                return InstructionType.Multiply;
            case "/":
                return InstructionType.Divide;
            case "+":
                return InstructionType.Add;
            case "-":
                return InstructionType.Subtract;
        }

        return InstructionType.Number;
    }
    private enum InstructionType
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        Number
    }
}