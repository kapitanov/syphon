using System;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using ITGlobal.CommandLine;
using Syphon;

namespace syphon_term
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.InputEncoding = Encoding.GetEncoding(1251);
            Console.OutputEncoding = Encoding.UTF8;

            var engine = new SyphonEngine(Preset.PetrovichRu, Level.L3, true);
            while (true)
            {
                using (CLI.WithForeground(ConsoleColor.Magenta))
                {
                    Console.Write(">");
                }

                var str = Console.ReadLine();
                var res = engine.Process(str);

                Console.WriteLine();
                res.Render(new ConsoleResultRenderer());
            }
        }

        private sealed class ConsoleResultRenderer : IResultRenderer
        {
            public void AppendUnchanged(string str)
            {
                using (CLI.WithForeground(ConsoleColor.White))
                {
                    Console.Write(str);
                }
            }

            public void AppendChanged(string str)
            {
                using (CLI.WithForeground(ConsoleColor.Red))
                {
                    Console.Write(str);
                }
            }

            public void End()
            {
                Console.WriteLine();
            }
        }
    }
}