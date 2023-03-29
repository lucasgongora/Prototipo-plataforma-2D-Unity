using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] public GameObject item;
    private BoxCollider2D boxCollider;
    private ItemManager itemManager;
    private Material myMaterial;
    private bool colision = false;
    private float itemSpeed;
    private float inicialPosition;
    private Color myColor;
    [Range(0f, 1f)]
    [SerializeField] private float myAlpha = 1f;

    private void Start()
    {
        itemManager = GameObject.Find("ItemsManager").GetComponent<ItemManager>();
        myMaterial = gameObject.GetComponent<SpriteRenderer>().material;
        boxCollider = GetComponent<BoxCollider2D>();
        myColor = Color.white;
        myMaterial.color = myColor;
        inicialPosition = transform.position.y;
    }
    void Update()
    {
        myColor.a = myAlpha;
        myMaterial.color = myColor;
        itemSpeed = itemManager.SpeedItemDeath;
        if (colision == true)
        {
            myAlpha -= itemSpeed * Time.deltaTime;
            Vector2 myVector = new Vector2(transform.position.x, inicialPosition + 2);
            transform.position = Vector2.MoveTowards(transform.position, myVector, itemSpeed * Time.deltaTime);
        }
        if (myAlpha <= 0f || transform.position.y == inicialPosition + 2)
        {
            Destroy(gameObject);
        }
    }
    //inician al mismo tiempo pero realmente no llega a la posicion final al mismo tiempo que el alpha 0.
    //visualmente si se destruye al mismo tiempo de lo que se hace transparente, pero no es matematicamente real.
    //no supe como hacerlo perfectamente. Me salió así.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            colision = true;
            if (item.tag  == "Heart")
            {
                itemManager.Heart();
            }
            if (item.tag == "CoinShine")
            {
                itemManager.CoinShine();
            }
            if (item.tag == "CoinSpin")
            {
                itemManager.CoinSpin();
            }
            boxCollider.enabled = false;   //esta linea evita que una sola colision con el player lo contabilice mas de una vez.
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}                                      
