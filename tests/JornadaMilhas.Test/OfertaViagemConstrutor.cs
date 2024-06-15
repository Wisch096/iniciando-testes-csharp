using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemConstrutor
{
    [Fact]
    public void RetornaOfertaValidaQuandoDadosValidos()
    {
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), 
            new DateTime(2024, 2, 5));
        double preco = 100.0;
        var validacao = true;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
        
        Assert.Equal(validacao, oferta.EhValido);
    }
    
    [Fact]
    public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidadosQuandoRotaNula()
    {
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), 
            new DateTime(2024, 2, 5));
        double preco = 100.0;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        Assert.Contains("A oferta de viagem nao possui rota ou período válidos",
            oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroDePreçoInvalidadoQuandoPrecoMenorQueZero()
    {
        Rota rota = new Rota("Origem1", "Destino1");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), 
            new DateTime(2024, 2, 5));
        double preco = -250;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
    }
}