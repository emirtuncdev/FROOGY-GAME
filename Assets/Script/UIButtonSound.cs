using UnityEngine;
using UnityEngine.UIElements;

public class UIButtonSound : MonoBehaviour
{
    public AudioClip croakSound;
    public float soundCooldown = 1f; // saniye
    private float lastSoundTime = -999f;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        var uiDoc = GetComponent<UIDocument>();
        if (uiDoc == null) return;

        var root = uiDoc.rootVisualElement;
        var buttons = root.Query<Button>().ToList();

        foreach (var button in buttons)
        {
            button.RegisterCallback<PointerEnterEvent>(evt => PlayCroakSound());
        }
    }

    private void PlayCroakSound()
    {
        if (Time.time - lastSoundTime < soundCooldown) return;

        if (croakSound != null && source != null)
        {
            source.PlayOneShot(croakSound);
            lastSoundTime = Time.time;
        }
    }
}
