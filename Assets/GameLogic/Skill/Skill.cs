using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.LightingExplorerTableColumn;

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

    public override int GetHashCode() {
        return this.GetHashCode();
    }

    public override bool Equals(object obj) {
        if (obj == null) return false;
        if (!(obj is Node<DataType>))
            return false;
        if (obj.GetHashCode() != GetHashCode()) return false;
        return this.Equals(obj);
    }
}