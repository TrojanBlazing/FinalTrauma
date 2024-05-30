using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItemSpawnner : MonoBehaviour
{
    [SerializeField]Interaction interaction;
    [SerializeField] GameObject[] collectiables;
    public void DropItem(Item item)
    {
        foreach (GameObject obj in collectiables ) 
        {
          if(obj.GetComponent<WorldItem>().worldItem == item.Type)
            {
               
                GameObject spawnObj = Instantiate(obj , interaction.transform.position + Vector3.forward *2f , Quaternion.identity);
                spawnObj.GetComponent<Rigidbody>().AddForce(transform.forward * 1f, ForceMode.Impulse);

            }
        }
    }
}
