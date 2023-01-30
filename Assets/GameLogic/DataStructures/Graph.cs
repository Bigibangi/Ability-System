using System.Collections.Generic;

public class Graph<T> {
    private readonly List<Node<T>> _nodes = new List<Node<T>>();

    #region Properties

    public int Count { get; private set; }

    public bool IsEmpty {
        get {
            return Count == 0;
        }
    }

    public IEnumerable<T> NodesContent {
        get {
            foreach (var node in _nodes) {
                yield return node.content;
            }
        }
    }

    public IEnumerable<Node<T>> Nodes {
        get {
            foreach (var node in _nodes) {
                yield return node;
            }
        }
    }

    #endregion Properties

    public Graph() {
        Count = 0;
    }

    public Graph(List<T> nodes) {
        foreach (var node in nodes) {
            _nodes.Add(new Node<T>(node));
        }
        Count = _nodes.Count;
    }

    public void Add(Node<T> node) {
        if (!_nodes.Contains(node)) {
            _nodes.Add(node);
        }
    }
}