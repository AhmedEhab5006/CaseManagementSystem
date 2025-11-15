using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum CaseReAssignmentValidation
    {
        Done,
        AssigneeNotFound,
        AssigneeAlreadyExists,
        CaseNotFound,
        Error,
        ArenotAssignedToCase
    }
}
