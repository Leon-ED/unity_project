using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CinematicController : MonoBehaviour
{
    public TextMeshProUGUI cinematicText; // R�f�rence au texte sur l'�cran
    public string[] texts; // Liste des textes � afficher
    public float typingSpeed = 0.05f; // Vitesse d'�criture
    public float textDisplayDuration = 1f; // Temps d'attente apr�s avoir �crit chaque texte
    public string nextSceneName = "MainScene"; // Nom de la sc�ne principale
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
            // �crire le texte lettre par lettre
            yield return StartCoroutine(TypeText(text));

            // Attendre un peu apr�s avoir affich� le texte complet
            yield return new WaitForSeconds(textDisplayDuration);
        }

        // Charger la sc�ne principale apr�s avoir affich� tous les textes
        SceneManager.LoadScene(nextSceneName);
    }

    private IEnumerator TypeText(string text)
    {
        cinematicText.text = ""; // R�initialiser le texte affich�
        audioSource.PlayOneShot(typingSound);// Jouer le son de clavier

        foreach (char letter in text.ToCharArray())
        {
            cinematicText.text += letter; // Ajouter chaque lettre
            yield return new WaitForSeconds(typingSpeed); // Attendre avant d'ajouter la suivante
        }

        audioSource.Stop(); // Arr�ter le son du clavier

    }
}
