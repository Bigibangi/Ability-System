using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour {
    public const string LEARN = "Изучить";

    [SerializeField]
    private Button _learnSkillButton,
                   _forgetSkillButton,
                   _forgetAllSkillButton,
                   _earnPointButton;

    [SerializeField]
    private TextMeshProUGUI _skillPointsCount;

    [SerializeField]
    private SkillStorage _skillStorage;

    [SerializeField]
    private GraphDisplay _skillsGraphDisplay;

    private void Awake() {
        _skillStorage.OnSkillPointsChanged += ShowEarnedPoints;
        _learnSkillButton.onClick.RemoveAllListeners();
        _forgetSkillButton.onClick.RemoveAllListeners();
        _learnSkillButton.gameObject.SetActive(false);
        _forgetSkillButton.gameObject.SetActive(false);
    }

    private void OnEnable() {
        SkillNode.OnSelectedSkill += HandleSelectedObject;
    }

    private void OnDisable() {
        SkillNode.OnSelectedSkill -= HandleSelectedObject;
        _learnSkillButton.onClick.RemoveAllListeners();
        _forgetAllSkillButton.onClick.RemoveAllListeners();
    }

    private void ShowEarnedPoints(int points) {
        _skillPointsCount.text = points.ToString();
    }

    private void HandleSelectedObject(BaseEventData eventData) {
        var current = eventData.selectedObject;
        Debug.Log("in menu " + current.name);
        var skillStatus = current.gameObject.GetComponent<SkillNode>().Skill.Status;
        if (skillStatus == SkillLearnStatus.Undiscovered) {
            _learnSkillButton.gameObject.SetActive(true);
            _learnSkillButton.onClick.AddListener(current.GetComponentInChildren<SkillController>().LearnSkill);
        }
    }
}