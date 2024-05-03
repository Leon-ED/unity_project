using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;
using TMPro;

public class PlanePilot : MonoBehaviour
{
    public float rotationValue;
    public float speed;
    public float accéleration;
    public float decélerationpower;
    public float camBias = 0.96f;
    private RaycastHit hitF;
    public float maxDistanceF = 300f;
    public Camera cam;
    private Vector3 target;
    public RectTransform Crosshair;
    public RectTransform targetCanvas;
    public GameObject Cursor, pivot;
    public CinemachineRecomposer rc3P, rc1P;
    private Transform ennemieTransform;
    private GameObject targetedennemie;
    public GameObject homingMissile;
    public Transform missilePoint1, missilePoint2;
    private Animator _CMVCamStateDrivenCamera;
    public bool switchCMVc;
    public GameObject boom;
    public int score = 0;
    public int kills = 0;
    public TextMeshProUGUI cameraText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI KillsText;
    public TextMeshProUGUI MainText;
    public AudioSource explosionSource;
    public AudioClip explosionSound;


    // Start is called before the first frame update
    void Start()
    {
        GameObject stateCamObject = GameObject.FindGameObjectWithTag("StateCam");
        if (stateCamObject != null)
        {
            _CMVCamStateDrivenCamera = stateCamObject.GetComponent<Animator>();
            if (_CMVCamStateDrivenCamera == null)
            {
                Debug.LogError("Animator component not found on object with tag 'StateCam'");
            }
        }
        else
        {
            Debug.LogError("Object with tag 'StateCam' not found in the scene.");
        }
    }
    private void FixedUpdate()
    {
        ScoreText.text = "Score : " + score.ToString();
        KillsText.text = "Kills : " + kills.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (kills == 2)
        {
            MainText.text = "Vous avez Gagné";
            MainText.color = Color.green;
            Destroy(Cursor);
            return;
        }

        Rotation();
        Movement();
        //CamMovement();
        GroundCollisionCheck();
        Acceleration();
        RepositionnateCrossair();
        OnDrawGizmo();
        EnnemiDetection();
        FireMissile();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("A_Button"))
        {
            if (switchCMVc)
            {
                SwitchCam("CMVcam1");
                cameraText.text = "Caméra : 3 ème Personne";
                switchCMVc = false;
            }
            else
            {
                switchCMVc = true;
                cameraText.text = "Caméra : Cockpit";
                SwitchCam("CMVcam2");
            }
        }

    }
    private void Rotation()
    {

        // transform.Rotate(Input.GetAxis("Vertical")/2, 0.0f, -Input.GetAxis("Horizontal")/2);
        transform.Rotate(-Input.GetAxis("Vertical") / 1.5f, rotationValue, -Input.GetAxis("Horizontal") / 1.3f);
        rc3P.m_Dutch = transform.localEulerAngles.z;
        //rc1P.m_Dutch = transform.localEulerAngles.z;

    }
    private void Movement()
    {
        transform.position += transform.forward * Time.deltaTime * (speed + accéleration);
        speed -= transform.forward.y * Time.deltaTime * decélerationpower;
        if (speed <= 35)
        {
            speed = 35;
        }
        if (Input.GetButton("RB"))
        {
            rotationValue = 0.2f;
        }
        else if (Input.GetButton("LB"))
        {
            rotationValue = -0.2f;
        }
        else
            rotationValue = 0;

    }
    private void CamMovement()
    {
        Vector3 moveCamTo = transform.position - transform.forward * 50f + Vector3.up * 35f;
        Camera.main.transform.position = Camera.main.transform.position * camBias + moveCamTo * (1.0f - camBias); ;

        Camera.main.transform.LookAt(transform.position + transform.forward * 30f);
        Camera.main.transform.Rotate(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, transform.rotation.z);
    }
    private void GroundCollisionCheck()
    {
        RaycastHit hit;
        float raycastDistance = 5f; // Ajustez la distance du raycast selon vos besoins

        // Lance un raycast vers le bas depuis la position de l'avion
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            // Vérifie si le terrain est touché
            if (hit.collider.CompareTag("Terrain"))
            {
                Debug.Log("Boum!"); // Affiche "boum" dans la console
                Instantiate(boom, transform.position, transform.rotation);
                Destroy(gameObject);
                MainText.text = "Vous avez perdu";
                MainText.color = Color.red;
                Destroy(Cursor);
                explosionSource.PlayOneShot(explosionSound);
            }
        }
    }
    private void Acceleration()
    {
        //speed = speed + accéleration;
        float InputValue = Input.GetAxis("Fire1");
        accéleration = Mathf.Lerp(0, InputValue, 0.5f) * 150;


    }

    private void OnDrawGizmo()
    {

        bool isHitF = Physics.BoxCast(transform.position, transform.localScale, direction: transform.forward, out hitF,
        transform.rotation, Mathf.Infinity);

        target = hitF.point;
    }
    public void RepositionnateCrossair()
    {
        Crosshair.gameObject.transform.SetParent(targetCanvas, false);
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(target);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * targetCanvas.sizeDelta.x) - (targetCanvas.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * targetCanvas.sizeDelta.y) - (targetCanvas.sizeDelta.y * 0.5f)));

        Crosshair.anchoredPosition = WorldObject_ScreenPosition;


    }
    public void EnnemiDetection()
    {
        if (hitF.transform.gameObject.GetComponent<Ennemie>() == true)
        {
            ennemieTransform = hitF.transform.gameObject.transform;
        }

    }
    private void FireMissile()
    {
        //Debug.Log("fire");
        if (Input.GetButtonDown("fire1") && ennemieTransform != null)
        {
            Instantiate(homingMissile, missilePoint1.position, missilePoint1.rotation);
            homingMissile.GetComponent<HomingMissile>().RocketTarget = ennemieTransform;

        }
    }


    public void SwitchCam(string cameraToSwitch)
    {
        _CMVCamStateDrivenCamera.Play(cameraToSwitch);
    }
}