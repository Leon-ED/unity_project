using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using UnityEngine.XR.Interaction.Toolkit;

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
    public InputActionProperty rightControllerRotation;
    public Camera camXROrigin;  // Ta caméra dans le XR Origin
    bool isXRRunning = false;
    private Controller controls;
    private bool isGrabbing = false;
    private Quaternion grabStartRotation;
    private Quaternion planeStartRotation;
    private bool wasFiringLastFrame = false;


    // Start is called before the first frame update
    void Start()
    {

        isXRRunning = XRGeneralSettings.Instance.Manager.isInitializationComplete;


        if (isXRRunning)
        {
            print("VR actif");
            // On est en VR : désactive la Cinemachine ou la caméra de suivi
            GameObject.Find("CM StateDrivenCamera1").SetActive(false);

            // Active le XR Rig (si désactivé par défaut)
            GameObject.Find("XR Origin").SetActive(true);

            controls = new Controller();
            controls.Enable();
        }
        else
        {
            print("VR inactif");
            // On n'est pas en VR : désactive le XR Rig
            GameObject.Find("XR Origin").SetActive(false);

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
        CheckFireMissile();

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
        if (isXRRunning)
        {
            var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
            UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

            if (rightHandDevices.Count > 0)
            {
                var device = rightHandDevices[0];

                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool gripPressed))
                {
                    if (gripPressed && !isGrabbing)
                    {
                        // On commence à grab : on enregistre la rotation de la manette et du vaisseau
                        isGrabbing = true;
                        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion currentRot))
                        {
                            grabStartRotation = currentRot;
                            planeStartRotation = transform.rotation;
                        }
                    }
                    else if (!gripPressed && isGrabbing)
                    {
                        // On vient de relâcher
                        isGrabbing = false;
                    }

                    if (isGrabbing)
                    {
                        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion currentRotation))
                        {
                            // Rotation relative entre la rotation actuelle et celle au moment du grab
                            Quaternion delta = Quaternion.Inverse(grabStartRotation) * currentRotation;

                            // Appliquer la rotation relative au vaisseau
                            Quaternion targetRotation = planeStartRotation * delta;

                            // Interpolation fluide
                            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
                        }
                    }
                }
            }
        }
        else
        {
            // Contrôle classique hors VR
            transform.Rotate(-Input.GetAxis("Vertical") / 1.5f, rotationValue, -Input.GetAxis("Horizontal") / 1.3f);
        }
    }





    private void Movement()
    {
        // Avance toujours vers l'avant de l'avion
        transform.position += transform.forward * Time.deltaTime * (speed + accéleration);

        // Ajuste la vitesse en fonction de l'altitude (comme tu le fais déjà)
        speed -= transform.forward.y * Time.deltaTime * decélerationpower;
        if (speed <= 35)
        {
            speed = 35;
        }

        // Rotation manuelle (si pas en VR)
        if (Input.GetButton("RB"))
        {
            rotationValue = 0.2f;
        }
        else if (Input.GetButton("LB"))
        {
            rotationValue = -0.2f;
        }
        else
        {
            rotationValue = 0;
        }
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
    private void CheckFireMissile()
    {
        if (isXRRunning)
        {
            var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
            UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

            if (rightHandDevices.Count > 0)
            {
                var device = rightHandDevices[0];

                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool isFiring))
                {
                    if (isFiring && !wasFiringLastFrame)
                    {
                        // Premier appui détecté
                        FireMissile();
                    }

                    wasFiringLastFrame = isFiring;
                }
            }
        }
        else
        {
            // Mode non-VR : déclenchement standard à la manette
            if (Input.GetButtonDown("fire1"))
            {
                FireMissile();
            }
        }
    }

    private void FireMissile()
    {
        if (ennemieTransform != null)
        {
            GameObject missile = Instantiate(homingMissile, missilePoint1.position, missilePoint1.rotation);
            missile.GetComponent<HomingMissile>().RocketTarget = ennemieTransform;
        }

        if (isXRRunning)
        {
            var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
            UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

            if (rightHandDevices.Count > 0)
            {
                var device = rightHandDevices[0];
                // Intensité de vibration
                device.SendHapticImpulse(0u, 0.5f, 1.0f);
            }
        }
    }




    public void SwitchCam(string cameraToSwitch)
    {
        _CMVCamStateDrivenCamera.Play(cameraToSwitch);
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}