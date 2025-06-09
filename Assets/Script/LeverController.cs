using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverController : MonoBehaviour
{
    public Transform planeTransform;

    private Quaternion leverGrabStartRotation;
    private Quaternion planeStartRotation;
    private XRGrabInteractable grab;

    private float accumulatedPitch = 0f;
    private float accumulatedRoll = 0f;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        grab.selectEntered.AddListener(OnGrabbed);
        grab.selectExited.AddListener(OnReleased);
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        leverGrabStartRotation = transform.localRotation;
        planeStartRotation = planeTransform.localRotation;

        accumulatedPitch = 0f;
        accumulatedRoll = 0f;
    }

    void OnReleased(SelectExitEventArgs args)
    {
        // Optionnel : tu peux reset ou garder la rotation
    }

    void Update()
    {
        if (grab != null && grab.isSelected)
        {
            // Rotation relative du levier par rapport au grab
            Quaternion leverDelta = Quaternion.Inverse(leverGrabStartRotation) * transform.localRotation;

            // Extraire les angles Euler en mode local lever (attention aux angles > 180)
            Vector3 eulerDelta = leverDelta.eulerAngles;
            if (eulerDelta.x > 180) eulerDelta.x -= 360;
            if (eulerDelta.z > 180) eulerDelta.z -= 360;

            // On accumule l’angle de pitch (rotation autour de l’axe X local)
            accumulatedPitch += eulerDelta.x;
            // On accumule l’angle de roll (rotation autour de l’axe Z local)
            accumulatedRoll += eulerDelta.z;

            // Remettre leverGrabStartRotation à la rotation actuelle pour prendre les petits deltas à chaque frame
            leverGrabStartRotation = transform.localRotation;

            // Calculer la rotation cible sur le vaisseau en appliquant ces angles accumulés
            Quaternion pitchRotation = Quaternion.AngleAxis(accumulatedPitch, Vector3.right);
            Quaternion rollRotation = Quaternion.AngleAxis(accumulatedRoll, Vector3.forward);

            Quaternion targetRotation = planeStartRotation * pitchRotation * rollRotation;

            planeTransform.localRotation = Quaternion.Slerp(planeTransform.localRotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}
