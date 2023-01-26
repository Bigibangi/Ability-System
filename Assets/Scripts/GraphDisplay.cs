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

    private Graph<Skill> _skills;
    private Sprite _defaultIcon;

    #endregion Fields

    #region Properties

    public Sprite DefaultIcon => _defaultIcon;

    #endregion Properties

    #region Monobehaviour

    private void Awake() {
        _skills = _player.GetSkills();
        VisualTreeSkills();
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

    #region Visualizing

    public void VisualTreeSkills() {
        foreach (var skill in _skills.Nodes) {
            VisualizeSkill(skill);
        }
    }

    private void VisualizeSkill(Skill skill) {
        var skillIcon = Instantiate(_skillIconPrefab);
        skillIcon.transform.SetParent(transform, false);
        skillIcon.GetComponent<Image>().sprite =
            skill.Config.Icon == null ? _defaultIcon : skill.Config.Icon;
    }

    #endregion Visualizing
}