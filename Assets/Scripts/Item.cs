using UnityEngine;
using System.Collections;

public enum ItemType {MANA, HEALTH};

public class Item : MonoBehaviour {

    public ItemType type;
    public Sprite icon;
    public int id;

    public bool stackable;
    public int maxStackSize;

    public void Use () {
        switch (type) {
            case ItemType.MANA: {
                Debug.Log("Drinking Mana Potion");
                break;
            }
            case ItemType.HEALTH: {
                Debug.Log("Drinking Health Potion");
                break;
            }
        }
    }

    public Sprite Icon {
        get {return icon;}
        set {icon = value;}
    }

    public bool Stackable {
        get{return stackable;}
    }

    public int MaxStackSize {
        get{return maxStackSize;}
    }

    public int ID {
        get{return id;}
    }
}
