using OnlineResume.Interfaces;
using OnlineResume.Interfaces.ResumeParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineResume.Models
{
    public class Resume : IResume
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public List<IResumeTextBlock> Education { get; set;}
        public List<IResumeTextBlock> Experience { get; set; }
        public List<IResumeTextBlock> Projects { get; set; }
        public List<IResumeSkill> Skills { get; set; }
    }
}
