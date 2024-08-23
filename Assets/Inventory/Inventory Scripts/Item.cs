using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tag
{
    Important,
    Material
}

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite icon;
    // public Tag itemTag;
    public string itemName;
    [TextArea]
    public string itemDescription;
    public int itemCount = 1;
}
