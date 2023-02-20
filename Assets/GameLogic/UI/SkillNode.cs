using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillNode : Selectable, IPointerClickHandler {
    private SkillController _controller;
    private Node<Skill> _node;

    public static Action<BaseEventData> OnSelectedSkill;

    public Action SkillStatusChanged;

    public Action OnLearnSkill;

    public Node<Skill> Node { get { return _node; } set { _node = value; } }
    public SkillController Controller { get { return _controller; } set { _controller = value; } }

    public void OnPointerClick(PointerEventData eventData) {
        var gameobject = eventData.pointerClick;
        Debug.Log(gameobject.name);
        OnSelectedSkill?.Invoke(eventData);
    }

    public bool TryLearnSkill(ref int pointsToReturn) {
        if (Node.IncidentNodes.Count == 0) {
            pointsToReturn = _controller.LearnSkill(pointsToReturn);
            return true;
        }
        foreach (var node in Node.IncidentNodes) {
            if (node.content.Status == SkillLearnStatus.Discovered) {
                pointsToReturn = _controller.LearnSkill(pointsToReturn);
                return true;
            }
        }
        return false;
    }

    public bool TryForgetSkill(out int pointsToReturn) {
        if (Node.IncidentNodes.Count == 0) {
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