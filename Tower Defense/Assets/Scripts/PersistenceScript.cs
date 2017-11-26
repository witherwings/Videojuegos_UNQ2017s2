using UnityEngine;

public class PersistenceScript : MonoBehaviour 
{
	public static PersistenceScript Instance;

	public bool hardMode = false;
	public int lives;
	public int money;
	public int levelReached = 1;

	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}
}
