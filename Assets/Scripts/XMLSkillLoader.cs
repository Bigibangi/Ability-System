using UnityEngine;

public class XMLSkillLoader {
    public string XML_SKILL_PATH = $"{Application.dataPath}/SkillAssets/XMLSkillConfigs/SkillsToLoad.xml";

    public SkillConfig SkillConfigLoad() {
        return new SkillConfig();
    }
}