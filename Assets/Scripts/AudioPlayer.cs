using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)]private float shootingVolume = 1f;
    
    [Header("Damage")]
    [SerializeField] private AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)]private float damageVolume = 1f;

    private static AudioPlayer _instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false); 
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayeClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayeClip(damageClip, damageVolume);
    }

    private void PlayeClip(AudioClip clip, float volume)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
    }
}
