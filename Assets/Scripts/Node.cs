using System.Collections.Generic;

public class Node<DataType> {
    public readonly DataType obj;
    public readonly List<Node<DataType>> incidentNodes;

    public Node(
        DataType obj,
        List<Node<DataType>> incidentNodes = null) {
        this.obj = obj;
        this.incidentNodes = incidentNodes;
    }
}