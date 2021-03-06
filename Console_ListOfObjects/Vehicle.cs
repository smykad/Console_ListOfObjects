﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ListOfObjects
{
    /// <summary>
    /// ******************************************************
    ///             VEHICLE CLASS
    /// ******************************************************
    /// </summary>
    public class Vehicle
    {
        public enum Model
        {
            NONE,
            CHEVY,
            FORD,
            TOYOTA,
            HONDA,
            DONE
        }
        //
        // variables for class to get/set
        //
        private string _name;
        private int _year;
        private bool _fwd;
        private Model _make;

        public Model Make
        {
            get { return _make; }
            set { _make = value; }
        }

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

        //
        // for creating a new vehicle
        //

        public Vehicle(string name,int year, bool fwd, Model model)
        {
            _name = name;
            _year = year;
            _fwd = fwd;
            _make = model;
        }
    }
}
