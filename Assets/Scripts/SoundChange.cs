using UnityEngine;
using System.Collections;

public class SoundChange : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object
    public float mainVolume = 1;


    private AudioSource audioSource;
    private Vector3 offset;         //Private variable to store the offset distance between the player and object

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void Update()
    {
        offset = transform.position - player.transform.position;
        float distance = offset.magnitude;

        if (distance < 13)
        {
            audioSource.enabled = true;

            audioSource.volume = (float)(System.Math.Atan(-System.Math.Pow((offset.magnitude - 5) / 3, 2)) + 1.5) * mainVolume;
        } else if (distance >= 13 && distance <= 14)
        {
            audioSource.enabled = true;
            audioSource.volume = 0F;
        }
        else if (distance > 15 && distance <= 30)
        {
            audioSource.volume = 0F;
        }
        else if (distance > 30)
        {
            audioSource.enabled = false;
        }
    }
}
