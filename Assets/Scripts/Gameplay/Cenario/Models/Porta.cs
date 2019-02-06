using RPG.Itens.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Cenario.Models
{
    public class Porta
    {
        public bool Aberta { get; private set; }
        
        private Vector3 localDeSaida;

        public Porta( Vector3 saida)
        {
            this.localDeSaida = saida;
        }

        public void Abrir(IColetavel chave)
        {
            if (chave.Id == "chave")
                this.Aberta = true;
            
         }

        public Vector3? Atravessar()
        {
            if (this.Aberta)
            {
                return this.localDeSaida;
            }
            else
            {
                return null;
            }
        }
    }
}
