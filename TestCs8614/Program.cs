using System;
using InterfaceLibrary;

namespace TestCs8614
{
    interface IInterfaceInThisAssembly
    {
        void Test(int? nullableInt);
    }

    class ImplementsThisAssemblyInterface : IInterfaceInThisAssembly
    {
        // No warning
        public void Test(int? nullableInt)
            => Console.WriteLine(nullableInt ?? Int32.MinValue);
    }

    class ImplementsOtherAssemblyInterface : IInterfaceInOtherAssembly
    {
        // warning CS8614: Nullability of reference types in type of parameter 'nullableInt' doesn't match
        //  implicitly implemented member 'void IInterfaceInOtherAssembly.Test(int? nullableInt)'.
        public void Test(int? nullableInt)
            => Console.WriteLine(nullableInt ?? Int32.MinValue);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var implementsThisAssembly = new ImplementsThisAssemblyInterface();
            implementsThisAssembly.Test(null);
            implementsThisAssembly.Test(100);

            Console.WriteLine();

            var implementsOtherAssembly = new ImplementsOtherAssemblyInterface();
            implementsOtherAssembly.Test(null);
            implementsOtherAssembly.Test(100);

            Console.WriteLine();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
