using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SQLGen
{
    public static class JSStaticClass
    {
        static Hashtable _TableColumns = new Hashtable();
        public static Hashtable TableColumns 
        {
            get
            {
                return _TableColumns;
            }

            set
            {
                _TableColumns = value ;
            }
        }

        static Hashtable _WhereColumns = new Hashtable();
        public static Hashtable WhereColumns
        {
            get
            {
                return _WhereColumns;
            }

            set
            {
                _WhereColumns = value;
            }
        }
    }
}
