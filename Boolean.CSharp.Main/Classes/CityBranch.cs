﻿using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class CityBranch : IBranch
    {
        public string Name => nameof(CityBranch);

        public List<IAccount> accounts => throw new NotImplementedException();

        public bool isIsBranch(string name)
        {
            throw new NotImplementedException();
        }
    }
}
