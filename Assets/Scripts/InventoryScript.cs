using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryScript : MonoBehaviour
{

    public Item item;
    [Header("UI")]
    public Image image;

    private void Start()
    {
        InitialiseItem(item);
    }

    public void InitialiseItem(Item newItem)
    {
        image.sprite = newItem.image;
    }


}
