using System.Collections.Generic;

public class Node<DataType> {
    public readonly DataType content;
    private List<Node<DataType>> _incidentNodes = new List<Node<DataType>>();
    private Graph<DataType> _graph;

    public List<Node<DataType>> IncidentNodes {
        get { return _incidentNodes; }
    }

    public Graph<DataType> Graph {
        get { return _graph; }
        set { _graph = value; }
    }

    public Node(
        DataType obj,
        Graph<DataType> graph) {
        content = obj;
        _graph = graph;
    }

    public void Connect(Node<DataType> anotherNode) {
        if (anotherNode != null) {
            _incidentNodes.Add(anotherNode);
            anotherNode.IncidentNodes.Add(this);
            Graph.Add(anotherNode);
        }
    }

    public override int GetHashCode() {
        return content.GetHashCode();
    }

    public override bool Equals(object obj) {
        if (obj == null) return false;
        if (!(obj is Node<DataType>))
            return false;
        if (obj.GetHashCode() != GetHashCode()) return false;
        return content.Equals(obj);
    }
}