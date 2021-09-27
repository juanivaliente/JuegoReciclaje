using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] reciclables;
    [SerializeField] private int spawnId;
    private int time = 0;
    private string actualLap = "Lap1";
    private bool allowInstance = true;
    private GameManager gm;

    public string ActualLap
    {
        set
        {
            actualLap = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //se llama al metodo de generar objetos
        if (gm.GameRunning)
        {
            if (allowInstance)
            {
                StartCoroutine(Generate());
            }
        }
    }

    IEnumerator Generate()
    {
        //desactivo para que no se vuelva a llamar al metodo
        allowInstance = false;

        //se elige el tiempo de creacion dependiendo la fase en la que se este
        switch(actualLap)
        {
            case "Lap1":
                Lap1();
                break;
            case "Lap2":
                Lap2();
                break;
            case "Lap3":
                Lap3();
                break;
        }   

        //tiempo de espera
        yield return new WaitForSeconds(time);

        //creacion del objeto
        int i = Random.Range(0, reciclables.Length);
        GameObject instance = Instantiate(reciclables[i], transform.position, transform.rotation);
        instance.GetComponent<SimpleIA>().Id = spawnId;

        //vuelvo a activar para llamar de nuevo al metodo
        allowInstance = true;
    }

    public void Lap1()
    {
        time = Random.Range(5, 7);
    }
    public void Lap2()
    {
        time = Random.Range(4, 6);
    }
    public void Lap3()
    {
        time = Random.Range(3, 5);
    }
}
