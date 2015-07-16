using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public static Inventory instance;

    public int slots;
    public int rows;
    public float slotPaddingLeft;
    public float slotPaddingTop;
    public float slotSize;

    public GameObject slotPrefab;

    private RectTransform inventoryRect;
    private float inventoryWidth;
    private float inventoryHeight;

    private List<GameObject> slotContent;


	// Use this for initialization
	void Start () {
        instance = this;
        inventoryRect = GetComponent<RectTransform> ();
        slotContent = new List<GameObject>();
	    CreateLayout();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown (KeyCode.I)) {
            GetComponent<Image> ().enabled = !GetComponent<Image> ().enabled;
            foreach (GameObject go in slotContent) {
                go.GetComponent<Image>().enabled = !go.GetComponent<Image>().enabled;
            }
        }
	}

    private void CreateLayout () {
        int columns = slots / rows;

        inventoryWidth = columns * (slotSize + slotPaddingLeft) + slotPaddingLeft;
        inventoryHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;

        //Größe des Rahmens setzten
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);

        //Slots erstellen
        for (int y = 0; y < rows; y++) {
            for(int x = 0; x < columns; x++) {
                GameObject newSlot = (GameObject)Instantiate(slotPrefab);
                newSlot.name = "Slot";
                newSlot.transform.SetParent(this.transform.parent);

                RectTransform slotItemRect = newSlot.GetComponent<RectTransform>();
                RectTransform[] transforms = newSlot.GetComponentsInChildren<RectTransform>();
                RectTransform slotHighlightRect = transforms[transforms.Length-1];
                
                //Slotgröße und -position setzten
                slotItemRect.localPosition = inventoryRect.localPosition + new Vector3 (slotPaddingLeft * (x + 1) + (slotSize * x), -slotPaddingTop * (y + 1) - (slotSize * y));
                slotItemRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotSize);
                slotItemRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotSize);
                slotHighlightRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, slotSize);
                slotHighlightRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, slotSize);
                

                slotContent.Add(newSlot);
             }
        }

    }

    public void AddItem (Item it) {
        foreach(GameObject go in slotContent) {
            Slot s = go.GetComponent<Slot>();
            if (s.AddItem (it)) {
                return;
            }
        }
        Debug.Log("Inventar ist voll");
    }
}
