using System.Linq;
using Adamastor.Sphere.Dungeon.Nodes;
using Adamastor.Sphere.Quests;
using Adamastor.Sphere.Rulesets;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace Adamastor.Sphere.Editor
{
    public class CustomNodeGraphEditor : NodeGraphEditor
    {
        private bool _show = true;
        protected RuleSet ruleSet;

        public override void OnGUI()
        {
            _show = GUI.Toggle(new Rect(8, 8, 256, 16), _show, 
                $"Show Rules | Passed {ruleSet.PassedRules} / {ruleSet.rules.Count}");

            if (!_show) return;
        
            GUI.backgroundColor = Color.black;
            var style = new GUIStyle { normal = { background = Texture2D.grayTexture }};
        
            var width = ruleSet.rules.Max(rule => rule.RuleDescription.ToCharArray().Length) * 6.2f;
            var height = ruleSet.rules.Count * 16 + 38;
            GUI.Label(new Rect(8, 32, width, height), "", style);
            
            style = new GUIStyle { normal = { textColor = Color.white }, fontSize = 18 };
            GUI.Label(new Rect(Mathf.Abs(width / 3), 38, 20, 20), "Cultist Dungeon Rules", style);

            var yPosition = 64;
            
            foreach (var rule in ruleSet.rules)
            {
                var valid = rule.Evaluate();
                
                style = new GUIStyle { normal = { textColor = valid ? Color.green : Color.red } };
                GUI.Label(new Rect(32, yPosition, width, 20), rule.RuleDescription, style);

                var guiContent = EditorGUIUtility.IconContent(valid ? "TestPassed" : "TestFailed");
                GUI.Label(new Rect(10, yPosition - 5, 24, 24), guiContent);
                
                yPosition += 16;
            }
        }
    }
}