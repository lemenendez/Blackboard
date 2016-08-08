using System;
using System.Collections.Generic;

namespace Blackboard
{
    /// <summary>
    /// each knowledgeworker is resposible for knowing the conditions under which it can contribute to a solution.
    /// </summary>
    abstract public  class KnowledgeWorker
    {
        protected Boolean canContribute;        
        protected string Name;                  
        public BlackBoard blackboard = null;    
        protected List<KeyValuePair<string, ControlData>> keys;
        public KnowledgeWorker(BlackBoard blackboard, String Name)
        {
            this.blackboard = blackboard;
            this.Name = Name;
        }

        public KnowledgeWorker(String Name)
        {
            this.Name = Name;
        }

        public string getName() 
        {
            return this.Name;
        }

        abstract public void executeAction();

        abstract public bool executeCondition();

        abstract public void updateBlackboard();

    }
}
