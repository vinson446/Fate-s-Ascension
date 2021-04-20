using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerScript : MonoBehaviour
{
    [SerializeField] int hp;
    public int HP { get => hp; set => hp = value; }

    [SerializeField] float moveSpeed;
    CharacterController charController;

    UIManager uiManager;


    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();

        uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.zero;
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.z = Input.GetAxisRaw("Vertical");
       
        charController.Move(velocity * Time.deltaTime * moveSpeed);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        uiManager.UpdatePlayerHealth();
    }

}
