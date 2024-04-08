using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class MusicaTest
{
    [Fact]
    public void TesteNomeDaMusicaInicializadoCorretamente()
    {
        string nome = "Música teste";
        Musica musica = new Musica(nome);
        Assert.Equal(nome, musica.Nome);
    }
    
    [Fact]
    public void TesteIdInicializadoCorretamente()
    {
        string nome = "Música teste";
        int id = 13;
        
        Musica musica = new Musica(nome) {Id = id};
        
        Assert.Equal(id, musica.Id);
    }
    
    [Fact]
    public void TestToString()
    {
        int id = 1;
        string nome = "Música teste";
        Musica musica = new Musica(nome);
        musica.Id = id;
        string toStringEsperado = $@"Id: {id} Nome: {nome}";

        string resultado = musica.ToString();
        
        Assert.Equal(toStringEsperado, resultado);
    }
}