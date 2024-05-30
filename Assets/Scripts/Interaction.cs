using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Transform pcamera;
    [SerializeField] private float maxDistance = 6;
    [SerializeField] GameObject text;

     PlayerInputAction playerInputAction;
    GameObject worldObj;
    Item.ItemType worldItemType;

    //Inventory
    Inventory inventory;
    [SerializeField] UiInventory inventoryUi;
    [SerializeField] Breaker breaker;

    bool isCollectiable;
    bool isBreaker;

   
    private void Awake()
    {

        playerInputAction = new PlayerInputAction();
        playerInputAction.PlayerMovement.Enable();
        playerInputAction.PlayerMovement.Interaction.performed += c => ObjectPickUp();
        playerInputAction.PlayerMovement.Interaction.performed += c => InteractWithObject();
        inventory = new Inventory();
    }
    void Start()
    {
        inventoryUi.SetInventory(inventory);
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void OnEnable()
    {
        playerInputAction.Enable();
    }
    private void OnDisable()
    {
        playerInputAction.Disable();    
    }
    private void Update()
    {
        //InteractWithObject();
    }

    void ObjectPickUp()
    {
        if(isCollectiable && inventory.GetItemList().Count<5)
        {
            
            worldItemType = worldObj.GetComponent<WorldItem>().worldItem;
            //Debug.Log(worldItemType);
             inventory.AddItem(new Item { Type = worldItemType, amount = 1 });
          
            Destroy(worldObj);
        }

        if (isBreaker)
        {
            breaker.ToggleLights();
        }

    }
    void InteractWithObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(pcamera.transform.position, pcamera.transform.forward, out hit, maxDistance))
        {
            worldObj = hit.transform.gameObject;

            if (hit.transform.tag == "collectables")
            {
                text.SetActive(true);

                isCollectiable = true;
               
            }
            else
            {
                isCollectiable = false;
            }
            if (hit.transform.tag == "Breaker")
            {
                text.SetActive(true);
                isBreaker = true;
              
            }
            else
            {
                isBreaker = false;
            }
            Iinteractable interactable = hit.collider.GetComponent<Iinteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }

    }
        

    }
    private void UpdateTextVisibility()
    {
        RaycastHit hit;
        if (Physics.Raycast(pcamera.position, pcamera.forward, out hit, maxDistance))
        {
            if (hit.transform.CompareTag("Door"))
            {
                text.SetActive(true);
                return;
            }
        }
        text.SetActive(false);
    }

    private void FixedUpdate()
    {
        UpdateTextVisibility();
    }





}
