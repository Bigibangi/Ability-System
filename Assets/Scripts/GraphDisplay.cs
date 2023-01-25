using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphDisplay : MonoBehaviour {

    #region Editor

    [SerializeField]
    private Player _player;

    [SerializeField]
    private GameObject _skillIconPrefab;

    #endregion Editor

    #region Fields

    private List<Skill> _skills;
    private Sprite _defaultIcon;

    #endregion Fields

    #region Properties

    public Sprite DefaultIcon => _defaultIcon;

    #endregion Properties

    #region Monobehaviour

    private void Awake() {
        _skills = new List<Skill>();
        foreach (var skill in _player.GetSkills()) {
            _skills.Add(skill);
            VisualizeSkill(skill);
        }
    }

    private void OnValidate() {
        _defaultIcon ??= Sprite.Create(
            Texture2D.blackTexture,
            new Rect(),
            new Vector2(0, 0));
    }

    private void OnEnable() {
    }

    private void OnDisable() {
    }

    #endregion Monobehaviour

    public void VisualizeSkill(Skill skill) {
        var skillDisplay = Instantiate(_skillIconPrefab);
        skillDisplay.transform.SetParent(transform, false);
        skillDisplay.GetComponent<Image>().sprite =
            skill.Config.Icon == null ? _defaultIcon : skill.Config.Icon;
    }
}