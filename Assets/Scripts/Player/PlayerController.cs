using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerControlData playerControlData;
    [SerializeField] private GameObject playerPrefab;

    private Rigidbody2D rd;
    private int angle;
    private bool isPlayer;
    [SerializeField] private Vector2 respawn;
    private int countShadow;
    private float distance;

    public float curTinme = 10f;
    // Key di chuyen
    private KeyCode keyA;
    private KeyCode keyS;
    private KeyCode keyW;
    private KeyCode keyD;
    // Key chieu
    private KeyCode keyU;
    private KeyCode keyI;
    private KeyCode keyO;
    private KeyCode keyP;

    private KeyCode keySpace;

    private bool check = false;

    private void OnEnable()
    {
        rd = GetComponent<Rigidbody2D>();
        GetKeyControl();
        countShadow = playerData.countShadow;
        distance = playerData.distance;
        angle = 1;
        isPlayer = true;
    }

    private void GetKeyControl()
    {
        keyA = playerControlData.keyA;
        keyS = playerControlData.keyS;
        keyW = playerControlData.keyW;
        keyD = playerControlData.keyD;
        keyU = playerControlData.keyU;
        keyI = playerControlData.keyI;
        keyO = playerControlData.keyO;
        keyP = playerControlData.keyP;
        keySpace = playerControlData.keySpace;
    }

    private void Update()
    {
        if (isPlayer)
        {
            ControllPlayer();
        }
    }

    private void ControllPlayer()
    {
        // di chuyen
        if (Input.GetKey(keyA))
        {
            Move(Vector2.left * playerData.speed);
            angle = -1;
        }
        if (Input.GetKey(keyD))
        {
            Move(Vector2.right * playerData.speed);
            angle = 1;
        }
        if (Input.GetKey(keyS))
        {
            // đi rón rén
        }
        if (Input.GetKeyDown(keyW))
        {
            Move(new Vector2(0, playerData.jump));
        }
        // skill
        if (Input.GetKeyDown(keyU))
        {
            Move(Vector2.right * 10f * angle);
        }
        if (Input.GetKeyDown(keyI))
        {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + Vector2.right * 10000000000 * angle, 10f);
        }
        if (Input.GetKeyDown(keyO))
        {

        }
        if (Input.GetKeyDown(keyP))
        {

        }

        // chua fix
        if (check) curTinme -= Time.deltaTime;
        if (curTinme <= 0)
        {
            curTinme = 10f;
            isPlayer = false;
            GameObject obj = Instantiate(playerPrefab);
            obj.transform.position = respawn;

            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(keySpace) && countShadow > 0)
        {
            if (countShadow == playerData.countShadow)
            {
                respawn = transform.position;
                check = true;
            }
            countShadow -= 1;
        }
    }

    private void Move(Vector2 cur)
    {
        rd.velocity = cur;
    }

    
}
