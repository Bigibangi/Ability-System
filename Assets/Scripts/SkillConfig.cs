using UnityEngine;

[CreateAssetMenu]
public class SkillConfig : ScriptableObject {

    [SerializeField]
    private string _name;

    [SerializeField]
    private string _description;

    [SerializeField]
    private string _category;

    [SerializeField]
    private int _pointsCost;

    [SerializeField]
    private Sprite _icon;

    public Sprite Icon { get { return _icon; } }
    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int PointCost { get { return _pointsCost; } }
}