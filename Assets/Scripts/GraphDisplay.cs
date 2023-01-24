using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphDisplay : MonoBehaviour {

    [SerializeField]
    private Player _player;

    [SerializeField]
    private GameObject _skillIconPrefab;

    private List<Skill> _skills;

    private void Awake() {
        _skills = new List<Skill>();
        foreach (var skill in _player.GetSkills()) {
            _skills.Add(skill);
        }
    }

    private void OnEnable() {
    }

    private void OnDisable() {
    }

    public void VisualizeSkill(Skill skill) {
        var skillDisplay = Instantiate(_skillIconPrefab);
        skillDisplay.transform.SetParent(transform, false);
        skillDisplay.GetComponent<Image>().sprite = skill.Config.Icon;
    }
}