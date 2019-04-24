﻿using System;
using System.Collections.Generic;
using System.Text;

namespace USFMToolsSharp.Models.Markers
{
    public abstract class Marker
    {
        public Marker()
        {
            Contents = new List<Marker>();
        }
        public List<Marker> Contents;
        public abstract string Identifier { get; }
        public virtual List<Type> AllowedContents {
            get {
                return new List<Type>();
            }
        }

        /// <summary>
        /// Populates properties on the marker
        /// </summary>
        /// <param name="input"></param>
        public virtual void Populate(string input)
        {

        }

        public bool TryInsert(Marker input)
        {
            if(Contents.Count > 0 && Contents[Contents.Count - 1].TryInsert(input))
            {
                return true;
            }
            if (AllowedContents.Contains(input.GetType()))
            {
                Contents.Add(input);
                return true;
            }
            return false;
        }
    }
}
