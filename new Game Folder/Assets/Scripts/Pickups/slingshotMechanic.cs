using UnityEngine;
using System.Collections;

public class slingshotMechanic : MonoBehaviour {

    private float time;
    bool done = false;
    private float oldSpeed;

	// Use this for initialization
	void Start () {
        Debug.Log("SLINGSHOT MECHANIC!");
        time = Time.deltaTime;
        oldSpeed = GameMaster.GetPlayerValues().movementSpeed;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (time < 1f)
        {
            if (GameMaster.GetPlayerValues().movementSpeed > 0)
            {
                PlayerControl.AddMoveSpeedBonus(-1);
            }


            time += Time.deltaTime;
        }
        else if(!done)
        {
            done = true;
            PlayerControl.AddMoveSpeedBonus(50 + oldSpeed);
        }
    }
}
