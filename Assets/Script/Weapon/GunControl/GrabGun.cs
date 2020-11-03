using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace Assets.Script.Weapon
{
	public class GrabGun : MonoBehaviour
	{
	    // Start is called before the first frame update
	    void Start()
	    {
	        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += Ongrabbed;
	    }
	
	    private void Ongrabbed(object sender, InteractableObjectEventArgs e)
	    {
	        StartCoroutine(SetGunControlState());
	    }
	
	    private IEnumerator SetGunControlState()
	    {
	        yield return null;
	        GetComponent<SingleGunControl>().enabled = true;
	    }
	
	    // Update is called once per frame
	    void Update()
	    {
	        
	    }
	}
}
