using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillFactory : ScriptableObject {

    public Skill BuildSkill(SkillConfig skillConfig) {
        return new Skill(skillConfig);
    }
}