using UnityEngine;
using System.Collections;

public class ArcadeController : GameController
{
	public GameObject enemy;

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
				if (i % 3 == 0)
				{
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Instantiate (enemy, spawnPosition, enemy.transform.rotation);
				}
				else
				{
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Instantiate (hazard, spawnPosition, Quaternion.identity);
				}
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
