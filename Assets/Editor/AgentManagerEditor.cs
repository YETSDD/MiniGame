using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AgentManager))]
public class AgentManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AgentManager agentManager = (AgentManager)target;

        if (GUILayout.Button("GenerateAndShow"))
        {
            agentManager.playerAgentObject = Utility.RandomGenerator.GenerateRandomAgent(agentManager.agentPrefab, agentManager.transform);
            AgentDisplay playerAgentDisplay = agentManager.playerAgentObject.GetComponent<AgentDisplay>();  
            playerAgentDisplay.InitializeMap(agentManager.playerAgentObject.GetComponent<AgentBase>().agentData, agentManager.playerAgentObject.transform);
            playerAgentDisplay.UpdateMap(agentManager.playerAgentObject.GetComponent<AgentBase>().agentData);
        }

        if (GUILayout.Button("DestroyAgent"))
        {
            if (agentManager.playerAgentObject != null)
            {
                DestroyImmediate(agentManager.playerAgentObject);
            }
        }
    }
}
