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
    [Header("存放的物品")]
    public List<Item> allItems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyboardInput))
        {
            if (backpackPanel.activeSelf)
            {
                backpackPanel.SetActive(false);
            } else
            {
                backpackPanel.SetActive(true);
            }
        }
    }

    public void AddToBackpack(Item item)
    {
        if (allItems.Contains(item))
        {
            item.itemCount += 1;
        } else
        {
            allItems.Add(item);
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
        for (int i = 0; i < allItems.Count; i++)
        {
            slotBtns[i].GetComponentsInChildren<Image>()[1].sprite = allItems[i].icon;
        }
    }

    public void ShowDetail(int index)
    {
        if (allItems.Count > index)
        {
            detailImage.sprite = allItems[index].icon;
            detailText.text = allItems[index].itemDescription;
        }
    }
}
