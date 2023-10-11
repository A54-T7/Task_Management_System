using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Commands.Contracts;
using Task_Management.Core.Contracts;

namespace Task_Management.Core
{
    internal class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string EmptyCommandError = "Command cannot be empty.";
        private const string ReportSeparator = "####################";

        private readonly ICommandFactory commandFactory;

        public Engine(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    string inputLine = Console.ReadLine().Trim();

                    if (inputLine == string.Empty)
                    {
                        Console.WriteLine(EmptyCommandError);
                        continue;
                    }

                    if (inputLine.Equals(TerminationCommand, StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }

                    ICommand command = commandFactory.Create(inputLine);
                    string result = command.Execute();
                    Console.WriteLine(result.Trim());
                    Console.WriteLine(ReportSeparator);
                }
                catch (Exception ex)
                {
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        Console.WriteLine(ex);
                    }
                    Console.WriteLine(ReportSeparator);
                }
            }
        }
    }
}
