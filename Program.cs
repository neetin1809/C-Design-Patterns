using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverePattern
{

    interface ISubject
    {
        void Subscribe(Observerer observerer);
        void unsubscribe(Observerer observerer);
        void Notify();
    }

    public class Subject : ISubject
    {
        public List<Observerer> observerers = new List<Observerer>();

        private int _inv;

        public int Inventory { 
            get
            {
                return _inv;
            } 
            set
            {
                if(value>_inv)
                    Notify();
                _inv= value;
            }
             }



        public void Subscribe(Observerer observerer)
        {
            observerers.Add(observerer);
        }

        public void unsubscribe(Observerer observerer)
        {
            observerers.Remove(observerer);
        }

        public void Notify()
        {
            observerers.ForEach(x => x.Update());
        }
    }
   interface IObserverer{
    void Update();
}

   public class Observerer : IObserverer
	{
        public string observererName { get; set; }

        public Observerer(string name)
        {
            this.observererName = name;
        }
        public void Update()
        {
            Console.WriteLine("{0} the new product has arrived at the market ", this.observererName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Subject subject = new Subject();

            Observerer obj1 = new Observerer("Observere 1");
            subject.Subscribe(obj1);

            subject.Subscribe(new Observerer("Observer 2"));
            subject.Inventory++;

            subject.unsubscribe(obj1);
            subject.Subscribe(new Observerer("Observer 3"));
            subject.Inventory++;

            Console.ReadLine();
        }
    }
}
