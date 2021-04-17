using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class NumbericsValidatorFactory
    {
        #region Private

        private string[] _numbers;

        #endregion

        public NumbericsValidatorFactory(params string[] numbers)
        {
            _numbers = numbers;
        }

        public NumbericsValidator NumbericsValidator
        {
            get => default;
            set
            {
            }
        }

        public virtual INumbericsValidator Create()
        {
            return new NumbericsValidator();
        }
    }
}
