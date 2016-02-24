using UnityEngine;
using System.Collections;

public class ForceToPlayer : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object
    public bool onEvent = true;
    public float intensity = 2F;

    private ConstantForce2D constantForce2D;
    private Vector3 offset;         //Private variable to store the offset distance between the player and object
    private bool started = false;

    // Use this for initialization
    void Start () {
        constantForce2D = GetComponent<ConstantForce2D>();
    }

    public void Begin()
    {
        started = true;
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void Update()
    {
        if (!onEvent || started)
        {
            offset = transform.position - player.transform.position;

            float force = System.Math.Min(1, offset.magnitude - 5);

            constantForce2D.force = -(offset.normalized * force * intensity);
        }
    }
}