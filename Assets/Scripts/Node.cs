using System.Collections.Generic;

public class Node<DataType> {
    public readonly DataType obj;
    public readonly List<Node<DataType>> incidentNodes;

    public Node(DataType obj) {
        this.obj = obj;
    }
}