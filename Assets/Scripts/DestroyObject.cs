using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    
	
	// Update is called once per frame
	void Update () {
        
        if(this.gameObject != null)
        {
            if (this.gameObject.transform.position.y <= -7)
            {
                Destroy(this.gameObject);
            }
        }
	    
	}
}
