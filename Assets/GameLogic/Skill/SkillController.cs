using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillController : MonoBehaviour {
    private Skill _skill;

    private void Awake() {
    }

    private void Start() {
        _skill = GetComponentInParent<SkillNode>().Skill;
    }

    public void LearnSkill() {
        Debug.Log("Skill Learned");
        _skill.Status = SkillLearnStatus.Discovered;
    }

    private void ForgetSkill() {
    }
}