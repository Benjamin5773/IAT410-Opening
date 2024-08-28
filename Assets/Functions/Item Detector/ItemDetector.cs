using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    [Header("交互按钮")]
    public KeyCode interactKey;
    [Header("交互UI指示器")]
    public GameObject interactLabel;

    private List<GameObject> items = new List<GameObject>();        // Store items in range

    // Start is called before the first frame update
    void Start()
    {
        interactLabel.GetComponentInChildren<TextMeshProUGUI>().text = interactKey.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (items.Count > 0)
        {
            interactLabel.SetActive(true);
            InteractWithItem();
        } else
        {
            interactLabel.SetActive(false);
        }
    }

    // Main Logic to interact
    void InteractWithItem()
    {
        if (Input.GetKeyDown(interactKey))
        {
            GameObject targetItem = GetClosestItem();
            FindObjectOfType<Backpack>().AddToBackpack(targetItem.GetComponent<ItemObject>().item);
            targetItem.GetComponent<ItemObject>().AddToItemList();

            items.Remove(targetItem);
            Destroy(targetItem);
        }
    }

    // Get the closest item in range
    GameObject GetClosestItem()
    {
        GameObject closestItem = items[0];
        foreach (var item in items)
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);
            if (distance < Vector3.Distance(transform.position, closestItem.transform.position))
            {
                closestItem = item;
            }
        }
        return closestItem;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            items.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            items.Remove(other.gameObject);
        }
    }
}
