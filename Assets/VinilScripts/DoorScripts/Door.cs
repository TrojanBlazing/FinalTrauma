

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Door : MonoBehaviour,Iinteractable
{
    public Animator anim;
    private bool open = false;

    public void Interact()
    {
        open = !open;
        anim.SetBool("Open", open);
    }
    

}



