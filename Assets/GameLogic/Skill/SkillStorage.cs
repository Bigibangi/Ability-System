using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillStorage : MonoBehaviour {

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
    }

    #endregion MonoBehaviour

    public Action<int> OnSkillPointsChanged;

    public Graph<Skill> GetSkills() {
        return _skillsGraph;
    }

    public void EarnPoint() {
        _points++;
        OnSkillPointsChanged?.Invoke(_points);
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