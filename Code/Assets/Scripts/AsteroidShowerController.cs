using UnityEngine;
using System.Collections;

public class AsteroidShowerController : GameController
{
	void Start ()
	{
		this.ResetGameVariables ();
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		this.UpdateCheckKeyPress ();
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (this.GetGameOver ())
			{
				this.SetExitText ("Press 'Esc' to return to main menu");
				this.SetRestartText ("Press 'R' for Restart");
				this.SetRestart (true);
				break;
			}
		}
	}
}
