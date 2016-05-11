//Programmer: Steven Burgess
//Project: Project: STEAM
using UnityEngine;
using System.Collections;

public abstract class GeneralMovement : MonoBehaviour {

	abstract public void Start ();

	abstract public void Update ();

	abstract public void BeginMoving ();

	abstract public void OnTriggerEnter (Collider c);

	abstract public void CheckForBonus ();

}