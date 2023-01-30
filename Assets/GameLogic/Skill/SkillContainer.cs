using System.Collections.Generic;
using UnityEngine;

public class SkillContainer : MonoBehaviour {

    #region Editor

    [SerializeField]
    private SkillFactory _skillFactory;

    [SerializeField]
    private List<SkillSettings> _skillSettings;

    #endregion Editor

    #region Fields

    private int _points;
    private Graph<Skill> _skillsGraph;

    #endregion Fields

    #region Properties

    public int SkillCount {
        get { return _skillsGraph.Count; }
    }

    #endregion Properties

    #region MonoBehaviour

    private void Awake() {
        _skillsGraph = new Graph<Skill>();
        SetUp(_skillsGraph);
        //_skillsGraph = new Graph<Skill>(skillList);
        //foreach (var node in _skillsGraph.Nodes) {
        //    var skill = node.obj as Skill;
        //    if (skill.Config.RequiredSkills.Count > 0) {
        //        foreach (var skillConfig in skill.Config.RequiredSkills) {
        //            var x = _skillsGraph
        //                .Nodes
        //                .Select(x => x)
        //                .Where(x => x.obj.RequiredSkills.Contains(skill));
        //            node.Connect(x as Node<Skill>);
        //        }
        //    }
        //}
    }

    #endregion MonoBehaviour

    public Graph<Skill> GetSkills() {
        return _skillsGraph;
    }

    public void EarnPoint(int points) {
        _points = points;
    }

    private void SetUp(Graph<Skill> skillsGraph) {
        var skillList = new List<Skill>();
        foreach (var skillConfig in _skillSettings) {
            var skill = _skillFactory.BuildSkill(skillConfig);
            skillList.Add(skill);
        }
        _skillsGraph = new Graph<Skill>(skillList);
    }
}