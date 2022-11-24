﻿using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace ITCOURSES.MongoDB;

[DependsOn(
    typeof(ITCOURSESTestBaseModule),
    typeof(ITCOURSESMongoDbModule)
    )]
public class ITCOURSESMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var stringArray = ITCOURSESMongoDbFixture.ConnectionString.Split('?');
        var connectionString = stringArray[0].EnsureEndsWith('/') +
                                   "Db_" +
                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connectionString;
        });
    }
}
