﻿using AutoMapper;
using BravoiSkill.Application.Services.Interfaces;
using BravoiSkill.Domain.Interfaces.Repositories.Users;
using BravoiSkill.Application.DTO.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravoiSkill.Application.DTO.Users;

namespace BravoiSkill.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private ISkillRepository _skillRepository;
        private IMapper _mapper;

        public SkillService(ISkillRepository skillRepository,
            IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public IEnumerable<Skill> GetAll()
        {
            var skillsDb = _skillRepository.GetListOfSkills();
            var skillsDto = skillsDb
                .Select(skillDb => _mapper.Map<Skill>(skillDb))
                .ToList();

            return skillsDto;
        }

        public Skill GetById(int id)
        {
            var skillDb = _skillRepository.GetSkillById(id);
            return _mapper.Map<Skill>(skillDb);
        }

        public void Create(Skill skill)
        {
            var skillEntity = _mapper.Map<Domain.Entities.Users.Skill>(skill);
            _skillRepository.Create(skillEntity);
        }

        public async Task Edit(int id, Skill skill)
        {
            skill.Validate();
            if (skill.HasErrors)
                throw new Exception(skill.Errors[0]);

            var skillEntity = _skillRepository.GetSkillById(id);
            if (skillEntity == null)
                throw new Exception("Skill does not exist in database");
            skill.SkillId = skillEntity.SkillId;
            _mapper.Map(skill, skillEntity);
            skillEntity.SkillCategory = null;
            _skillRepository.Update(skillEntity);
        }
        public void Delete(int id)
        {
            var skillEntity = _skillRepository.GetSkillById(id);
            if (skillEntity == null)
                throw new Exception("Skill does not exist in database");

            _skillRepository.Delete(skillEntity);
        }
    }
}
