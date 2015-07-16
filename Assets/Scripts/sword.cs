using UnityEngine;
using System.Collections;

public class sword : MonoBehaviour {

	public int dmg;
	public float range;

    private Animation animations;

	// Use this for initialization
	void Start () {
	    animations = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown (0) && !animations.isPlaying) {
            Ray ray = transform.parent.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit) && hit.distance <= range) {
                animations.Play ("Attack");
                hit.transform.gameObject.SendMessage("Hit", dmg);
			}
		}
	}
}
