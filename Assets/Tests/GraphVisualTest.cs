using System.Collections;
using NUnit.Framework;
using UnityEditor.SceneTemplate;
using UnityEngine;
using FluentAssertions;
using NSubstitute;
using UnityEngine.TestTools;

public class GraphVisualTest {

    // A Test behaves as an ordinary method
    [Test]
    public void GraphVisualTestSimplePasses() {
        var graphDisplay = new GameObject().AddComponent<GraphDisplay>();
        Assert.IsNotNull(graphDisplay);
    }

    [Test]
    public void WhenSkillWithEmptyIcon_AndVisualizing_ThenIconAreTheSame() {
        // Arrange. Act.

        // Assert.
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use `yield return
    // null;` to skip a frame.
    [UnityTest]
    public IEnumerator GraphVisualTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions. Use yield to skip a frame.
        yield return null;
    }
}