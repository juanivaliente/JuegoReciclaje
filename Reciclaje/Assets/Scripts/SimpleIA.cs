using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleIA : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private int id;
    private GameManager gm;

    public int Id
    {
        set
        {
            id = value;
        }
        get
        {
            return id;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento del personaje
        rb.velocity = -(transform.right * speed);

        //Si el juego finalizo destruyo todos los objetos para que no modifiquen el estado
        if (!gm.GameRunning)
            Destroy(gameObject);
    }

    //cuando haga tap sobre el personaje se destruye
    public void OnMouseDown()
    {
        
        if(gameObject.tag == "Reciclable")
        {
            gm.RemovePoints(1);
        }
        else
        {
            gm.AddPoints(1);
        }

        Destroy(gameObject);
    }
}
