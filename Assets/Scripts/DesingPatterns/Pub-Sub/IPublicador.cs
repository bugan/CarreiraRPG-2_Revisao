using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPublicador<T>
{
    void Assinar(IAssinante<T> assinante, string canal);
}
