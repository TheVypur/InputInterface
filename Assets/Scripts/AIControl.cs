using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    private InputInterface m_Input;
    private float fTimer = 0;
    private float fMaxTimer = 1;
    private KeyCode keyHeldDown;
    // Start is called before the first frame update
    void Start()
    {
        m_Input = GetComponent<InputInterface>();
    }

    private void Update()
    {
        m_Input.Clear();
        m_Input.AddKeyPressed(keyHeldDown);

        fTimer += Time.deltaTime;

        if (fTimer > fMaxTimer)
        {
            fTimer -= fMaxTimer;

            // Pick a random direction
            int iRand = Random.Range(0, 5);
            if (iRand == 0)
            {
                keyHeldDown = KeyCode.W;
            }
            else if (iRand == 1)
            {
                keyHeldDown = KeyCode.A;
            }
            else if (iRand == 2)
            {
                keyHeldDown = KeyCode.S;
            }
            else if (iRand == 3)
            {
                keyHeldDown = KeyCode.D;
            } 
            else if (iRand == 4)
            {
                keyHeldDown = KeyCode.Space;
            }
        }
    }
}
