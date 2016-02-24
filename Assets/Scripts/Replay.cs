using UnityEngine;
using System.Collections;

public class Replay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void Click()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
