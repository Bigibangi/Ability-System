using System.Collections.Generic;
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

    //for testing the build, serialize/deserialize will rework it
    [SerializeField]
    private List<SkillConfig> _requiredSkill;

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int PointCost { get { return _pointsCost; } }
    public Sprite Icon { get { return _icon; } }
}