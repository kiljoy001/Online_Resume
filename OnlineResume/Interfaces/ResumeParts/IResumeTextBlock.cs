using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineResume.Interfaces.ResumeParts
{
    public interface IResumeTextBlock
    {
        string Title { get; set; }
        string StartDate { get; set; }
        string EndDate { get; set; }
        string Description { get; set; }
    }
}
