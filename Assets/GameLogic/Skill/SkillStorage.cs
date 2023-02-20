using System;
using System.Collections.Generic;
using System.Linq;
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
        OnSkillPointsEarned += ChangePoints;
        SetUp(_skillsGraph);
    }

    #endregion MonoBehaviour

    public Action<int> OnSkillPointsChanged;
    public Action<int> OnSkillPointsEarned;

    public int Points {
        get { return _points; }
    }

    public Graph<Skill> GetSkills() {
        return _skillsGraph;
    }

    private void EarnPoint() {
        _points++;
        OnSkillPointsChanged?.Invoke(_points);
    }

    private void ChangePoints(int points) {
        _points += points;
        if (_points < 0) {
            _points = 0;
        }
        OnSkillPointsChanged?.Invoke(_points);
    }

    private void SetUp(Graph<Skill> skillsGraph) {
        var skillList = new List<Skill>();
        foreach (var skillConfig in _skillSettings) {
            var skill = _skillFactory.BuildSkill(skillConfig);
            skillList.Add(skill);
        }
        foreach (var skill in skillList) {
            if (skill.Config.RequiredSkills != null) {
                foreach (var skillConfig in skill.Config.RequiredSkills) {
                    for (int i = 0; i < skillList.Count; i++) {
                        if (skillList[i].Config == skillConfig) {
                            skill.AddRequiredSkill(skillList[i]);
                        }
                    }
                }
            }
        }
        _skillsGraph = new SkillGraph<Skill>(skillList);
    }
}