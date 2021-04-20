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
    class ConsoleController
    {
        #region Private

        private IViewer _illustrator;
        private IConditionReader _reader;
        private TicketValidatorFactory _ticketCheckerFactory;
        private INumbericsValidator _numbersChecker;
        private TicketsFillerFactory _fillerFactory;

        #endregion

        public ConsoleController(string pathToFile, string startRange, string finishRange, 
                IConditionReader reader, TicketValidatorFactory ticketCheckerFactory, 
                TicketsFillerFactory fillerFactory, INumbericsValidator numbersChecker,
                IViewer illustrator)
        {
            PathToFile = pathToFile;
            StartRange = startRange;
            FinishRange = finishRange;
            _illustrator = illustrator;
            _reader = reader;
            _ticketCheckerFactory = ticketCheckerFactory;
            _numbersChecker = numbersChecker;
            _fillerFactory = fillerFactory;
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
                    _illustrator.ShowMessage(DefaultSettings.INSTRUCTION);
                    return;
                }

                string condition = _reader.GetCondition();

                if (!_numbersChecker.IsNumber())
                {
                    string message = string.Format("{0}\n{1}",
                            DefaultSettings.WRONG_FORMAT_NUMBERS, DefaultSettings.INSTRUCTION);
                    _illustrator.ShowMessage(message);
                    return;
                }

                int firstNumber = checked(int.Parse(StartRange));
                int lastNumber = checked(int.Parse(FinishRange));
                ITicketValidator checker = _ticketCheckerFactory.Create(condition, firstNumber, 
                        lastNumber);

                if (!checker.IsRightCondition() || !checker.IsFallenTheRange())
                {
                    string message = string.Format("{0}\n{1}",
                            DefaultSettings.WRONG_ARGS, DefaultSettings.INSTRUCTION);
                    _illustrator.ShowMessage(message);
                    return;
                }

                ITicketsFiller ticketsCreator = _fillerFactory.Create(DefaultSettings.NUMBERICS_COUNT, 
                        firstNumber, lastNumber);
                IEnumerable<ITicket> tickets = ticketsCreator.GetTickets();
                ITicketAnalyzer analyzer = GetLuckyTicketAnalyzer(tickets, condition);
                IEnumerable<ITicket> luckyTickets = analyzer.GetLuckyTickets();
                _illustrator.ShowLuckyTickets(luckyTickets, analyzer.LickyTicketsCount);
            }
            catch (OverflowException ex)
            {
                string message = string.Format("{0}\n{1}", ex.Message, DefaultSettings.INSTRUCTION);
                _illustrator.ShowMessage(message);
            }
            catch (IOException ex)
            {
                string message = string.Format("{0}\n{1}", ex.Message, DefaultSettings.INSTRUCTION);
                _illustrator.ShowMessage(message);
            }
            catch(NullReferenceException ex)
            {
                string message = string.Format("{0}\n{1}", ex.Message, DefaultSettings.INSTRUCTION);
                _illustrator.ShowMessage(message);
            }
        }

        public ITicketAnalyzer GetLuckyTicketAnalyzer(IEnumerable<ITicket> tickets, 
                string condition)
        {
            TicketAnalyzerFactory factory;

            if (condition == DefaultSettings.MOSKOW_CONDITION)
            {
                factory = new MoskowTicketAnalyzerFactory();
            }
            else
            {
                factory = new PiterTicketAnalyzerFactory();
            }

            return factory.Create(tickets);
        }
    }
}
