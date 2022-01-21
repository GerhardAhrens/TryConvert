//-----------------------------------------------------------------------
// <copyright file="ComparerClass1.cs" company="Lifeprojects.de">
//     Class: ComparerClass1
//     Copyright © Lifeprojects.de 2022
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>21.01.2022 21:00:50</date>
//
// <summary>
// Klasse für 
// </summary>
//-----------------------------------------------------------------------

namespace TryConvertDemo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class ComparerClass1 : IComparable<ComparerClass1>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparerClass1"/> class.
        /// </summary>
        public ComparerClass1(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        int IComparable<ComparerClass1>.CompareTo(ComparerClass1 obj)
        {
            ComparerClass1 objectCopy = (ComparerClass1)obj;
            if (this.Id > objectCopy.Id)
            {
                return 1;
            }
            if (this.Id < objectCopy.Id)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static IComparer<ComparerClass1> ByName
        {
            get
            {
                return ((IComparer<ComparerClass1>)new SortByNameClass());
            }
        }

        public static IComparer<ComparerClass1> ById
        {
            get
            {
                return ((IComparer<ComparerClass1>)new SortByIdClass());
            }
        }

        public override string ToString()
        {
            return $"{this.Name} : {this.Id}";
        }

        private class SortByNameClass : IComparer<ComparerClass1>
        {
            public int Compare(ComparerClass1 first, ComparerClass1 second)
            {
                ComparerClass1 objectFirst = (ComparerClass1)first;
                ComparerClass1 objectSecond = (ComparerClass1)second;

                return string.Compare(objectFirst.Name, objectSecond.Name);
            }
        }

        private class SortByIdClass : IComparer<ComparerClass1>
        {
            public int Compare(ComparerClass1 first, ComparerClass1 second)
            {
                ComparerClass1 objectFirst = (ComparerClass1)first;
                ComparerClass1 objectSecond = (ComparerClass1)second;

                return ((IComparable<ComparerClass1>)objectFirst).CompareTo(second);
            }
        }
    }
}
