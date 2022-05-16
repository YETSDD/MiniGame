using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectRange
{
    part = 0,
    global = 1
}
public class BuffBase : MonoBehaviour
{
    public int remainRounds;

    public EffectRange range = EffectRange.part;

    public virtual void OnBuffStart()
    {
    }

    public virtual void OnBuffUpdate()
    {
    }

    public virtual void OnBuffDestroy()
    {
    }

}
