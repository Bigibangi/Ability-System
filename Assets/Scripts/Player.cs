using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private SkillFactory _skillFactory;

    private Graph<Skill> _skillsGraph;

    public int SkillCount {
        get { return _skillsGraph.Count; }
    }

    public IEnumerable<Skill> GetSkills() {
        return _skillsGraph.GetAllNodesContent();
    }

    private void Awake() {
    }
}