    using RPG.Gameplay;
using RPG.Gameplay.Personagens;
using RPG.Itens.Controllers;
using System;
using UnityEngine;

namespace RPG.Cenario.Controllers
{
    public class PortaController : MonoBehaviour
    {
        
        [SerializeField]
        private Transform localDeSaida;

        private Animator animator;
        private bool aberta;

        private Models.Porta porta;
        private void Awake()
        {
            this.porta = new Models.Porta(localDeSaida.position);
            this.animator = this.GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        { 
            var personagem = collision.GetComponent<MovimentacaoController>();
            var inventario = collision.GetComponent<InventarioController>();

            if (this.porta.Aberta)
            {
                personagem.Teletransportar(this.porta.Atravessar());
            }
            else if(inventario.TemItem("chave"))
            {
                var chave = inventario.Remover("chave");
                this.porta.Abrir(chave);
            }
        }
    }
}
