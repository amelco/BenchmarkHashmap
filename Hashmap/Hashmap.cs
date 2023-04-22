/* 
 * Hashmap: chave => hash => valor
 * Ex.:     eu    =>  2   =>  24
 *          tu    =>  20  =>  10
 *          ele   =>  4   =>  35
 *          nos   =>  4   =>  42
 * Essa implementação de hashmap tem X elementos, cada um 'balde' de tamanho máximo ao da estrutura List.
 */

public class Hashmap<T>
{
    private int _size;
    private List<Elemento<T>>[] _list;

    public Hashmap(int size)
    {
        _size = size;
        _list = new List<Elemento<T>>[_size];
    }

    public void Add(string chave, T valor)
    {
        int index = ObtemPosicao(chave);
        var elemento = new Elemento<T>() { Chave = chave, Value = valor };
        if (_list[index] == null)
        {
            _list[index] = new List<Elemento<T>>();
        }
        _list[index].Add(elemento);
    }

    public T GetValue(string chave)
    {
        int index = ObtemPosicao(chave);
        foreach (var valor in _list[index])
        {
            if (valor != null && valor.Chave != null && valor.Chave.Equals(chave))
            {
                if (valor.Value != null)
                    return valor.Value;
            }
        }
        throw new Exception("Chave não existente.");
    }

    private int ObtemPosicao(string chave)
    {
        var position = chave[0] % _size;
        return position;
    }
}

class Elemento<T>
{
    public string? Chave { get; set; }
    public T? Value { get; set; }

}