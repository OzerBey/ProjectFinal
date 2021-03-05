﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    //servis bagımlılıklarımızı cözümleyecegimiz yer
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //microsoft kendi içinde otomatik injection yapıyor burada --arka tarafta hazır bir ICacheManager instance oluşturuyor

            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();

            //for Redis
            // serviceCollection.AddSingleton<ICacheManager, RedisCacheManager>();


        }
    }
}
