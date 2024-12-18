using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_later : MonoBehaviour
{

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.time = 18;

        //Play the audio
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
