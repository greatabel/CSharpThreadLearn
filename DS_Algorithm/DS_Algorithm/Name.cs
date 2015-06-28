using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_Algorithm
{
    public struct Name
    {
        private string fname, mname, lname;
        public Name(string first, string middle, string last)
        {
            fname = first;
            mname = middle;
            lname = last;
        }
        public string firstName
        {
            get
            {
                return fname;
            }
            set
            {
                fname = firstName;
            }
        }
        public string middleName
        {
            get
            {
                return mname;
            }
            set
            {
                mname = middleName;
            }
        }
        public string lastName
        {
            get
            {
                return lname;
            }
            set
            {
                lname = lastName;
            }
        }
        public override string ToString()
        {
            return (String.Format("{0} {1} {2}", fname, mname, lname));
        }
        public string Initials()
        {
            return (String.Format("{0}{1}{2}", fname.Substring(0, 1), mname.Substring(0, 1), lname.Substring(0, 1)));
        }



    }
}
