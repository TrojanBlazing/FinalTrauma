using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{ 
  public enum ItemType
    {
        Flashlight,
        Battery,
        Object1,
        Object2
    }

    public ItemType Type;
    public int amount;

    public Sprite GetSprite()
    {
        switch (Type)
        {
            default:
            case ItemType.Flashlight: 
                return ItemAssets.Instance.FlashLight;
            case ItemType.Battery:
                return ItemAssets.Instance.Battery;
            case ItemType.Object1:
                return ItemAssets.Instance.Obj1;
            case ItemType.Object2:
                return ItemAssets.Instance.Obj2;
            


        }
    }
}
