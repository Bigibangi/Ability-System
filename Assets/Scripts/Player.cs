using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private SkillFactory _skillFactory;

    private Graph<Skill> _skillsGraph;

    public int SkillCount {
        get { return _skillsGraph.Count; }
    }

    public IEnumerable<Skill> GetSkills() {
        yield return (Skill) _skillsGraph.GetAllNodes();
    }

    private void Awake() {
        var xmlSkillLoader = new XMLSkillLoader();
        var skills = new List<Skill>();
        for (int i = 0; i < 5; i++) {
            var skillConfig = xmlSkillLoader.SkillConfigLoad();
            skills.Add(_skillFactory.BuildSkill(skillConfig as SkillConfig));
        }
        _skillsGraph = new Graph<Skill>(skills);
    }
}