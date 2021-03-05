using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    //teknoloji bağımsız interface yapısı
    public interface ICacheManager
    {
        T Get<T>(string key);//with generic
        object Get(string key); //without generic
        void Add(string key, object value, int duration); //duration (min or hour)
        bool IsAdd(string key);
        void Remove(string key);//remove from the cache
        void RemoveByPattern(string pattern);
    }
}
