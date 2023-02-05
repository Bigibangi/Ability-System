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
        _learnSkillButton.onClick.RemoveAllListeners();
        _forgetSkillButton.onClick.RemoveAllListeners();
        _learnSkillButton.gameObject.SetActive(false);
        _forgetSkillButton.gameObject.SetActive(false);
    }

    private void OnEnable() {
        SkillController.OnSelectedSkill += ShowDetailsCurrentSelectedNode;
    }

    private void ShowEarnedPoints(int points) {
        _skillPointsCount.text = points.ToString();
    }

    private void ShowDetailsCurrentSelectedNode(BaseEventData eventData) {
        var currentNode = eventData.selectedObject;
        Debug.Log("in menu " + currentNode.name);
    }
}