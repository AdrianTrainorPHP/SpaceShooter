using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText exitText;
	public GUIText gameOverText;

	protected bool gameOver;
	protected bool restart;
	protected bool exit;
	protected int score;


	void Start ()
	{
		this.gameOver = false;
		this.restart = false;
		this.exit = false;
		this.restartText.text = "";
		this.exitText.text = "";
		this.gameOverText.text = "";
		this.score = 0;
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R))
		{
			Application.LoadLevel (Application.loadedLevel);
		}
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.LoadLevel ("Menu");
		}
	}

	/**
	 * Game Logic
	 */
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

			if (gameOver)
			{
				exitText.text = "Press 'Esc' to return to main menu";
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void UpdateScore ()
	{
		this.scoreText.text = "Score: " + this.GetScore ();
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	public void UpdateCheckKeyPress ()
	{
		if (Input.GetKeyDown (KeyCode.R))
		{
			Application.LoadLevel (Application.loadedLevel);
		}
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.LoadLevel ("Menu");
		}
	}

	public void ResetGameVariables ()
	{
		this.SetGameOver (false);
		this.SetRestart (false);
		this.SetExit (false);
		this.SetRestartText ("");
		this.SetExitText ("");
		this.SetGameOverText ("");
		this.SetScore (0);
	}

	public bool GetGameOver ()
	{
		return this.gameOver;
	}
	
	public void SetGameOver (bool gameOver)
	{
		this.gameOver = gameOver;
	}
	
	public bool GetRestart ()
	{
		return this.restart;
	}
	
	public void SetRestart (bool restart)
	{
		this.restart = restart;
	}
	
	public bool GetExit ()
	{
		return this.exit;
	}
	
	public void SetExit (bool exit)
	{
		this.exit = exit;
	}
	
	public string GetRestartText ()
	{
		return this.restartText.text;
	}
	
	public void SetRestartText (string restartText)
	{
		this.restartText.text = restartText;
	}
	
	public string GetExitText ()
	{
		return this.exitText.text;
	}
	
	public void SetExitText (string exitText)
	{
		this.exitText.text = exitText;
	}
	
	public string GetGameOverText ()
	{
		return this.gameOverText.text;
	}
	
	public void SetGameOverText (string gameOverText)
	{
		this.gameOverText.text = gameOverText;
	}
	
	public int GetScore ()
	{
		return this.score;
	}
	
	public void SetScore (int score)
	{
		this.score = score;
	}
}
