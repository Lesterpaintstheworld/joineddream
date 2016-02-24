using UnityEngine;
using System.Collections;

public class LineMove : MonoBehaviour {

    public GameObject player;
    public GameObject people;

    private LineRenderer lineRenderer;

    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = player.transform.position - people.transform.position;
        float distance = offset.magnitude;

        if (distance < 3)
        {
            lineRenderer.enabled = false;

        } else if (distance < 13)
        {
            lineRenderer.enabled = true;

            lineRenderer.SetPosition(0, player.transform.position - offset.normalized * 1.5F);
            lineRenderer.SetPosition(1, people.transform.position + offset.normalized * 1.5F);

            lineRenderer.SetWidth(20 / (distance * distance - 1), 20 / (distance * distance - 1));           
        } else
        {
            lineRenderer.enabled = false;
        }
    }
}
