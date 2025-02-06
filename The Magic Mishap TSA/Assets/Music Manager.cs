using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the MusicManager GameObject
        audioSource = GetComponent<AudioSource>();
        
        // Optional: If you want to ensure music continues across scenes, keep the music playing across scene loads
        DontDestroyOnLoad(gameObject); // Keep the music manager when switching scenes
    }

    // This function can be called to stop the music when the scene changes
    public void StopMusic()
    {
        // Stop the music
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
