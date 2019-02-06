using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

namespace RPG.Gameplay.Personagens
{
    public class MovimentacaoController : MonoBehaviour
    {
        [SerializeField]
        private InputMaster inputs;
        [SerializeField]
        private Movimentacao movimentacao;

        private Rigidbody2D fisica;
        private Animator animator;

        private void Awake()
        {
            this.fisica = this.GetComponent<Rigidbody2D>();
            this.animator = this.GetComponent<Animator>();
            this.movimentacao.Init(this.fisica);
            this.movimentacao.Teletransportar(this.transform.position);
            this.inputs.Jill.Andar.performed += LerInputs;
        }


        private void OnEnable()
        {
            inputs.Enable();
        }


        private void OnDisable()
        {
            inputs.Disable();
        }
      

        private void FixedUpdate()
        {
            this.movimentacao.Andar(Time.fixedDeltaTime);
            this.animator.SetBool("EstaAndando", this.movimentacao.EstaAndando);
        }

        
        private void LerInputs(InputAction.CallbackContext contexto)
        {
            var direcao = contexto.ReadValue<Vector2>();
            this.MudarDirecao(direcao);
        }


        public void MudarDirecao(Vector2 novaDirecao)
        {
            this.movimentacao.MudarDirecao(novaDirecao);
            if (novaDirecao != Vector2.zero)
            {
                this.animator.SetFloat("VelocidadeX", novaDirecao.x);
                this.animator.SetFloat("VelocidadeY", novaDirecao.y);
            }
        }


        public void Teletransportar(Vector3? posicao)
        {
            if (posicao == null) return;

            this.movimentacao.Teletransportar((Vector2)posicao);
        }
    }
}
