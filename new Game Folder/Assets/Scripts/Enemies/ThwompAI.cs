using UnityEngine;
using System.Collections;

public class ThwompAI : MonoBehaviour {

		delegate IEnumerator StateRoutine ();


		StateRoutine currentRoutine;
        GameObject player; 

		IEnumerator Start ()
		{
            player = GameObject.FindWithTag("Player");
			currentRoutine = StartState;

			while (enabled && Application.isPlaying && currentRoutine != null)
			{
				yield return StartCoroutine (currentRoutine ());
			}
		}


		IEnumerator StartState ()
		{
			Debug.Log ("Searching for Enemy");
			yield return new WaitForSeconds(1.0f);

            if((transform.position.z - player.transform.position.z) < 40)
			    currentRoutine = RunningState;

		}


		IEnumerator RunningState ()
		{

            Debug.Log("Player found!");
		transform.LookAt (GameMaster.playerObject.transform.position);
		rigidbody.velocity = GameMaster.playerObject.transform.position - transform.position;

			yield return new WaitForSeconds(1.0f);
			
            currentRoutine = EndState;
		}


		IEnumerator EndState ()
		{
			Debug.Log ("Killed?");
		yield return new WaitForSeconds(1.0f);

			enabled = false;
		}
	
}
