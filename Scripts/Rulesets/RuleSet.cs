//////////////////////////////////
// Copyright © Project Sphere by Adamastor Studio
// Created on 20/12/2022
//////////////////////////////////

using System.Collections.Generic;
using System.Linq;

namespace Adamastor.Sphere.Rulesets
{
    /// <summary>
    /// Represents a set of logic rules. It can be used to add, remove, and evaluate logic rules.
    /// </summary>
    public class RuleSet
    {
        /// <summary>
        /// A read-only list of ILogicRule objects that represents the logic rules in the rule set.
        /// </summary>
        public readonly List<ILogicRule> rules;

        public int PassedRules => rules.Count(rule => rule.Evaluate());

        /// <summary>
        /// It initializes the rules list.
        /// </summary>
        public RuleSet()
        {
            rules = new List<ILogicRule>();
        }

        /// <summary>
        /// This method takes an ILogicRule object as an input and adds it to the rules list.
        /// If the rule is already in the list, it will not add the rule again.
        /// </summary>
        /// <param name="rule">The rule to be added to the rules list.</param>
        public virtual void AddRule(ILogicRule rule)
        {
            if (rules.Contains(rule)) return;
            rules.Add(rule);
        }

        /// <summary>
        /// This method takes an ILogicRule object as an input and removes it from the rules list.
        /// If the rule is not in the list, it will not remove any rule.
        /// </summary>
        /// <param name="rule">The rule to be removed from the rules list.</param>
        public virtual void RemoveRule(ILogicRule rule)
        {
            if (!rules.Contains(rule)) return;
            rules.Remove(rule);
        }

        /// <summary>
        /// This method evaluates whether all rules in the rules list are true.
        /// </summary>
        /// <returns>A boolean indicating whether all rules are true.</returns>
        public virtual bool EvaluateAllRules() => rules.All(rule => rule.Evaluate());
    }
}
