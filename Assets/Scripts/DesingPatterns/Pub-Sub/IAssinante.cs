using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAssinante<T>
{
    void Atualizar(T dados);
}
