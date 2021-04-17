using LuckyTicketLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketTask
{
    class ConsoleApplication
    {

        #region Private

        private Viewer _consoleViewer;

        #endregion

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

                IConditionReader reader = GetConditionReader();
                string condition = reader.GetCondition();
                INumbericsValidator numberChecker = GetINumbericsValidator();

                if (!numberChecker.IsNumber())
                {
                    _consoleViewer.ShowInstruction(DefaultSettings.INSTRUCTION);
                    return;
                }

                //NumberConvertor convertor = new NumberConvertor();
                int firstNumber = int.Parse(StartRange);
                int lastNumber = int.Parse(FinishRange);
                ITicketValidator checker = GetTicketValidator(condition, firstNumber, lastNumber);

                if (!checker.IsRightCondition() || !checker.IsFallenTheRange())
                {
                    _consoleViewer.ShowInstruction(DefaultSettings.INSTRUCTION);
                    return;
                }

                ITicketsCreator creator = GetTicketsCreator(DefaultSettings.NUMBERICS_COUNT, 
                        firstNumber, lastNumber);
                IEnumerable<ITicket> tickets = creator.GetTickets();
                ITicketAnalyzer analyzer = GetLuckyTicketAnalyzer(tickets, condition);
                IEnumerable<ITicket> luckyTickets = analyzer.SearchLuckyTickets();
                _consoleViewer.ShowLuckyTickets(luckyTickets, analyzer.LickyTicketsCount);
            }
            catch (IOException ex)
            {
                _consoleViewer.ShowInstruction(ex.Message + DefaultSettings.INSTRUCTION);
            }
        }

        public ITicketAnalyzer GetLuckyTicketAnalyzer(IEnumerable<ITicket> tickets, 
                string condition)
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

        public ITicketsCreator GetTicketsCreator(int numbericsCount, int startRange, 
                int finishRange)
        {
            TicketsCreatorFactory creatorFactory = new TicketsCreatorFactory(numbericsCount,
                    startRange, finishRange);

            return creatorFactory.Create();
        }

        public IConditionReader GetConditionReader()
        {
            ConditionReaderFactory readerFactory = new ConditionReaderFactory(PathToFile);

            return readerFactory.Create();
        }

        public ITicketValidator GetTicketValidator(string condition, int startRange,
                int finishRange)
        {
            TicketValidatorFactory validatorFactory = new TicketValidatorFactory(condition, 
                    startRange, finishRange);

            return validatorFactory.Create();
        }

        public INumbericsValidator GetINumbericsValidator()
        {
            NumbericsValidatorFactory factory = new NumbericsValidatorFactory();

            return factory.Create();
        }
    }
}
