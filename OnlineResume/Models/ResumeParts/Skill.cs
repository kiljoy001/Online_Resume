using OnlineResume.Interfaces.ResumeParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineResume.Models
{
    public class Skill : IResumeSkill
    {
        public string SkillName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal SelfSkillRating { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
