using TMPro;
using UnityEngine;
using System.Collections;

public class TypeWriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Référence au texte
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
        // Jouer un son si défini
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
