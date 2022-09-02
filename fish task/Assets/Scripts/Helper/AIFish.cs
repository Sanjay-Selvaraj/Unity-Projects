using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AIFish : MonoBehaviour {

    public UnityEvent OnArrivedAtDestination;

    [SerializeField] private float _fireRange = 10;
    [SerializeField] private float _cooldown = 0.75f;
    [SerializeField] private Projectile _projectilePrefab;

    public float Cooldown => _cooldown;
    public Target CurrentTarget;

    private Animator _animator;
    private NavMeshAgent _navAgent;

    private Vector3 CurrentDestination => _navAgent.destination;
    private bool _arrivedAtDestination = true;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && TargetManager.Instance.HasTargets) {
            _animator.SetBool("IsAttackModeOn", !_animator.GetBool("IsAttackModeOn"));
        }

        float dist = Vector3.Distance(transform.position, CurrentDestination);

        if (dist < 1 && !_arrivedAtDestination) {
            OnArrivedAtDestination.Invoke();               
        }

        if (CurrentTarget == null || (CurrentTarget != null && CurrentTarget.Equals(null))) {
            CurrentTarget = null;
            _animator.SetBool("HasFood", false);
        }
        else {
            _animator.SetBool("HasFood", true);
        }


        _animator.SetBool("IsFoodinRange", (dist < _fireRange) && (CurrentTarget != null));
    }

    public void MoveTo(Vector3 position) {
        _navAgent.destination = position;
        _navAgent.isStopped = false;
        _arrivedAtDestination = false;
    }

    public void StopMove() {
        _navAgent.isStopped = true;
        _arrivedAtDestination = true;
    }

    public void TurnOffAttackMode() {
        _animator.SetBool("IsAttackModeOn", false);
    }

    public void FireProjectile() {
        Projectile newProjectile = Instantiate(_projectilePrefab);

        newProjectile.Initialize(transform.position + Vector3.forward * 1.15f, transform.rotation);
    }
}