using System;
using System.Collections.Generic;
using Blackboard;
using System.Linq;

namespace Primes
{
    public class PrimeFinder:KnowledgeWorker
    {
        protected int MAX = 1000;
        public PrimeFinder(BlackBoard blackboard): base(blackboard,"PrimeFinder")
        {
            
        }

        public PrimeFinder() : base("PrimeFinder")
        {

        }

        public override void executeCondition()
        {
            this.keys = new List<KeyValuePair<string, ControlData>>();
            foreach (KeyValuePair<string, ControlData> cdata in this.blackboard.inspect())
            {
                if (cdata.Value.problem == "PrimeNumbers" 
                        && cdata.Value.input!=null 
                        && cdata.Value.input.Length>0 
                        && valueIsOk(cdata.Value.input[0])
                        && (int)cdata.Value.input[0]<this.MAX)
                {
                    
                    this.canContribute = true;
                    // this.keys.Add(new KeyValuePair<string, ControlData>(cdata.Key, cdata.Value.Clone()));
                    this.keys.Add(cdata);
                    System.Console.WriteLine(string.Format("Worker:{0} can contribute on Problem:{1}", this.Name, cdata.Key));                    
                }
            }
        }

        protected bool valueIsOk( object obj)
        {
            if (Equals(obj, null))
            {
                return false;
            }

            Type objType = obj.GetType();
            objType = Nullable.GetUnderlyingType(objType) ?? objType;

            if (objType.IsPrimitive)
            {
                return objType != typeof(bool) &&
                    objType != typeof(char) &&
                    objType != typeof(IntPtr) &&
                    objType != typeof(UIntPtr);
            }

            return objType == typeof(decimal);
        }

        public override void executeAction()
        {
            if (this.canContribute)
            {
                foreach (KeyValuePair<string, ControlData> value in this.keys)
                {
                    if (this.keys.Contains(value))
                    {
                        List<int> primes = new List<int>();                        
                        for (int i = 0; i < MAX; i++)
                        {
                            if (isPrimeSlow(i))
                            {
                                primes.Add(i);
                            }
                        }
                        // update temp results
                        value.Value.output = primes.Cast<object>().ToArray();                        
                    }
                }
            }
        }

        public bool isPrimeSlow(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;   

        }

        public override void updateBlackboard()
        {
            foreach (KeyValuePair<string, ControlData> value in this.keys)
            {
                this.blackboard.update(value);
            }
        }
    }
}
