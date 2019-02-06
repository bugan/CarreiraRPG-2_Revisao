using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemAdicionadoDTO
{
    public string id;
    public int quantidade;

    public ItemAdicionadoDTO(string id, int quantidade)
    {
        this.id = id;
        this.quantidade = quantidade;
    }
}
