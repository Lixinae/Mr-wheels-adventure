using UnityEngine;
using System.Collections;

public class CheckMeshRenderer : MonoBehaviour {

    [SerializeField]private GameObject target_obj;

    public void OnDrawGizmos()
    {
        if (target_obj != null)
            Debug.DrawLine(this.transform.position, target_obj.transform.position, Color.yellow);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (target_obj != null)
        {
            if (!target_obj.GetComponent<Renderer>().enabled) {
                
                target_obj.GetComponent<Renderer>().enabled = true;
               
            }
            //target_obj.WakeUp();
        }
    }
}
