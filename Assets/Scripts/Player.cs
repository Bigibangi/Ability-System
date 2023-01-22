using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private SkillFactory _skillFactory;

    private List<Skill> _skills = new List<Skill>();

    public int SkillCount {
        get { return _skills.Count; }
    }

    public IEnumerable<Skill> GetSkills() {
        foreach (var skill in _skills) {
            yield return skill;
        }
    }

    private void Awake() {
        var xmlSkillLoader = new XMLSkillLoader();
        for (int i = 0; i < 5; i++) {
            var skillConfig = xmlSkillLoader.SkillConfigLoad();
            _skills[i] = _skillFactory.BuildSkill((SkillConfig) skillConfig);
        }
    }
}