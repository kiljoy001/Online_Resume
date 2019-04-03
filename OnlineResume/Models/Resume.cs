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
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IResumeTextBlock> Education { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IResumeTextBlock> Experience { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IResumeTextBlock> Projects { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IResumeSkill> Skills { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
