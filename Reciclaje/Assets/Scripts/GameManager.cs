using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Reciclados")]
    [SerializeField] private int reciclados;
    [SerializeField] private Text recicladosTxt;

    [Header("Life")]
    [SerializeField] private float lifes;
    [SerializeField] private Text lifesTxt;

    [Header("Time")]
    [SerializeField] private float time;
    [SerializeField] private Text timeTxt;

    [Header("Score")]
    [SerializeField]private int points;

    [Header("Others")]
    private bool gameRunning = true;
    [SerializeField] private GameObject[] spawners;

    public bool GameRunning
    {
        get
        {
            return gameRunning;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //resto 1 segundo
        if(gameRunning)
        time -= Time.deltaTime;

        timeTxt.text = "" + (int)time;
        recicladosTxt.text = "" + reciclados + "/20";
        lifesTxt.text = "" + lifes + "/3";

        //actualizo los tiempos de spawn de cada spawner
        if(time == 90)
        {
            updateSpawners("Lap2");
        }
        if(time == 30)
        {
            updateSpawners("Lap3");
        }

        //1° caso de ganar
        if(reciclados >= 20 && gameRunning)
        {
            Win();
        }

        //1° caso de perdida
        if(lifes <= 0 && gameRunning)
        {
            Lose();
        }
        //2° caso de perdida
        if(time <= 0 && gameRunning)
        {
            Lose();
        }
    }

    private void updateSpawners(string lap)
    {
        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i].GetComponent<Spawner>().ActualLap = lap;
        }
    }

    public void Win()
    {
        gameRunning = false;
        Debug.Log("Ganaste");
    }
    public void Lose()
    {
        gameRunning = false;
        Debug.Log("Perdiste");
    }


    public void AddPoints(int points)
    {
        this.points += points;
    }
    public void RemovePoints(int points)
    {
        if(this.points > points)
        this.points -= points;
    }

    public void AddReciclados()
    {
        reciclados += 1;
    }
    public void RemoveLife()
    {
        lifes -= 1;
    }
}
