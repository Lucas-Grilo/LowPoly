using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerController2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 moviment;
    private Rigidbody rb;
    public Camera mainCamera;
    private Vector3  direction;
    
    public int vidaMaxima = 100; // Vida máxima do jogador
    private int vidaAtual;

    public int maxHealth = 100; // Vida máxima do personagem
    public int currentHealth; // Vida atual do personagem

    public float health = 100f; // Saúde do jogador

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
         currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        moviment.x = Input.GetAxisRaw("Horizontal");
        moviment.z = Input.GetAxisRaw("Vertical");
        direction = new Vector3(moviment.x, 0, moviment.z);

        if(direction !=Vector3.zero)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
             GetComponent<Animator>().SetBool("isWalking", false);
        }

        RotateTowardsMouse();

    }

    void FixedUpdate()
    {
        Vector3 moveDirection = moviment.normalized * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);
    }
    
    void RotateTowardsMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf. Infinity));
        {
            Vector3 direction = hit. point - transform.position;
            direction.y = 0;
            Quaternion toRotation = Quaternion. LookRotation(direction); transform.
            rotation = Quaternion.RotateTowards (transform.rotation,toRotation, 1000 * Time.deltaTime);
        }
    }
     
     public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduz a vida atual pelo dano recebido
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Garante que a vida não fique negativa

        Debug.Log("Vida Atual: " + currentHealth);
        
        if (currentHealth <= 100)
        {
            Die();
        }
    }

    // Método para curar o personagem
    public void Heal(int healAmount)
    {
        currentHealth += healAmount; // Aumenta a vida atual
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Garante que a vida não ultrapasse o máximo

        Debug.Log("Vida Atual: " + currentHealth);
    }

    // Método chamado quando a vida do personagem chega a zero
    private void Die()
    {
        Debug.Log("O personagem morreu!");
        // Aqui você pode adicionar lógica para a morte do personagem, como reiniciar o jogo, tocar uma animação, etc.
    }

    public void RecuperarVida(int quantidade)
    {
        vidaAtual += quantidade; // Recupera vida
        if (vidaAtual > vidaMaxima) // Garante que a vida não ultrapasse o máximo
        {
            vidaAtual = vidaMaxima;
        }

        Debug.Log("Vida atual: " + vidaAtual); // Exibe a vida atual no console
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Player took damage: " + damage + ", remaining health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }


}