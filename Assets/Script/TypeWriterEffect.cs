using TMPro;
using UnityEngine;
using System.Collections;

public class TypeWriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // R�f�rence au texte
    public float typingSpeed = 0.05f; // Vitesse de dactylographie
    public AudioClip typingSound; // Bruit de clavier
    public AudioSource audioSource; // Source audio pour jouer les sons

    private string fullText;

    private void Start()
    {
        fullText = textMeshPro.text;
        textMeshPro.text = ""; // Commence avec un texte vide
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        // Jouer un son si d�fini
        if (audioSource != null && typingSound != null)
        {
            audioSource.PlayOneShot(typingSound);
        }
        foreach (char letter in fullText.ToCharArray())
        {
            textMeshPro.text += letter;

            

            yield return new WaitForSeconds(typingSpeed);
        }
        audioSource.Stop();
    }
}
