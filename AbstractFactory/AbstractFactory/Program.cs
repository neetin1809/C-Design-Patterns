using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    interface IDumb
    {
        string Name();
    }
    interface ISmart
    {
        string Name();
    }
    class Asha : IDumb
    {

        public string Name()
        {
            return "Asha";
        }
    }

    class Genie:IDumb
    {
        public string Name()
        {
            return "Genie";
        }
    }
    class Primo : IDumb
    {
        public string Name()
        {
            return "Primo";
        }
    }
    class Lumia:ISmart
    {

        public string Name()
        {
            return "Lumia";
        }
    }

    class GaalxyS2 : ISmart
    {

        public string Name()
        {
            return "GaalxyS2";
        }
    }

    class Duos :ISmart
    {
        public string Name()
        {
            return "Duos";
        }
    }

    class Titan:ISmart
    {
        public string Name()
        {
            return "Titan";
        }
    }

    interface iPhoneFactory
    {
        ISmart GetSmart();
        IDumb GetDumb();
    }

    class SamsungFactory:iPhoneFactory
    {

        public ISmart GetSmart()
        {
            return new GaalxyS2();
        }

        public IDumb GetDumb()
        {
            return new Genie();
        }
    }
    class NokiaFactory : iPhoneFactory
    {

        public ISmart GetSmart()
        {
          return new Lumia();
        }

        public IDumb GetDumb()
        {
            return new Asha();
        }
    }

    class HTCFactory:iPhoneFactory
    {

        public ISmart GetSmart()
        {
          return new Titan();
        }

        public IDumb GetDumb()
        {
            return new Primo();
        }
    }
    enum MANUFACTURERS
    {
        SAMSUNG,
        HTC,
        NOKIA
    }
    class PhoneTypeChecker
{
    ISmart sam;
    IDumb htc;
    iPhoneFactory factory;
    MANUFACTURERS manu;

    public PhoneTypeChecker(MANUFACTURERS m)
    {
        manu = m;
    }

    public void CheckProducts()
    {
        switch (manu)
        {
            case MANUFACTURERS.SAMSUNG:
                factory = new SamsungFactory();
                break;
            case MANUFACTURERS.HTC:
                factory = new HTCFactory();
                break;
            case MANUFACTURERS.NOKIA:
                factory = new NokiaFactory();
                break;
        }

        Console.WriteLine(manu.ToString() + ":\nSmart Phone: " +
        factory.GetSmart().Name() + "\nDumb Phone: " + factory.GetDumb().Name());
    }
}
    class Program
    {
        static void Main(string[] args)
        {
            PhoneTypeChecker checker = new PhoneTypeChecker(MANUFACTURERS.SAMSUNG);

            checker.CheckProducts();

            Console.ReadLine();

            checker = new PhoneTypeChecker(MANUFACTURERS.HTC);

            checker.CheckProducts();
            Console.ReadLine();

            checker = new PhoneTypeChecker(MANUFACTURERS.NOKIA);

            checker.CheckProducts();
            Console.Read();
        }
    }
}
