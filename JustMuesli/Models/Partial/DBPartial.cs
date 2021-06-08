using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMuesli.Models
{
    partial class DB
    {
        private static DB _instanse;
        public static DB Instanse
        {
            get
            {
                _instanse = _instanse ?? new DB();
                return _instanse;
            }

        }

    }

}
