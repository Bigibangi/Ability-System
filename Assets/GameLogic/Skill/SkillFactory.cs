using UnityEngine;

[CreateAssetMenu]
public class SkillFactory : ScriptableObject {

    [SerializeField]
    private GameObject _skillPrefab;

    private GameObject _skillTree;

    private void Awake() {
        _skillTree = GameObject.FindGameObjectWithTag("SkillTree");
    }

    public Skill BuildSkill(SkillSettings skillConfig) {
        var skillIcon = Instantiate(_skillPrefab);
        var skill = new Skill(skillConfig);
        skillIcon.name = skillConfig.Name;
        skillIcon.transform.SetParent(_skillTree.transform, false);
        var skillView = skillIcon.GetComponentInChildren<SkillView>();
        skillView.Skill = skill;
        return skill;
    }
}