﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Subcontractor
{
    public interface ISubcontractorUniquenessChecker
    {
        bool ExistsByName(string raisonSocial);
    }
}
