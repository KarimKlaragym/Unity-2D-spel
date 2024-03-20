using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image icon;
    

    int myIndex;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Sedt(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite =slot.item.icon;

        if (slot.item.stackable == true)
        {
           
        } else 
        {
         
        }
    }

    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);

       
    }

    internal void Set(ItemSlot itemSlot)
    {
        throw new NotImplementedException();
    }
}
