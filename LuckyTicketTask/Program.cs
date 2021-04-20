using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuckyTicketLibrary;

namespace LuckyTicketTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConditionReaderFactory readerFactory = new ConditionReaderFactory();
                IConditionReader reader = readerFactory.Create(DefaultSettings.PATH_TO_FILE);
                NumbericsValidatorFactory numbersCheckerFactory = new NumbericsValidatorFactory();
                INumbericsValidator numbersChecker = numbersCheckerFactory.Create();
                TicketValidatorFactory ticketCheckerFactory = new TicketValidatorFactory();
                TicketsFillerFactory fillerFactory = new TicketsFillerFactory();
                IViewer illustrator = new ConsoleView();

                ConsoleController application = new ConsoleController(DefaultSettings.PATH_TO_FILE,
                        args[0], args[1], reader, ticketCheckerFactory, fillerFactory, numbersChecker,
                        illustrator);

                application.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(DefaultSettings.INSTRUCTION);
            }

            Console.ReadKey();
        }
    }
}
