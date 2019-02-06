using RPG.Itens.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Itens.Controllers
{
    public class Chave : MonoBehaviour, IColetavel {
        public string Id { get { return "chave"; } }

        public void Coletar()
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}