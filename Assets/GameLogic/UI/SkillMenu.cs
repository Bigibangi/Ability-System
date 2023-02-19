using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour {

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
        _forgetAllSkillButton.onClick.AddListener(ForgetAllSkillButton);
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
        ShowSkillDetails(current);
    }

    private void ShowSkillDetails(GameObject current) {
        SkillNode skillNode;
        if (current.TryGetComponent(out skillNode)) {
            UpdateAllButtons(skillNode);
        }
    }

    private void UpdateAllButtons(SkillNode skillNode) {
        _learnSkillButton.gameObject.SetActive(false);
        _forgetSkillButton.gameObject.SetActive(false);
        var status = skillNode.Node.content.Status;
        var remainedPoints = _skillStorage.Points;
        switch (status) {
            case SkillLearnStatus.Undiscovered:
            _learnSkillButton.onClick.RemoveAllListeners();
            _learnSkillButton.gameObject.SetActive(true);
            _learnSkillButton.onClick.AddListener(() => {
                if (skillNode.TryLearnSkill(ref remainedPoints)) {
                    UpdateAllButtons(skillNode);
                    _skillStorage.Points = remainedPoints;
                }
            });
            break;

            case SkillLearnStatus.Discovered:
            _forgetSkillButton.onClick.RemoveAllListeners();
            _forgetSkillButton.gameObject.SetActive(true);
            _forgetSkillButton.onClick.AddListener(() => {
                if (skillNode.TryForgetSkill(out int pointsToReturn)) {
                    UpdateAllButtons(skillNode);
                    _skillStorage.Points += pointsToReturn;
                }
            });
            break;
        }
    }

    private void ForgetAllSkillButton() {
        int pointsToReturn = 0;
        foreach (var skill in _skillStorage.GetSkills().NodesContent) {
            if (skill.Status == SkillLearnStatus.Discovered) {
                skill.Status = SkillLearnStatus.Undiscovered;
                pointsToReturn += skill.Config.PointCost;
            }
        }
        _skillStorage.Points += pointsToReturn;
    }
}