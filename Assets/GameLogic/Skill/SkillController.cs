using UnityEngine;

public class SkillController {
    private Skill _skill;

    public SkillController(Skill skill) {
        _skill = skill;
    }

    public int LearnSkill(int remainedPoints) {
        remainedPoints -= _skill.Config.PointCost;
        if (remainedPoints >= 0) {
            _skill.Status = SkillLearnStatus.Discovered;
            return -_skill.Config.PointCost;
        }
        return 0;
    }

    public int ForgetSkill() {
        _skill.Status = SkillLearnStatus.Undiscovered;
        return _skill.Config.PointCost;
    }
}