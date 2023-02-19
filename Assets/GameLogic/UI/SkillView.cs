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

    #region Monobehaviour

    private void Awake() {
        _icon = gameObject.GetComponent<Image>();
        _enableColor = _icon.color;
        StartCoroutine(Visualize());
    }

    private void Update() {
        StartCoroutine(Visualize());
    }

    #endregion Monobehaviour

    public SkillLearnStatus GetSkillStatus() {
        return _skill.Status;
    }

    private IEnumerator Visualize() {
        yield return new WaitForFixedUpdate();
        if ((_skill = gameObject.GetComponentInParent<SkillNode>().Node.content) != null) {
            _icon.sprite = _skill.Config.Sprite;
            if (_skill.Status == SkillLearnStatus.Undiscovered) {
                _icon.color = _disableColor;
            }
            else if (_skill.Status == SkillLearnStatus.Discovered) {
                _icon.color = _enableColor;
            }
            var pointString = gameObject.GetComponentInChildren<Text>();
            pointString.text = _skill.Config.PointCost.ToString();
            pointString.color = Color.green;
            pointString.alignment = TextAnchor.LowerRight;
        }
    }
}