using System;
using System.Collections.Generic;
using Blackboard;
using Primes;

namespace BlackBoardSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackBoard blackBoard = new BlackBoard();

            ControlData data1 = new ControlData("PrimeNumbers", new object[] { 100 });

            blackBoard.update("DAT0001", data1);

            PrimeFinder primeFinder = new PrimeFinder();

            blackBoard.addKnowledgeWorker(primeFinder);

            blackBoard.print();
            blackBoard.control.loop();
            blackBoard.print();
            System.Console.ReadKey();

        }
    }
}
