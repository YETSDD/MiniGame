using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="module",menuName ="AgentData/Module")]
[System.Serializable]
public class Module : ScriptableObject
{
    public string moduleName;

    public List<BuffBase> buffs = new List<BuffBase>();
}
