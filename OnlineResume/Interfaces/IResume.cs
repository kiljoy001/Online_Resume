using OnlineResume.Interfaces.ResumeParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineResume.Interfaces
{
    public interface IResume
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        List<IResumeTextBlock> Education { get; set; }
        List<IResumeTextBlock> Experience { get; set; }
        List<IResumeTextBlock> Projects { get; set; }
        List<IResumeSkill> Skills { get; set; }

    }
}
