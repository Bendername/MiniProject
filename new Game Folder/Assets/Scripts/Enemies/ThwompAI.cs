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

			yield return new WaitForSeconds(1.0f);

            if((transform.position.z - player.transform.position.z) < 80)
			    currentRoutine = RunningState;

		}


		IEnumerator RunningState ()
		{


		    transform.LookAt (GameMaster.playerObject.transform.position);
		    rigidbody.velocity = ((GameMaster.playerObject.transform.position - transform.position) * GameMaster.GetPlayerValues().movementSpeedMultiplier) / 1.5f;
            audio.Play();

			yield return new WaitForSeconds(1.0f);
			
            currentRoutine = EndState;
		}


		IEnumerator EndState ()
		{

		yield return new WaitForSeconds(1.0f);

			enabled = false;
		}
	
}
