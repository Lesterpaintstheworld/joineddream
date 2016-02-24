using UnityEngine;
using System.Collections;

public class EndTextOnKeyPress : MonoBehaviour
{

    public GameObject player;
    public GameObject text;

    private Vector3 offset;
    private bool launched = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0F || moveVertical!= 0F)
        {
            if (!launched)
            {
                launched = true;
                text.GetComponent<Fade>().End();
            }
        }
    }
}