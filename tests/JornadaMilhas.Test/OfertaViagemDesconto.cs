using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemDesconto
{
    [Fact]
    public void RetornaPrecoAtualizadoQuandoAplicadoDesconto()
    {
        Rota rota = new Rota("OrigemA", "DestinoB");
        Periodo periodo = new Periodo(new DateTime(2024, 05, 01),
            new DateTime(2024, 05, 10));
        double precoOriginal = 100.00;
        double desconto = 20.00;
        double precoComDesconto = precoOriginal - desconto;
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
        
        oferta.Desconto = desconto; 
        Assert.Equal(precoComDesconto, oferta.Preco);
    }
    
    [Fact]
    public void RetornaDescontoMaximoQuandoValorDescontoMaiorQuePreco()
    {
        Rota rota = new Rota("OrigemA", "DestinoB");
        Periodo periodo = new Periodo(new DateTime(2024, 05, 01),
            new DateTime(2024, 05, 10));
        double precoOriginal = 100.00;
        double desconto = 120.00;
        double precoComDesconto = 30.00;
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
        
        oferta.Desconto = desconto; 
        Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
    }
}