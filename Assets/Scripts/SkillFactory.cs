using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillFactory : ScriptableObject {

    [SerializeField]
    private List<SkillConfig> _skillList;

    public List<SkillConfig> SkillList {
        get {
            return _skillList;
        }
    }

    public IEnumerable<Skill> BuildSkillLazy(
        SkillLearnStatus learnStatus = SkillLearnStatus.Undiscovered) {
        foreach (var skillConfig in _skillList) {
            yield return BuildSkill(skillConfig);
        }
    }

    public Skill BuildSkill(SkillConfig skillConfig) {
        return new Skill(skillConfig);
    }
}