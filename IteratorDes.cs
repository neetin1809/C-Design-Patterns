//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        
        interface  IIterator{
                string FirstItem{ get;}
                string NextItem{ get;}
                string CurrentItem{ get;}
                bool isDone{ get;}
        }
        
        interface IAggregate{
            IIterator GetIterator();
            string this [int index]{get;set;}
            int Count{get;}
        }
        
        class MyAggregate :IAggregate
        {
            List<String> _values = null;
            public MyAggregate(){
                _values = new List<string>();
            }
            public string this [int index]{
                
                get{
                    if(index<_values.Count)
                        return _values[index];
                    else
                        return string.Empty;
            }
            set{
                _values.Add(value);
             }
            }
            public IIterator GetIterator(){
                return new MyIterator(this);
            }
            public int Count{
                get{
                    return _values.Count;
                }
            }
        }
        
        class MyIterator:IIterator{
            IAggregate _iaggregate = null;
            int currentIndex = 0;
            
            public MyIterator(IAggregate ager){
                _iaggregate = ager;
            }
            
            public string FirstItem{ get{
                currentIndex = 0;
                return _iaggregate[currentIndex];
            }
                                   }
                                    
            public bool isDone{get {
               if(currentIndex<_iaggregate.Count)
                   return false;
                return true;
            }
           }
                          
        public string NextItem
    {
        get
        {
            currentIndex += 1;

            if (isDone == false)
            {
                return _iaggregate[currentIndex];
            }
            else
            {
                return string.Empty;
            }
        }
    }

        public string CurrentItem{
            get {
                return _iaggregate[currentIndex];
            }
        }
        }
        public static void Main(string[] args)
        {
            //Your code goes here
            Console.WriteLine("Hello, world!");
            MyAggregate aggr = new MyAggregate();

        aggr[0] = "1";
        aggr[1] = "2";
        aggr[2] = "3";
        aggr[3] = "4";
        aggr[4] = "5";
        aggr[5] = "6";
        aggr[6] = "7";
        aggr[7] = "8";
        aggr[8] = "9";
        aggr[9] = "10";

        IIterator iter = aggr.GetIterator();

        for (string s = iter.FirstItem; iter.isDone == false;  s = iter.NextItem )
        {
            Console.WriteLine(s);
        }

        }
    }
}
