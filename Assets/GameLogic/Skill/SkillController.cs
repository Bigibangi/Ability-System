using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillController : MonoBehaviour, IPointerClickHandler {
    private Image _icon;

    private void Awake() {
    }

    private void SetDisable() {
    }

    public void OnPointerClick(PointerEventData eventData) {
        SetDisable();
        Debug.Log(gameObject.name);
    }
}