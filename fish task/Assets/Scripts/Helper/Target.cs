using UnityEngine;

public class Target : MonoBehaviour {

    public int HP = 100;

    public void TakeDamage(int amount) {
        HP -= amount;

        if (HP <= 0) {
            TargetManager.Instance.RemoveTarget(this);
            Destroy(gameObject);
        }
    }
}