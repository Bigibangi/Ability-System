using UnityEngine;

[CreateAssetMenu]
public class SkillFactory : ScriptableObject {

    [SerializeField]
    private GameObject _skillPrefab;

    public Skill BuildSkill(SkillSettings skillConfig) {
        var skill = new Skill(skillConfig);
        return skill;
    }
}