using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XMLSkillLoader {
    public string XML_SKILL_PATH = $"{Application.dataPath}/SkillAssets/XMLSkillConfigs";

    public IEnumerable<SkillConfig> SkillConfigLoad() {
        var skillFiles = Directory.GetFiles(XML_SKILL_PATH);
        var skillConfig = new SkillConfig();
        foreach (var XMLfile in skillFiles) {
            skillConfig = XMLOperation.Deserialize<SkillConfig>(XML_SKILL_PATH + "/" + XMLfile);
            yield return skillConfig;
        }
    }
}