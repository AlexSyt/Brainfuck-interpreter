using System;

namespace Brainfuck_Interpreter
{
    class Program
    {
        //Hello World! on Brainfuck
        //static string code =
        //    "++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.> +.++++++ +..++ +.> ++.<< +++++++" +
        //    "++++++++.>.++ +.------.--------.> +.>.";

        //show Fibonacci numbers up to 16 numbers on Brainfuck
        static string code =
            "++++++++++++++++++++++++++++++++++++++++++++>++++++++++++++++++++++++++++++++>++++++++++++++++>>" +
            "+<<[>>>>++++++++++<<[->+>-[>+>>]>[+[-<+>]>+>>]<<<<<<]>[<+>-]>[-]>>>++++++++++<[->-[>+>>]>[+[-<+>]" +
            ">+>>]<<<<<]>[-]>>[++++++++++++++++++++++++++++++++++++++++++++++++.[-]]<[++++++++++++++++++++++++" +
            "++++++++++++++++++++++++.[-]]<<<++++++++++++++++++++++++++++++++++++++++++++++++.[-]<<<<<<<.>.>>[>" +
            ">+<<-]>[>+<<+>-]>[<+>-]<<<-]<<++...";

        static int _count;
        static readonly int[] Memory = new int[30000];
        static int _memoryPointer;

        private static void Interpreter(string s)
        {
            int i = -1;
            int right = s.Length;

            while (i < right)
            {
                i++;
                if (i == right) break;
                switch (s[i])
                {
                    case '>':
                        _memoryPointer++;
                        break;
                    case '<':
                        _memoryPointer--;
                        break;
                    case '+':
                        Memory[_memoryPointer]++;
                        break;
                    case '-':
                        if (Memory[_memoryPointer] > 0) Memory[_memoryPointer]--;
                        break;
                    case '.':
                        Console.Write((char) Memory[_memoryPointer]);
                        break;
                    case ',':
                        Memory[_memoryPointer] = (byte) Console.Read();
                        break;
                    case '[':
                        if (Memory[_memoryPointer] == 0)
                        {
                            _count = -1;
                            do
                            {
                                i++;
                                switch (code[i])
                                {
                                    case '[':
                                    {
                                        _count--;
                                        break;
                                    }
                                    case ']':
                                    {
                                        _count++;
                                        break;
                                    }
                                }
                            } while (_count != 0);
                        }
                        break;
                    case ']':
                        if (Memory[_memoryPointer] != 0)
                        {
                            _count = 1;
                            do
                            {
                                i--;
                                switch (code[i])
                                {
                                    case '[':
                                    {
                                        _count--;
                                        break;
                                    }
                                    case ']':
                                    {
                                        _count++;
                                        break;
                                    }
                                }
                            } while (_count != 0);
                        }
                        break;
                }
            }
        }

        static void Main()
        {
            Interpreter(code);
            Console.ReadKey();
        }
    }
}