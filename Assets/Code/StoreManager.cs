using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [Tooltip("The array of world locations where each merchandise item will spawn.")]
    public Transform[] MerchLocations;
    [Tooltip("The prefabs of each kind of item that this store could sell.")]
    public GameObject[] MerchPrefabs;

    // Worklist of indices in random order representing each merch prefab not yet spawned and put on display
    private List<int> merchNotOfferedYet;
    // Array of merch items currently on display. Shares indices with MerchLocations, meaning
    // the item stored at index i is stored at the location at index i.
    private GameObject[] merchOnDisplay;
    
    void Start()
    {
        // Populate and shuffle the worklist of indices representing merchandise to put on display
        CreateMerchList();

        // Initialize the dictionary with merch locations
        merchOnDisplay = new GameObject[MerchLocations.Length];

        // Spawn a random item at each specified merchandise location
        InitializeStore();
    }

    // Replace empty spots in the store with a random item
    void InitializeStore()
    {
        for (int i = 0; i < MerchLocations.Length; i++)
        {
            PutItemOnDisplay(i);
        }
    }

    void ReplacePurchasedItem(GameObject itemBeingPurchased)
    {
        // Find the purchased item in the array
        for (int i = 0; i < merchOnDisplay.Length; i++)
        {
            if (merchOnDisplay[i].Equals(itemBeingPurchased))
            {
                PutItemOnDisplay(i);
            }
        }
    }

    void PutItemOnDisplay(int i)
    {
        // Instantiate the item at the current location
        merchOnDisplay[i] = Instantiate(NextMerchItemPrefab(), MerchLocations[i].position, Quaternion.identity, this.transform); ;

        // Set it up so that when this item is bought, the item will be replaced
        merchOnDisplay[i].GetComponent<InteractablePickup>().OnPurchase += ReplacePurchasedItem;
    }

    void CreateMerchList()
    {
        // Populate list with indices
        merchNotOfferedYet = new List<int>();
        for (int i = 0; i < MerchPrefabs.Length; i++)
        {
            merchNotOfferedYet.Add(i);
        }

        // Now shuffle the list
        int n = merchNotOfferedYet.Count;
        while (n > 1)
        {
            n--;
            int swapIndex = (int) Random.Range(0, n);
            int temp = merchNotOfferedYet[swapIndex];
            merchNotOfferedYet[swapIndex] = merchNotOfferedYet[n];
            merchNotOfferedYet[n] = temp;
        }
    }

    // Grabs the prefab for the next merch item from the randomly ordered list of 
    // not-yet-offered items
    GameObject NextMerchItemPrefab()
    {
        // Grab the next merch item from the list
        GameObject nextItemPrefab = MerchPrefabs[merchNotOfferedYet[0]];
        merchNotOfferedYet.RemoveAt(0);

        // If the list of merch not-offered-yet is now empty, repopulate it
        if (merchNotOfferedYet.Count == 0)
        {
            CreateMerchList();
        }

        return nextItemPrefab;
    }
}
