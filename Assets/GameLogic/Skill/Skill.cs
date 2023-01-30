using System.Collections.Generic;
using UnityEngine;

public class Skill : IActiveAbility {
    private SkillSettings _config;

    private List<Skill> _requiredSkills;
    private SkillLearnStatus _status = SkillLearnStatus.Undiscovered;

    public SkillLearnStatus Status {
        get { return _status; }
        set { _status = value; }
    }

    public SkillSettings Config => _config;

    public List<Skill> RequiredSkills => _requiredSkills;

    public Skill(SkillSettings skillConfig) {
        _config = skillConfig;
        _requiredSkills = new List<Skill>();
    }

    public virtual void Activate() {
        Debug.Log(_config.Description);
    }

    public void AddRequiredSkill(Skill skill) {
        _requiredSkills.Add(skill);
    }
}