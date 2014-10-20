using UnityEngine;
using System.Collections;

public class ThwompAI : MonoBehaviour {

		delegate IEnumerator StateRoutine ();


		StateRoutine currentRoutine;
		WaitForSeconds w = new WaitForSeconds (1.0f);
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
			yield return w;

            if((transform.position.z - player.transform.position.z) < 40)
			    currentRoutine = RunningState;
		}


		IEnumerator RunningState ()
		{

            Debug.Log("Player found!");
            yield return w;

            currentRoutine = EndState;
		}


		IEnumerator EndState ()
		{
			Debug.Log ("Killed?");
			yield return w;

			enabled = false;
		}
	
}
