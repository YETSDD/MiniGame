using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType
{
    None = 0,
    Air = 1,
    Earth = 2,
    Fire = 3,
    Water = 4
}

[System.Serializable]
public class PixelData
{
    public float currentHealthPoint;

    public ElementType elementType = ElementType.None;

    public ModuleData moduleRef;

    public float damageFactor = 1.0f;

    public PixelData(float healthPoint, ModuleData module = null)
    {
        this.currentHealthPoint = healthPoint;
        this.moduleRef = module;
    }

    public void ChangeHealthPoint(float amount)
    {
        float finalChangeAmount = amount < 0 ? amount * damageFactor : amount;
        currentHealthPoint = currentHealthPoint + finalChangeAmount >= 0 ? currentHealthPoint + finalChangeAmount : 0;
    }
}
