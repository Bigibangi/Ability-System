using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillNode : Selectable, IPointerClickHandler {
    private Skill _skill;

    public static Action<BaseEventData> OnSelectedSkill;

    public Skill Skill { get { return _skill; } set { _skill = value; } }

    public override void OnDeselect(BaseEventData eventData) {
        Debug.Log("Deselected");
    }

    public override void OnSelect(BaseEventData eventData) {
        Debug.Log("Selected");
    }

    public void OnPointerClick(PointerEventData eventData) {
        var gameobject = eventData.pointerClick;
        Debug.Log(gameobject.name);
        OnSelectedSkill?.Invoke(eventData);
    }
}