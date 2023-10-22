using Task_Management.Core.Contracts;
using Task_Management.Core;
using Task_Management.Models;

namespace Task_Management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine engine = new Core.Engine(commandFactory);
            engine.Start();
            string name = "";
            Member member = new Member(name);
        }
    }
}