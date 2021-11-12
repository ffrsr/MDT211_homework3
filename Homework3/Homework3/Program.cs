using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    {
        static char GetNextData(char InputInstruction)
        {
            switch (InputInstruction)
            {
                case 'A':
                    return 'P';
                case 'B':
                    return 'P';
                case 'C':
                    return 'R';
                case 'D':
                    return 'Q';
                case 'E':
                    return 'R';
                default:
                    return '?';
            }
            
        }
        static void Main(string[] args)
        {
            Queue inputQueue = new Queue();
            char InputInstruction;
            char InputData;

            CPU cpu1 = new CPU();
            CPU cpu2 = new CPU();
            CPU cpu3 = new CPU();
            CPU cpu4 = new CPU();

            while (true)
            {                
                InputInstruction = char.Parse(Console.ReadLine());
                
                if (InputInstruction == '?')
                {
                    Console.WriteLine("CPU cycles needed: 2");                  
                }
                InputData = char.Parse(Console.ReadLine());
                Console.WriteLine("{0} {1}", InputInstruction, InputData);
                
                Node Input = new Node(InputInstruction, InputData);
                inputQueue.Push(Input);
            }
            
            Node CPU;
            while (true)
            {
                CPU = inputQueue.Pop();
                if (CPU == null)
                {
                    break;
                }
                Console.WriteLine(CPU.inputData);

                if (CPU.inputInstruction != '?')
                {
                    Node temporary = new Node(CPU.inputInstruction, GetNextData(CPU.inputData));

                    inputQueue.Push(temporary);
                }
            }
        }
    }

    class Node
    {
        public char inputInstruction;
        public char inputData;
        public Node Next;

        public Node(char inputInstructionValue, char inputDataValue)
        {
            inputInstruction = inputInstructionValue;
            inputData = inputDataValue;
        }
    }

    class Queue
    {
        public Node Root;

        public void Push(Node node)
        {
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Node ptr = Root;
                while (ptr.Next != null)
                {
                    ptr = ptr.Next;
                }
                ptr.Next = node;
            }
        }
        public Node Pop ()
        {
            if (Root == null)
            {
                return null;
            }
            Node node = Root;
            Root = Root.Next;
            node.Next = null;
            return node;
        }
    }

    class CPU
    {
        public char cpu;        
    }


}
