using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SkillNode : Selectable, IPointerClickHandler {
    private SkillController _controller;
    private Node<Skill> _node;

    public static Action<BaseEventData> OnSelectedSkill;

    public Action SkillStatusChanged;

    public Action OnLearnSkill;

    public Node<Skill> Node { get { return _node; } set { _node = value; } }
    public SkillController Controller { get { return _controller; } set { _controller = value; } }

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

    public bool TryLearnSkill(ref int remainedPoints) {
        if (Node.IncidentNodes == null) {
            _controller.LearnSkill(ref remainedPoints);
            return true;
        }
        foreach (var node in Node.IncidentNodes) {
            if (node.content.Status == SkillLearnStatus.Discovered) {
                _controller.LearnSkill(ref remainedPoints);
                return true;
            }
        }
        return false;
    }

    public bool TryForgetSkill(out int pointsToReturn) {
        if (Node.IncidentNodes == null) {
            pointsToReturn = _controller.ForgetSkill();
            return true;
        }
        foreach (var node in Node.IncidentNodes) {
            if (node.content.Status == SkillLearnStatus.Undiscovered) {
                pointsToReturn = _controller.ForgetSkill();
                return true;
            }
        }
        pointsToReturn = 0;
        return false;
    }
}