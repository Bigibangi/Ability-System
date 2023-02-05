using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SkillView : MonoBehaviour {

    #region Editor

    [SerializeField]
    private Color _enableColor,
                  _disableColor;

    #endregion Editor

    #region Fields

    private Skill _skill;
    private Image _icon;

    #endregion Fields

    #region Properties

    public Skill Skill { set { _skill = value; } }

    #endregion Properties

    #region Monobehaviour

    public void Awake() {
        _icon = gameObject.GetComponent<Image>();
        StartCoroutine(Visualize());
    }

    #endregion Monobehaviour

    public SkillLearnStatus GetSkillStatus() {
        return _skill.Status;
    }

    private IEnumerator Visualize() {
        yield return new WaitForFixedUpdate();
        if (_skill != null) {
            _icon.sprite = _skill.Config.Sprite;
            if (_skill.Status == SkillLearnStatus.Undiscovered) {
                _icon.color = _disableColor;
            }
            var pointString = gameObject.GetComponentInChildren<Text>();
            pointString.text = _skill.Config.PointCost.ToString();
            pointString.color = Color.green;
            pointString.alignment = TextAnchor.LowerRight;
        }
    }
}