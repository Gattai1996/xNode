//////////////////////////////////
// Copyright © Project Sphere by Adamastor Studio
// Created on 20/12/2022
//////////////////////////////////

namespace Adamastor.Sphere.Rulesets
{
    /// <summary>
    /// This class represents a boolean logic rule.
    /// </summary>
    public interface ILogicRule
    {
        public string RuleDescription { get; }
        
        /// <summary>
        /// Evaluates the rule.
        /// </summary>
        /// <returns>A boolean value indicating whether the rule is satisfied.</returns>
        bool Evaluate();
    }
}
