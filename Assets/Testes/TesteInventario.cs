using NUnit.Framework;
using RPG.Itens.Models;
using System;

public class TestesInventario
{

    [Test]
    public void Ao_Coletar_Um_Item_Inexistente_O_Inventario_Cria_Uma_Nova_Entrada()
    {
        var inventario = new Inventario();
        var stubColetavel = new MockColetavel();
        inventario.Adicionar(stubColetavel);
        Assert.IsTrue(inventario.TemItem(stubColetavel));
    }

    [Test]
    public void Ao_Coletar_Um_Item_O_Inventario_Soma_A_Quantidade_De_Itens()
    {
        var inventario = new Inventario();
        var stubColetavel = new MockColetavel();
        inventario.Adicionar(stubColetavel);
        Assert.AreEqual(inventario.QuantidadeDe(stubColetavel), 1);
        inventario.Adicionar(stubColetavel);
        Assert.AreEqual(inventario.QuantidadeDe(stubColetavel), 2);
    }

    [Test]
    public void A_Quantidade_De_Um_Item_Que_Nao_Existe_No_Inventario_E_Zero()
    {
        var inventario = new Inventario();
        var stubColetavel = new MockColetavel();
        Assert.AreEqual(inventario.QuantidadeDe(stubColetavel), 0);
    }

    [Test]
    public void O_Inventario_Chama_O_Metodo_Coletar_Do_Item_Coletado()
    {
        var inventario = new Inventario();
        var stubColetavel = new MockColetavel();
        inventario.Adicionar(stubColetavel);
        Assert.IsTrue(stubColetavel.aoSerColetadoFoiChamado);
    }

    [Test]
    public void Quando_Um_Item_E_Retirado_A_Quantidade_Dele_No_Inventario_Diminui()
    {
        var inventario = new Inventario();
        var stubColetavel = new MockColetavel();
        inventario.Adicionar(stubColetavel);
        Assert.AreEqual(inventario.QuantidadeDe(stubColetavel), 1);
        inventario.Remover(stubColetavel.Id);
        Assert.AreEqual(inventario.QuantidadeDe(stubColetavel), 0);
    }

    [Test]
    public void Ao_Retirar_Um_Item_Precisamos_Receber_Ele_Do_Inventario()
    {
        var inventario = new Inventario();
        var stubColetavel = new MockColetavel();
        inventario.Adicionar(stubColetavel);
        Assert.AreEqual(inventario.QuantidadeDe(stubColetavel), 1);
        var item = inventario.Remover(stubColetavel.Id);
        Assert.IsNotNull(item);
    }

    [Test]
    public void Nao_E_Possivel_Pegar_Itens_Com_Quantidade_Igual_A_Zero()
    {
        var inventario = new Inventario();
        var stubColetavel = new MockColetavel();
        Assert.AreEqual(inventario.QuantidadeDe(stubColetavel), 0);
        Assert.Throws<InvalidOperationException>(
            new TestDelegate(() => inventario.Remover(stubColetavel.Id)
            ));
    }


    private class MockColetavel : IColetavel
    {
        public string Id { get { return "mock"; } }

        public bool aoSerColetadoFoiChamado;

        public void Coletar()
        {
            aoSerColetadoFoiChamado = true;
        }
    }
}


