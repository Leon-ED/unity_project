using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie : MonoBehaviour
{
    public bool locked;
    public GameObject boom;
    public GameObject spaceShip;
    private PlanePilot pilot;
    public AudioClip explosionSound;
    public AudioClip portalSound;
    // Start is called before the first frame update
    void Start()
    {
        // Accéder au script du vaisseau spatial une fois que l'objet est créé
        pilot = spaceShip.GetComponent<PlanePilot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Missile"))
        {
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
            if (pilot != null)
            {
                pilot.kills += 1; // Par exemple, augmenter le score de 100
                int score = !pilot.switchCMVc ? 100 : 150;
                pilot.score += score;
                pilot.explosionSource.PlayOneShot(explosionSound);

                if (pilot.kills == 2)
                {
                    pilot.explosionSource.PlayOneShot(portalSound);
                }
            }
        }
    }
}
