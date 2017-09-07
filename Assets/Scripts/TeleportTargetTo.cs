using UnityEngine;
using System.Collections;

public class TeleportTargetTo : MonoBehaviour
{

    [SerializeField]private Transform teleportTo;

    public void OnTriggerEnter(Collider col)
    {
        TeleportTarget(col.gameObject);
    }

    public void OnDrawGizmos()
    {
        if (teleportTo != null)
            Debug.DrawLine(this.transform.position, teleportTo.position, Color.blue);
    }

    private void TeleportTarget(GameObject target)
    {
        if (target != null)
        {
            target.transform.position = teleportTo.position;
            target.transform.rotation = teleportTo.rotation;
            var rb = target.GetComponent<Rigidbody>();
            if (rb != null && !rb.isKinematic)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}