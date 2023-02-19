using UnityEngine;

public class SkillController {
    private Skill _skill;

    public SkillController(Skill skill) {
        _skill = skill;
    }

    public void LearnSkill(ref int remainedPoints) {
        remainedPoints -= _skill.Config.PointCost;
        if (remainedPoints >= 0) {
            _skill.Status = SkillLearnStatus.Discovered;
        }
        else remainedPoints += _skill.Config.PointCost;
    }

    public int ForgetSkill() {
        Debug.Log("Skill Forgotten");
        _skill.Status = SkillLearnStatus.Undiscovered;
        return _skill.Config.PointCost;
    }
}