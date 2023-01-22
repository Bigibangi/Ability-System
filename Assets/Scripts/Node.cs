using System.Collections.Generic;

public class Node<T> {
    public readonly T obj;
    public readonly List<Node<T>> incidentNodes;

    public Node(T obj) {
        this.obj = obj;
    }
}