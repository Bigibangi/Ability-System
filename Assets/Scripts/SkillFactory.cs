using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillFactory : ScriptableObject {

    public Skill BuildSkill(SkillConfig skillConfig) {
        var skill = new Skill(skillConfig);
        skill.Status = SkillLearnStatus.Undiscovered;
        return skill;
    }
}