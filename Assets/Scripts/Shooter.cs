using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserSpeed = 10f;
    [SerializeField] private float laserLifeTime = 5f;
    [SerializeField] private float firingRate = 0.2f;

    private Coroutine _firingCoroutine;
    private GameObject _createdLaser;

    private bool _isFiring;

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
            yield return new WaitForSeconds(firingRate);
        }
    }
}
