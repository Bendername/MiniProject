using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RedPanda
{

    StateOfPanda pandaState;
    Stack<StateOfPanda> stackOfPandas;

    public RedPanda(float Width)
    {
        pandaState = new StateOfPanda(Matrix4x4.identity, Width);
        stackOfPandas = new Stack<StateOfPanda>();
    }

    //Turn Panda around y-axis
    public void TurnAroundY(float angle)
    {
		pandaState.M = pandaState.M * Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0,angle,0), Vector3.one);
    }

    //Turn Panda around z-axis
    public void TurnAroundZ(float angle)
    {
		pandaState.M = pandaState.M * Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0,0,angle), Vector3.one);
    }

    // Onwards Panda!
    public void Move(float dist)
    {
		pandaState.M = pandaState.M * Matrix4x4.TRS(new Vector3(0,0,dist), Quaternion.identity, Vector3.one);
    }

    // Store the current state of the Panda
    public void PushToStack()
    {
        stackOfPandas.Push(pandaState);
    }

    // Restore to the previous state
    public void PopOfStack()
    {
        if (stackOfPandas.Count == 0)
        {
            Debug.Log("Sorry, there is nothing to pop of the stack - Because it's empty");
        }
        else
        {
            pandaState = stackOfPandas.Pop();
        }
    }

    public StateOfPanda GetState()
    {
        return pandaState;
    }

    public void SetWidth(float width)
    {
        pandaState.width = width;
    }

    public float GetWidth()
    {
        return pandaState.width;
    }

    public Matrix4x4 GetTransform()
    {
        return pandaState.M;
    }

}

public class StateOfPanda
{
    public Matrix4x4 M;
    public float width;

    public StateOfPanda(Matrix4x4 M, float Width)
    {
        this.M = M;
        width = Width;
    }
}