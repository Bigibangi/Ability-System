using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private SkillFactory _skillFactory;

    [SerializeField]
    private List<SkillConfig> _skillConfigs;

    private Graph<Skill> _skillsGraph;

    public int SkillCount {
        get { return _skillsGraph.Count; }
    }

    public IEnumerable<Skill> GetSkills() {
        return _skillsGraph.Nodes;
    }

    private void Awake() {
        var skillList = new List<Skill>();
        foreach (var skillConfig in _skillConfigs) {
            skillList.Add(_skillFactory.BuildSkill(skillConfig));
        }
        _skillsGraph = new Graph<Skill>(skillList);
    }
}