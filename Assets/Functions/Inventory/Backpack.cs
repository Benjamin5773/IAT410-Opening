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

    [Header("����������ť")]
    public KeyCode keyboardInput;
    [Header("������Ÿ�")]
    public List<GameObject> slotBtns;
    [Header("��ŵ���Ʒ")]
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
        // ��ձ���ȫ��icon
        foreach (var item in slotBtns)
        {
            item.GetComponentsInChildren<Image>()[1].sprite = null;
        }

        // �ٽ�ȫ����Ʒ��icon�Ž�
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
