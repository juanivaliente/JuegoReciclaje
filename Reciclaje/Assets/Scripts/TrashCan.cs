using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField] private int id;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<SimpleIA>().Id == id)
        {
            //si el objeto que entro al cubo es reciclable suma puntos y se destruye
            if (collision.gameObject.tag == "Reciclable")
            {
                Destroy(collision.gameObject);
                gm.AddPoints(1);
                gm.AddReciclados();
            }
            //sino se destruye el objeto y se quitan puntos
            else
            {
                Destroy(collision.gameObject);
                gm.RemovePoints(2);
                gm.RemoveLife();
            }
        }
    }
}
