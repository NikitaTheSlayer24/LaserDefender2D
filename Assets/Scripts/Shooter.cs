using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserSpeed = 10f;
    [SerializeField] private float laserLifeTime = 5f;
    [SerializeField] private float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] private bool useAI;
    [SerializeField] private float minimumDuration = 0f;
    [SerializeField] private float maximumDuration = 0f;

    private Coroutine _firingCoroutine;
    private AudioPlayer _audioPlayer;
    private GameObject _createdLaser;

    private float _timeToNextLaser;
    private bool _isFiring;

    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
    {
        if (useAI)
        {
            _isFiring = true;
        }
    }

    private void Update()
    {
        Fire();
    }

    public void IsFiring(bool value)
    {
        _isFiring = value;
    }

    private void Fire()
    {
        if (_isFiring && _firingCoroutine == null)
        {
            _firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!_isFiring && _firingCoroutine != null)
        {
            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        }

    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            _createdLaser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = _createdLaser.GetComponent<Rigidbody2D>();

            rb.velocity = transform.up * laserSpeed;

            Destroy(_createdLaser, laserLifeTime);

            _timeToNextLaser = Random.Range(baseFiringRate - minimumDuration, baseFiringRate + maximumDuration);

            _audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(_timeToNextLaser);
        }
    }
}
