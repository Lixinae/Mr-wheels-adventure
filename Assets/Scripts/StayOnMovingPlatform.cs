using UnityEngine;
using System.Collections;

// Permet de faire tenir le joueur à la plateforme en mouvement et le faire bouger avec
public class StayOnMovingPlatform : MonoBehaviour
{

    void OnTriggerEnter(Collider col){
            col.transform.parent = gameObject.transform;
      
    }

    void OnTriggerExit(Collider col){
            col.transform.parent = null;
    }
}
