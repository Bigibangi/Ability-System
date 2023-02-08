using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GraphDisplay : MonoBehaviour {

    #region Editor

    [SerializeField]
    private SkillStorage _skillContainer;

    [SerializeField]
    private GameObject _skillIconPrefab;

    [SerializeField]
    private SkillMenu _skillMenu;

    #endregion Editor

    #region Fields

    private Graph<Skill> _skills;
    private GameObject _root;

    #endregion Fields

    #region Monobehaviour

    private void Awake() {
        _root = Instantiate(_skillIconPrefab);
        _root.name = "Base";
        _root.transform.SetParent(transform, false);
        _skills = _skillContainer.GetSkills();
        VisualTreeSkills();
    }

    private void OnValidate() {
    }

    private void OnEnable() {
    }

    private void OnDisable() {
    }

    #endregion Monobehaviour

    #region Visualizing

    public void VisualTreeSkills() {
        foreach (var skillNode in _skills.Nodes) {
            VisualizeSkillNode(skillNode);
            VisualizeConnections();
        }
    }

    private void VisualizeConnections() {
    }

    private void VisualizeSkillNode(Node<Skill> node) {
        var skillIcon = Instantiate(_skillIconPrefab);
        skillIcon.transform.SetParent(transform, false);
        skillIcon.name = node.content.Config.Name;
        var skillNode = skillIcon.gameObject.GetComponentInChildren<SkillNode>();
        skillNode.Skill = node.content;
    }

    #endregion Visualizing
}