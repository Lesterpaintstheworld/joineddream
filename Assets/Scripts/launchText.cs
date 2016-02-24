using UnityEngine;
using System.Collections;

public class launchText : MonoBehaviour {

    public GameObject player;
    public GameObject text;

    private Vector3 offset;
    private bool launched = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        offset = transform.position - player.transform.position;
        float distance = offset.magnitude;

        if (distance < 13)
        {
            if (!launched)
            {
                launched = true;
                text.GetComponent<Fade>().Begin();
            }
        }
    }
}
