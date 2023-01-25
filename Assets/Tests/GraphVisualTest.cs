using System.Collections;
using NUnit.Framework;
using UnityEngine;
using FluentAssertions;
using NSubstitute;
using UnityEngine.TestTools;

public class GraphVisualTest {

    // A Test behaves as an ordinary method
    [Test]
    public void GraphVisualTestSimplePasses() {
        //Arrange
        var graphDisplay = new GameObject().AddComponent<GraphDisplay>();
        //Act
        //Assert
        Assert.IsNotNull(graphDisplay);
    }

    [Test]
    public void WhenSkillWithEmptyIcon_AndVisualizing_ThenIconMustBeDefault() {
        // Arrange.
        var skillConfig = ScriptableObject.CreateInstance<SkillConfig>();
        var skill = new Skill(skillConfig);
        var graphDisplay = new GameObject().AddComponent<GraphDisplay>();
        // Act.
        graphDisplay.VisualizeSkill(skill);
        // Assert.
        skill.Config.Icon.Should().Be(graphDisplay.DefaultIcon);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use `yield return
    // null;` to skip a frame.
    [UnityTest]
    public IEnumerator GraphVisualTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions. Use yield to skip a frame.
        yield return null;
    }
}