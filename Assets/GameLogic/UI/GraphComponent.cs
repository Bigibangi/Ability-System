using UnityEngine;

public class GraphComponent : MonoBehaviour {

    #region Editor

    [SerializeField]
    private SkillStorage _skillContainer;

    [SerializeField] private Transform _nodesContainer;
    [SerializeField] private Transform _linesContainer;

    [SerializeField]
    private GameObject _skillIconPrefab, _connection;

    [SerializeField]
    private SkillMenu _skillMenu;

    #endregion Editor

    #region Fields

    private Graph<Skill> _skills;
    private GameObject _root;

    #endregion Fields

    #region Monobehaviour

    private void Awake() {
        _root = Instantiate(_skillIconPrefab);
        _root.name = "Base";
        _root.transform.SetParent(_nodesContainer);
        _skills = _skillContainer.GetSkills();
        VisualTreeSkills();
    }

    private void OnValidate() {
    }

    private void OnEnable() {
    }

    private void OnDisable() {
    }

    #endregion Monobehaviour

    #region Visualizing

    public void VisualTreeSkills() {
        foreach (var skillNode in _skills.Nodes) {
            VisualizeSkillNode(skillNode);
            //VisualizeConnections();
        }
    }

    private void VisualizeConnections() {
        var skillNodes = gameObject.GetComponentsInChildren<SkillNode>();
        foreach (var skillNode in skillNodes) {
            var startPosition = skillNode.gameObject.GetComponent<RectTransform>().position;
            var connection = Instantiate(_connection);
            connection.transform.SetParent(transform.parent, false);
            var rectTransform = connection.GetComponent<RectTransform>();
            var endPosition = _root.GetComponent<RectTransform>().position;
            var direction = (endPosition - startPosition).normalized;
            var distance = Vector2.Distance(startPosition, endPosition);
            rectTransform.sizeDelta = new Vector2(distance, 3f);
            rectTransform.anchoredPosition = startPosition + direction * distance * 0.5f;
            rectTransform.localEulerAngles = new Vector3(0, 0, Vector3.Angle(startPosition, endPosition));
        }
    }

    private void VisualizeSkillNode(Node<Skill> node) {
        var skillIcon = Instantiate(_skillIconPrefab);
        skillIcon.transform.SetParent(_nodesContainer);
        skillIcon.name = node.content.Config.Name;
        var skillNode = skillIcon.gameObject.GetComponentInChildren<SkillNode>();
        var rectTransform = skillIcon.GetComponent<RectTransform>();
        skillNode.Controller = new SkillController(node.content);
        skillNode.Node = node;
    }

    #endregion Visualizing
}