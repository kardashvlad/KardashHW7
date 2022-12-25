using System;

namespace _6._2
{
    class OldCharger
    {
        public string MatchThinSocket()
        {
            return "old charge";
        }
    }
    interface INewCharger
    {
        string MatchWideSocket();
    }
    class NewCharger : INewCharger
    {
        public string MatchWideSocket()
        {
            return "new charge";
        }
    }
    class Adapter : INewCharger
    {
        private readonly OldCharger adapter;
        public Adapter(OldCharger adapter)
        {
            this.adapter = adapter;
        }
        public string MatchWideSocket()
        {
            return adapter.MatchThinSocket();
        }
    }

    class ElectricityConsumer
    {
        public void Charge(INewCharger charger)
        {
            Console.WriteLine(charger.MatchWideSocket());
        }
    }

    public class AdapterDemo
    {
        static void Main()
        {
            var newCharger = new NewCharger();

            ElectricityConsumer notebook = new ElectricityConsumer();
            notebook.Charge(newCharger);

            var oldCharger = new OldCharger();
            var adapter = new Adapter(oldCharger);

            notebook.Charge(adapter);
            Console.ReadKey();
        }
    }
}
