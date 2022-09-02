using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] private float _speed = 25.0f;
    [SerializeField] private float _lifetimeInSeconds = 3;
    [SerializeField] private int _damage = 35;

    private bool _isEnabled = false;

    public void Initialize(Vector3 position, Quaternion rotation) {
        Invoke("DestroyThis", _lifetimeInSeconds);
        _isEnabled = true;

        transform.position = position;
        transform.rotation = rotation;
    }

    private void Update() {
        if (_isEnabled == false) { return; }
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void DestroyThis() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        Target target = other.gameObject.GetComponent<Target>();

        if (target != null) {
            target.TakeDamage(_damage);
            DestroyThis();
        }
    }
}