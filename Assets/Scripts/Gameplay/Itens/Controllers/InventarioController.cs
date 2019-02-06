using RPG.Itens.Models;
using RPG.Padroes.Observer;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Itens.Controllers
{
    public class InventarioController : MonoBehaviour, IObservador<ItemAdicionadoDTO>, IPublicador<ItemAdicionadoDTO>
    {
        private Inventario inventario;
        private Dictionary<string, List<IAssinante<ItemAdicionadoDTO>>> canais;

        private void Awake()
        {
            this.canais = new Dictionary<string, List<IAssinante<ItemAdicionadoDTO>>>();
            this.inventario = new Inventario(this);
        }

        public void Adicionar(IColetavel coletavel)
        {
            this.inventario.Adicionar(coletavel);
        }

        public IColetavel Remover(string itemID)
        {
            return this.inventario.Remover(itemID);
        }

        public bool TemItem(string itemId)
        {
            return this.inventario.TemItem(itemId);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IColetavel coletavel = collision.GetComponent<Collider2D>().GetComponent<IColetavel>();
            if (coletavel != null)
            {
                this.inventario.Adicionar(coletavel);
            }
        }

        public void Notificar(object sender, ItemAdicionadoDTO dados)
        {
            if (this.canais.ContainsKey(dados.id))
            {
                foreach (var assinante in canais[dados.id])
                {
                    assinante.Atualizar(dados);
                }
            }
        }

        public void Assinar(IAssinante<ItemAdicionadoDTO> assinante, string canal)
        {
            if (!this.canais.ContainsKey(canal))
            {
                this.canais.Add(canal, new List<IAssinante<ItemAdicionadoDTO>>());
            }

            this.canais[canal].Add(assinante);
        }
    }

}