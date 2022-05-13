using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AgentGenerator))]
public class AgentGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AgentGenerator agentGenerator = (AgentGenerator)target;
        if (GUILayout.Button("GenerateAndShow"))
        {
            agentGenerator.ShowRandomBodyMap();
        }
        //if (GUILayout.Button("DestroyGrids")) {
        //    agentGenerator.DestroyGrids();
        //}
        if (GUILayout.Button("DestroyAgent"))
        {
            agentGenerator.DestroyAgentInEditor();
        }
    }
}
