using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Skill))]
public class SkillEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Skill skill = (Skill)target;
        if (GUILayout.Button("Damage"))
        {
            skill.RectDamageToAgent();
        }
    }


}
