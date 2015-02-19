using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ToolsTest.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyName an = new AssemblyName("TestEmit");

            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.RunAndSave);

            ModuleBuilder mb = ab.DefineDynamicModule("TestEmitModule", "TestEmit.exe");

            TypeBuilder tb = mb.DefineType("TestEmitClass", TypeAttributes.Public);

            MethodBuilder methodBuilder = tb.DefineMethod("SayHelloMethod",
                MethodAttributes.Public | MethodAttributes.Static, null, null);

            ILGenerator ilGenerator = methodBuilder.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldstr,"hello,first emit!");

            ilGenerator.Emit(OpCodes.Call, typeof (Console).GetMethod("ReadLine"));

            ilGenerator.Emit(OpCodes.Pop);

            ilGenerator.Emit(OpCodes.Ret);

            Type emitType = tb.CreateType();

            ab.SetEntryPoint(emitType.GetMethod("SayHelloMethod"));

            ab.Save("TestEmit.exe");

            Console.WriteLine("hello,the first emit test class has been generated for you.");

            Console.ReadLine();
        }
    }
}
