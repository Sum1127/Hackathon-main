using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogmove : MonoBehaviour
{
    Transform playerTr;
    Transform batTr;
    [SerializeField] public float dogHP;
    [SerializeField] public float dogattack;
    [SerializeField] float walk;
    [SerializeField] float run;
    private float hidari;
    private float migi;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        batTr = transform;
        hidari = transform.localScale.x;
        migi = transform.localScale.x * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerTr.position) < 5.0f)
        {
            return;}

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerTr.position.x, playerTr.position.y), walk * Time.deltaTime);

        Vector3 localScale = transform.localScale;
        if (playerTr.position.x - batTr.position.x < 0)
        {
            localScale.x = hidari;
        }

        else if (playerTr.position.x - batTr.position.x > 0)
        {
            localScale.x = migi;
        }
        transform.localScale = localScale;

        if (dogHP <= 0)
        {
            Destroy(this.gameObject, 3.0f);
        }
    }
}

