using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class ConditionReaderFactory
    {

        #region Private

        private string _pathToFile;

        #endregion

        public ConditionReaderFactory(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public virtual IConditionReader Create()
        {
            return new ConditionReader(_pathToFile);
        }
    }
}
