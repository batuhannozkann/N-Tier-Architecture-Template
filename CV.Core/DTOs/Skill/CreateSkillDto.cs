﻿using CV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Core.DTOs.Skill
{
    public class CreateSkillDto
    {
        public string Name { get; set; }
        public Level ProficiencyLevel { get; set; }
        public int PersonId { get; set; }
    }
}
