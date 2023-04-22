using BenchmarkDotNet.Attributes;

namespace Hashmap
{
    [MemoryDiagnoser]
    public class HashBenchmark
    {
        int tamanho = 1_000;
        int seed = 65;

        [Benchmark]
        public void Hashmap()
        {
            var chaves = GetChaves();
            var hashmap = new Hashmap<int>(tamanho);
            for (var i = 0; i < tamanho; i++)
            {
                int valor = i;
                hashmap.Add(chaves[i], valor);
            }
            foreach (var chave in chaves)
            {
                var item = hashmap.GetValue(chave);
            }
        }

        [Benchmark]
        public void HashSet()
        {

            var chaves = GetChaves();
            HashSet<string> keys = new HashSet<string>();
            for (var i = 0; i < tamanho; i++)
            {
                keys.Add(chaves[i]);
            }
            foreach (var chave in chaves)
            {
                var item = keys.TryGetValue(chave, out string? value);
            }
        }

        private string[] GetChaves()
        {
            string[] chaves = new string[tamanho];
            var rnd = new Random(seed);
            for (var i = 0; i < tamanho; i++)
            {
                chaves[i] = ((char)rnd.Next(65, 92)).ToString() + ((char)rnd.Next(65, 92)).ToString() + ((char)rnd.Next(65, 92)).ToString();
            }
            return chaves;
        }
    }
}
