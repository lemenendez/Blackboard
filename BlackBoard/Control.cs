using System;
using System.Collections.Generic;


namespace Blackboard
{
    public class Control
    {
        BlackBoard blackBoard = null;
        
        public Control(BlackBoard blackBoard)
        {
            this.blackBoard = blackBoard;
        }

        public void loop()
        {
            System.Console.WriteLine("Starting loop");
            if (blackBoard == null)
                throw new InvalidOperationException("blackboard is null");
            this.nextSource();
            System.Console.WriteLine("Loop ended");
            
        }

        /// <summary>
        /// Selects the next source of knowledge (knowledgeworker by inspecting the blackgoard)
        /// </summary>
        void nextSource()
        {
            // observers the blackboard
            foreach (KeyValuePair<string, ControlData> value in this.blackBoard.inspect())
            {                  
                 foreach (KnowledgeWorker worker in this.blackBoard.knowledgeWorkers)
                 {
                     if (worker.executeCondition())
                     {
                         Console.WriteLine(string.Format("{0} Can Contribute",worker.getName()));                         
                         worker.executeAction();
                         worker.updateBlackboard();
                     }
                 }                        
            }
        }
    }
}
