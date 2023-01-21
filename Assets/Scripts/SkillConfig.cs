using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[CreateAssetMenu]
public class SkillConfig : ScriptableObject {

    [SerializeField, XmlAttribute("name")]
    private string _name;

    [SerializeField, XmlAttribute("description")]
    private string _description;

    [SerializeField, XmlAttribute("category")]
    private string _category;

    [SerializeField, XmlAttribute("pointCost")]
    private int _pointsCost;

    [SerializeField, XmlAttribute("icon")]
    private Sprite _icon;

    //for testing the build, serialize/deserialize will rework it
    [SerializeField]
    private List<SkillConfig> _requiredSkill;

    public Sprite Icon { get { return _icon; } }
    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int PointCost { get { return _pointsCost; } }
}