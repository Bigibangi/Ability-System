using System.Collections;
using NUnit.Framework;
using UnityEngine;
using FluentAssertions;
using NSubstitute;
using UnityEngine.TestTools;
using System.Collections.Generic;
using System;

public class GraphTest {
    private Graph<int> graph;
    private List<int> intNodes;

    [SetUp]
    public void Init() {
        graph = new Graph<int>(new List<int>());
        intNodes = new List<int>() { 1, 2, 3 };
    }

    [Test]
    public void WhenGraphIsEmpty_ThenIsEmptyShouldBeTrue() {
        // Arrange. Act. Assert.
        graph.IsEmpty.Should().BeTrue();
    }

    [Test]
    public void WhenGraphInstatiated_ThenCountMustBeEqualNumbersOfListCount() {
        // Arrange.
        var intList = new List<int>{ 1, 2, 3 };
        graph = new Graph<int>(intList);
        // Act. Assert.
        graph.Count.Should().Be(intList.Count);
    }

    [Test]
    public void WhenGraphInstatiated_AndLazyReturnsAllnodes_ThenAllNodesMustBeReturns() {
        // Arrange.
        var lazyIntNodes = new List<int>();
        // Act.
        lazyIntNodes.Add((int) (object) graph.NodesContent);
        // Assert.
        lazyIntNodes.Should().BeEquivalentTo(graph.NodesContent);
    }
}