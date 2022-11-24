using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ITCOURSES.Data;

/* This is used if database provider does't define
 * IITCOURSESDbSchemaMigrator implementation.
 */
public class NullITCOURSESDbSchemaMigrator : IITCOURSESDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
