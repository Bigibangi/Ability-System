using System.Xml.Serialization;
using UnityEngine;

[XmlRoot(ElementName = "skill")]
public class Skill : IActiveAbility {
    private SkillConfig _config;

    private Skill[] _requiredSkills;
    private SkillLearnStatus _status = SkillLearnStatus.Undiscovered;

    public SkillLearnStatus Status {
        get { return _status; }
        set { _status = value; }
    }

    public SkillConfig Config => _config;

    public Skill(SkillConfig skillConfig) {
        _config = skillConfig;
    }

    public virtual void Activate() {
        Debug.Log(_config.Description);
    }
}