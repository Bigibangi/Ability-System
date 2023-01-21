using UnityEngine;

public class Graph : MonoBehaviour {

    [SerializeField]
    private Player _player;

    private Node<Skill>[] _skillsGraph;

    private void Awake() {
        _skillsGraph = new Node<Skill>[_player.SkillCount];
        for (int i = 0; i < _skillsGraph.Length; i++) {
            _skillsGraph[i] = new Node<Skill>();
        }
    }
}