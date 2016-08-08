using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Blackboard
{
    public class BlackBoard
    {
        public List<KnowledgeWorker> knowledgeWorkers;
        protected Dictionary<string, ControlData> data;
        public Control control;


        public BlackBoard()
        {
            this.knowledgeWorkers = new List<KnowledgeWorker>();
            this.control = new Control(this);
            this.data = new Dictionary<string, ControlData>();
        }

        public void addKnowledgeWorker(KnowledgeWorker newKnowledgeWorker) 
        {
            newKnowledgeWorker.blackboard = this;
            this.knowledgeWorkers.Add(newKnowledgeWorker);
        }       

        public Dictionary<string, ControlData> inspect()
        {
            return (Dictionary<string, ControlData>) this.data.ToDictionary(k => k.Key, k => (ControlData) k.Value.Clone());
        }
        public void update(KeyValuePair<string, ControlData> blackboardEntry) 
        {
            if (this.data.ContainsKey(blackboardEntry.Key))
            {
                this.data[blackboardEntry.Key] = blackboardEntry.Value;
            }
            else
                throw new InvalidOperationException(blackboardEntry.Key + " Not Found!");
        }

        public void update(string key, ControlData data)
        {
            if (this.data.ContainsKey(key))
            {
                this.data[key] = data;
            }
            else
            {
                this.data.Add(key, data);
            }            
        }

        public void print()
        {
            System.Console.WriteLine("Blackboard state");
            foreach (KeyValuePair<string, ControlData> cdata in this.data)
            {
                Console.WriteLine(string.Format("data:{0}", cdata.Key));
                Console.WriteLine(string.Format("\tProblem:{0}", cdata.Value.problem));
                if(cdata.Value.input!=null)
                    Console.WriteLine(string.Format("\tInput:{0}", string.Join(",",cdata.Value.input)));
                if(cdata.Value.output!=null)
                    Console.WriteLine(string.Format("\tOutput:{0}", string.Join(",",cdata.Value.output)));
            }
        }

    }
}
