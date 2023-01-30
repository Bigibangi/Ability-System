using System;
using UnityEngine;
using UnityEngine.UI;

public class GraphDisplay : MonoBehaviour {

    #region Editor

    [SerializeField]
    private SkillContainer _skillContainer;

    [SerializeField]
    private GameObject _skillIconPrefab;

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

    private void VisualizeSkillNode(Node<Skill> skillNode) {
        //skillIcon = Instantiate(_skillIconPrefab);
        //skillIcon.transform.SetParent(transform, false);
        //skillIcon.GetComponent<Image>().sprite = skillNode.content.Config.Icon;
        //var pointString = skillIcon.gameObject.GetComponentInChildren<Text>();
        //pointString.text = skillNode.content.Config.PointCost.ToString();
        //pointString.color = Color.green;
        //pointString.alignment = TextAnchor.LowerRight;
    }

    #endregion Visualizing
}