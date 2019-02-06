using RPG.Padroes.Observer;
using System;
using System.Collections.Generic;

namespace RPG.Itens.Models
{
    [Serializable]
    public class Inventario
    {
        public Dictionary<string, Stack<IColetavel>> Items { get; private set; }

        private EventHandler<ItemAdicionadoDTO> Notificar;

        public Inventario(IObservador<ItemAdicionadoDTO> observador)
        {
            this.Items = new Dictionary<string, Stack<IColetavel>>();

            this.Notificar += observador.Notificar;
        }

        public Inventario()
        {
            this.Items = new Dictionary<string, Stack<IColetavel>>();
        }

        public void Adicionar(IColetavel coletavel)
        {
            var id = coletavel.Id;
            CriarEntradaSeNaoExistir(id);
            this.Items[id].Push(coletavel);
            coletavel.Coletar();
            this.Publicar(id);
        }

        public IColetavel Remover(string id)
        {
            if (this.Items.ContainsKey(id))
            {
                var coletavel = this.Items[id].Pop();
                this.Publicar(id);
                return coletavel;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public bool TemItem(IColetavel coletavel)
        {
            return this.TemItem(coletavel.Id);
        }

        public bool TemItem(string id)
        {
            return this.Items.ContainsKey(id) && this.Items[id].Count > 0;
        }

        public int QuantidadeDe(IColetavel coletavel)
        {
            return this.QuantidadeDe(coletavel.Id);
        }

        public int QuantidadeDe(string id)
        {
            if (this.TemItem(id))
            {
                return this.Items[id].Count;
            }
            return 0;
        }

        private void CriarEntradaSeNaoExistir(string id)
        {
            if (!this.Items.ContainsKey(id))
            {
                var listaDeItens = new Stack<IColetavel>();
                this.Items.Add(id, listaDeItens);
            }
        }

        private void Publicar(string item)
        {
            var dados = new ItemAdicionadoDTO(item, QuantidadeDe(item));
            this.Notificar?.Invoke(this, dados);
        }
    }
}