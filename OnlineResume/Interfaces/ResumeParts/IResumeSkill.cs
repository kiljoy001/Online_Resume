using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineResume.Interfaces.ResumeParts
{
    public interface IResumeSkill
    {
        string SkillName { get; set; }
        decimal SelfSkillRating { get; set; } 
    }
}
