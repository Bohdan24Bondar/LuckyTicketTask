using LuckyTicketLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketTask
{
    class ConsoleApplication
    {
        private Viewer _consoleViewer;

        public ConsoleApplication(string pathToFile, string startRange, string finishRange)
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
                    _consoleViewer.ShowInstruction(DefaultSettings.INSTRUCTION);
                    return;
                }

                ConditionReader reader = new ConditionReader(PathToFile);
                string condition = reader.GetCondition();
                NumbericsValidator numberChecker = new NumbericsValidator();

                if (!numberChecker.IsNumber())
                {
                    _consoleViewer.ShowInstruction(DefaultSettings.INSTRUCTION);
                    return;
                }

                NumberConvertor convertor = new NumberConvertor();
                int firstNumber = convertor.ConvertNumber(StartRange);
                int lastNumber = convertor.ConvertNumber(FinishRange);
                TicketValidator checker = new TicketValidator(condition, firstNumber, lastNumber);

                if (!checker.IsRightCondition() || !checker.IsFallenTheRange())
                {
                    _consoleViewer.ShowInstruction(DefaultSettings.INSTRUCTION);
                    return;
                }

                TicketsCreator creator = new TicketsCreator(DefaultSettings.NUMBERICS_COUNT, firstNumber, lastNumber);
                List<ITicket> tickets = creator.FillTickets();
                ITicketAnalyzer analyzer = GetLuckyTicketAnalyzer(tickets, condition);
                IEnumerable<ITicket> luckyTickets = analyzer.SearchLuckyTickets();
                _consoleViewer.ShowLuckyTickets(luckyTickets, analyzer.LickyTicketsCount);
            }
            catch (IOException ex)
            {
                _consoleViewer.ShowInstruction(ex.Message + DefaultSettings.INSTRUCTION);
            }
        }

        public ITicketAnalyzer GetLuckyTicketAnalyzer(List<ITicket> tickets, string condition)
        {
            TicketAnalyzerFactory factory;

            if (condition == DefaultSettings.MOSKOW_CONDITION)
            {
                factory = new MoskowTicketAnalyzerFactory(tickets);
            }
            else
            {
                factory = new PiterTicketAnalyzerFactory(tickets);
            }

            return factory.Create();
        }

    }
}
