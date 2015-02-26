using UnityEngine;
using System.Collections;

/**
 * Exmaple if an animated view of an occupant.
 */ 
public class SimpleOccupantAnimator : MonoBehaviour {
	
	public GameObject walkNorth;
	public GameObject walkSouth;
	public GameObject attackNorth;
	
	/// <summary>
	/// Show sprite and start the animation.
	/// </summary>
	public void Show()
	{
		StartCoroutine("DoAnimation");
	}

	/// <summary>
	/// Stop the animation and hide sprite.
	/// </summary>
	public void Hide()
	{
		StopCoroutine("DoAnimation");
	}

	/// <summary>
	/// Do the animation.
	/// </summary>
	virtual protected IEnumerator DoAnimation()
	{
		// Random delay
		yield return new WaitForSeconds(Random.Range (0.0f, 0.75f));

		while (true)
		{
			// North
			walkNorth.SetActive(true);
			walkSouth.SetActive(false);
			attackNorth.SetActive(false);
			walkNorth.animation.Play();
			yield return true;
			while (walkNorth.animation.isPlaying) yield return true;
			// Attack
			walkNorth.SetActive(false);
			walkSouth.SetActive(false);
			attackNorth.SetActive(true);
			yield return new WaitForSeconds(3.0f);
			// South
			walkNorth.SetActive(false);
			walkSouth.SetActive(true);
			attackNorth.SetActive(false);
			walkSouth.animation.Play();
			yield return true;
			while (walkSouth.animation.isPlaying) yield return true;
		}
	}
}
