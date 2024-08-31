using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Backpack : MonoBehaviour
{
    public GameObject backpackPanel;
    public Image detailImage;
    public TextMeshProUGUI detailText;

    [Header("背包交互按钮")]
    public KeyCode keyboardInput;
    [Header("背包存放格")]
    public List<GameObject> slotBtns;
    [Header("物品存储处")]
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBackpack();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyboardInput))
        {
            if (backpackPanel.activeSelf)
            {
                backpackPanel.SetActive(false);
                Time.timeScale = 1;
            } else
            {
                backpackPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void AddToBackpack(Item item)
    {
        if (inventory.items.Contains(item))
        {
            item.itemCount += 1;
        } else
        {
            inventory.items.Add(item);
        }
        UpdateBackpack();
    }

    private void UpdateBackpack()
    {
        // 清空背包全部icon
        foreach (var item in slotBtns)
        {
            item.GetComponentsInChildren<Image>()[1].sprite = null;
        }

        // 再将全部物品的icon放进
        for (int i = 0; i < inventory.items.Count; i++)
        {
            slotBtns[i].GetComponentsInChildren<Image>()[1].sprite = inventory.items[i].icon;
        }
    }

    public void ShowDetail(int index)
    {
        if (inventory.items.Count > index)
        {
            detailImage.sprite = inventory.items[index].icon;
            detailText.text = inventory.items[index].itemDescription;
        }
    }
}
