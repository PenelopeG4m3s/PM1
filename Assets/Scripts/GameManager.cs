using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs")]
    public static GameManager instance;
    public GameObject playerControllerPrefab;
    public GameObject playerPawnPrefab;
    [Header("Up-to-date Lists")]
    public List<Pawn> tanks;
    public List<Controller> players;

    void Awake()
    {
        // Create our singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        // Create our up to date list objects (not just memory locations )
        tanks = new List<Pawn>();
        players = new List<Controller>();
    }

    void Start()
    {
        // Create our up to date list objects
        StartGame();

    }

    public void StartGame()
    {
        // Do everything that we need to start the game

        // Spawn the player
        SpawnPlayer();

    }

    public void SpawnPlayer()
    {
        // Spawn a tank pawn (and store it in tanks)
        Pawn tempTankPawn = SpawnTank( playerPawnPrefab );

        // Spawn a player controller (and store it in player)
        Controller tempPlayerController = SpawnPlayerController(playerControllerPrefab);

        // Have the player possess the pawn
        tempPlayerController.Possess(tempTankPawn);
    }

    public Pawn SpawnTank( GameObject prefab )
    {
        GameObject tempTankObject = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity);
        return tempTankObject.GetComponent<Pawn>();
    }

    public Controller SpawnPlayerController ( GameObject prefab )
    {
        GameObject tempPlayer = Instantiate<GameObject>( prefab, Vector3.zero, Quaternion.identity );
        return tempPlayer.GetComponent<Controller>();
    }
}
