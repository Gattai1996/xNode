//////////////////////////////////
// Copyright © Project Sphere by Adamastor Studio
// Created on 12/01/2023
//////////////////////////////////

using System.Linq;
using Adamastor.Sphere.Dungeon.Nodes;

namespace Adamastor.Sphere.Rulesets
{
    public class NodeGraphInputConnectionRule : ILogicRule
    {
        private readonly DungeonNodeGraph _nodeGraph;

        public string RuleDescription { get; }

        public NodeGraphInputConnectionRule(string ruleDescription, DungeonNodeGraph nodeGraph)
        {
            RuleDescription = ruleDescription;
            _nodeGraph = nodeGraph;
        }

        public bool Evaluate()
        {
            return _nodeGraph.nodes.ConvertAll(node => node as DungeonNode).Count(node => 
                node is not EntranceNode && node.GetInputNode() is not null) == _nodeGraph.nodes.Count - 1;
        }
    }
}