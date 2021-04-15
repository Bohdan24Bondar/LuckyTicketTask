using LuckyTicketLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketTask
{
    class ConsoleController
    {
        private Viewer _consoleViewer;

        public ConsoleController(string pathToFile, string startRange, string finishRange)
        {
            PathToFile = pathToFile;
            StartRange = startRange;
            FinishRange = finishRange;
            _consoleViewer = new Viewer();
        }

        public string PathToFile { get; private set; }

        public string StartRange { get; private set; }

        public string FinishRange { get; private set; }

        public void Run()
        {
            try
            {
                if (!File.Exists(PathToFile))
                {
                    // todo _consoleViewer. 
                    return;
                }

                ConditionReader reader = new ConditionReader(PathToFile);
                string condition = reader.GetCondition();
                NumbericsValidator numberChecker = new NumbericsValidator();

                if (!numberChecker.IsNumber())
                {
                    // todo _consoleViewer. 
                    return;
                }

                NumberConvertor convertor = new NumberConvertor();
                int firstNumber = convertor.ConvertNumber(StartRange);
                int lastNumber = convertor.ConvertNumber(FinishRange);
                TicketValidator checker = new TicketValidator(condition, firstNumber, lastNumber);

                if (!checker.IsRightCondition() || !checker.IsFallenTheRange())
                {
                    // todo _consoleViewer. 
                    return;
                }

                TicketsCreator creator = new TicketsCreator(DefaultSettings.NUMBERICS_COUNT, firstNumber, lastNumber);
                List<Ticket> tickets = creator.FillTickets();

                LuckyTicketsAnalyzer analyzer;

                if (condition == DefaultSettings.MOSKOW_CONDITION)
                {
                    analyzer = new MoskowLuckyTicketsAnalyzer(tickets);
                }
                else
                {
                    analyzer = new PiterLuckyTicketsAnalyzer(tickets);
                }

                IEnumerable<Ticket> luckyTickets = analyzer.SearchLuckyTickets();

                //_consoleViewer.ShowLuckyTickets(luckyTickets, analyzer.LickyTicketsCount);
            }
            catch (IOException)
            {
                throw;
            }
        }
    }
}
