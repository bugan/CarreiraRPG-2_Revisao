using System;
using UnityEngine;

namespace RPG.Gameplay
{
    [Serializable]
    public class Movimentacao
    {
        public Vector2 PosicaoAtual { get { return this.fisica.position; } }
        public bool EstaAndando { get { return this.direcao != Vector2.zero; } }

        public float velocidade;

        private Vector2 direcao;
        private Rigidbody2D fisica;

        public void Init(Rigidbody2D fisica)
        {
            this.fisica = fisica;
        }

        public void Teletransportar(Vector2 posicao)
        {
            this.fisica.position = posicao;
        }
        
        public void Andar(float tempo)
        {
            this.fisica.position += this.direcao * this.velocidade * tempo;
        }

        public void MudarDirecao(Vector2 novaDirecao)
        {
            this.direcao = novaDirecao.normalized;
        }
    }
}
