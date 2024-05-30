
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.UI;
public class UiInventory : MonoBehaviour
{
    Inventory inventory;
   [SerializeField] Transform itemContainer, slotTemplate;
  
    [SerializeField] WorldItemSpawnner spawnner;
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChange += Inventory_OnItemListChange;
        RefreshInventory();
    }

    private void Inventory_OnItemListChange(object sender, System.EventArgs e)
    {   
        RefreshInventory();
    }

    public void RefreshInventory()
    {

        foreach (Transform child in itemContainer) 
        {
            if(child == slotTemplate)
            {
                continue;
            }
            Destroy(child.gameObject);
        }
        int x = 0, y = 0;
        float slotSize = 50f;
        foreach (Item item in inventory.GetItemList())
        {
           
            RectTransform slotRectTransform = Instantiate(slotTemplate, itemContainer).GetComponent<RectTransform>();
            slotRectTransform.gameObject.SetActive(true);
            slotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            {
                //Drop item
                inventory.RemoveItem(item);
                spawnner.DropItem(item);
            };

            slotRectTransform.anchoredPosition = new Vector2(x* slotSize, y*slotSize);
            Image image = slotRectTransform.Find("MainImage").GetComponent<Image>();
             image.sprite = item.GetSprite();
            x++;
            if(x==5)
            {
                return;
            }
        }
    }
}
