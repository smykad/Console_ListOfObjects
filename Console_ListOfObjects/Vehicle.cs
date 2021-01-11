using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ListOfObjects
{
    public class Vehicle
    {
        private string _name;
        private int _year;
        private bool _fwd;

        public bool Fwd
        {
            get { return _fwd; }
            set { _fwd = value; }
        }


        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Vehicle()
        {

        }

        public Vehicle(string name,int year, bool fwd)
        {
            _name = name;
            _year = year;
            _fwd = fwd;
        }
    }
}
