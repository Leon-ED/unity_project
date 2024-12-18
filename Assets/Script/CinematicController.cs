using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CinematicController : MonoBehaviour
{
    public TextMeshProUGUI cinematicText; // Référence au texte sur l'écran
    public string[] texts; // Liste des textes à afficher
    public float typingSpeed = 0.05f; // Vitesse d'écriture
    public float textDisplayDuration = 1f; // Temps d'attente après avoir écrit chaque texte
    public string nextSceneName = "MainScene"; // Nom de la scène principale
    public AudioClip typingSound; // Son du clavier
    public AudioSource audioSource; // Source audio pour jouer le son
    public AudioClip musicSound;
    public AudioSource audioSourceMusic; // Source audio pour jouer la musique

    private void Start()
    {
        if (cinematicText != null)
        {
            StartCoroutine(PlayCinematic());
        }
        else
        {
            Debug.LogError("Cinematic Text is not assigned!");
        }
    }

    private IEnumerator PlayCinematic()
    {
        // Parcourir chaque texte
        foreach (string text in texts)
        {
            // if it's the last text, stop the music
            if (text == texts[texts.Length - 2])
            {
                audioSourceMusic.PlayOneShot(musicSound);
            }
            // Écrire le texte lettre par lettre
            yield return StartCoroutine(TypeText(text));

            // Attendre un peu après avoir affiché le texte complet
            yield return new WaitForSeconds(textDisplayDuration);
        }

        // Charger la scène principale après avoir affiché tous les textes
        SceneManager.LoadScene(nextSceneName);
    }

    private IEnumerator TypeText(string text)
    {
        cinematicText.text = ""; // Réinitialiser le texte affiché
        audioSource.PlayOneShot(typingSound);// Jouer le son de clavier

        foreach (char letter in text.ToCharArray())
        {
            cinematicText.text += letter; // Ajouter chaque lettre
            yield return new WaitForSeconds(typingSpeed); // Attendre avant d'ajouter la suivante
        }

        audioSource.Stop(); // Arrêter le son du clavier

    }
}
