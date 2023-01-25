using System.Collections.Generic;

public class Graph<T> {
    private readonly Node<T>[] _nodes;

    #region Properties

    public int Count { get; private set; }

    public bool IsEmpty {
        get {
            return Count == 0;
        }
    }

    public IEnumerable<T> Nodes {
        get {
            foreach (var node in _nodes) {
                yield return node.obj;
            }
        }
    }

    #endregion Properties

    public Graph(List<T> nodes) {
        _nodes = new Node<T>[nodes.Count];
        for (int i = 0; i < _nodes.Length; i++) {
            _nodes[i] = new Node<T>(nodes[i]);
        }
        Count = _nodes.Length;
    }
}