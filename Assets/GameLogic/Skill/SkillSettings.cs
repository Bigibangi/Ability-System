using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillSettings : ScriptableObject {

    [SerializeField]
    private string _name;

    [SerializeField]
    private string _description;

    [SerializeField]
    private string _category;

    [SerializeField]
    private int _pointsCost;

    [SerializeField]
    private Sprite _sprite;

    //for testing the build, serialize/deserialize will rework it
    [SerializeField]
    private List<SkillSettings> _requiredSkills;

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int PointCost { get { return _pointsCost; } }
    public Sprite Sprite { get { return _sprite; } }
    public List<SkillSettings> RequiredSkills { get { return _requiredSkills; } }
}