using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    public Sprite emptySlot;

	private Stack<Item> items;

    public void Start () {
        items = new Stack<Item>();
    }

    private bool CanAdd (Item item) {

        if (items.Count == 0) {
            return true;
        }

        if (items.Peek ().ID == item.ID && item.Stackable && item.MaxStackSize != items.Count) {
            return true;
        }

        return false;
    }

    public bool AddItem (Item item) {
        if (!CanAdd (item)) {
            return false;
        }
        items.Push(item);
        ChangeSprite(item.Icon);
        return true;
    }

    public Item RemoveItem () {
        Item it = items.Pop();
        if (items.Count == 0) {
            ChangeSprite(emptySlot);
        }
        return it;
    }

    public bool IsEmpty {
        get {return items.Count == 0;}
    }

    private void ChangeSprite (Sprite sprite) {
        Image[] imgs = GetComponentsInChildren<Image> ();
        imgs[imgs.Length-1].sprite = sprite;
    }


}
