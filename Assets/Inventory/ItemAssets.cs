using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
   public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite FlashLight;
    public Sprite Battery;
    public Sprite Obj1;
    public Sprite Obj2;
}
