using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillFactory : ScriptableObject {

    public Skill BuildSkill(
        SkillConfig skillConfig,
        SkillLearnStatus learnStatus = SkillLearnStatus.Undiscovered) {
        var skill = new Skill(skillConfig);
        skill.Status = learnStatus;
        return skill;
    }
}