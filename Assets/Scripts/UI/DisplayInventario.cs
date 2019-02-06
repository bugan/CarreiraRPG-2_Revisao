using UnityEngine;
using UnityEngine.UI;
using RPG.Itens.Controllers;
using RPG.Padroes.Observer;
using TMPro;

namespace RPG.UI
{
    public class DisplayInventario : MonoBehaviour, IAssinante<ItemAdicionadoDTO>
    {
        [SerializeField]
        private string idItem;

        [SerializeField]
        private InventarioController inventarioController;

        private TextMeshProUGUI quantidadeDeChaves;

        private void Awake()
        {
            this.quantidadeDeChaves = this.GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            this.inventarioController.Assinar(this, this.idItem);
           
        }

        public void Atualizar(ItemAdicionadoDTO dados)
        {
            this.quantidadeDeChaves.text = "x " + dados.quantidade;
        }
    }
}
