using System.Collections.Generic;

public class SkillGraph<T> : Graph<T>
    where T : Skill {

    public SkillGraph(List<T> nodes) : base(nodes) {
        foreach (var node in _nodes) {
            if (node.content.RequiredSkills != null) {
                foreach (var skill in node.content.RequiredSkills) {
                    for (int i = 0; i < _nodes.Count; i++) {
                        if (_nodes[i].content.Equals(skill)) {
                            node.Connect(_nodes[i]);
                        }
                    }
                }
            }
        }
    }
}