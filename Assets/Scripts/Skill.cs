using UnityEngine;

public class Skill : IActiveAbility {
    private SkillConfig _config;

    private Skill[] _requiredSkills;
    private SkillLearnStatus _status = SkillLearnStatus.Undiscovered;

    public Skill(SkillConfig config) {
        _config = config;
    }

    public virtual void Activate() {
        Debug.Log(_config.Description);
    }
}