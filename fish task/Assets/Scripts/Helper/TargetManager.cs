using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    public static TargetManager Instance;

    private List<Target> _targetList = new List<Target>();

    public bool HasTargets => _targetList.Count > 0;

    private void Awake() {
        Instance = this;
        _targetList = new List<Target>(GetComponentsInChildren<Target>());
    }

    public Target GetClosestTarget(Vector3 position) {
        Target closestTarget = null;
        float closestDistance = float.MaxValue;

        foreach (Target target in _targetList) {
            float dist = Vector3.Distance(target.transform.position, position);

            if (dist < closestDistance) {
                closestDistance = dist;
                closestTarget = target;
            }
        }

        return closestTarget;
    }

    public void RemoveTarget(Target target) {
        if (_targetList.Contains(target)) {
            _targetList.Remove(target);
        }
    }
}