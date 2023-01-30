using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SkillPointsCount : MonoBehaviour {

    [SerializeField]
    private SkillContainer _skillContainer;

    private int _points = 0;
    private TextMeshProUGUI _pointPanel;

    public Action<int> OnPointsChanged;

    private void Awake() {
        _pointPanel = GetComponent<TextMeshProUGUI>();
        OnPointsChanged += _skillContainer.EarnPoint;
    }

    public void EarnPoint() {
        _points++;
        _pointPanel.SetText(_points.ToString());
        OnPointsChanged?.Invoke(_points);
    }
}