using System.Threading.Tasks;

namespace ITCOURSES.Data;

public interface IITCOURSESDbSchemaMigrator
{
    Task MigrateAsync();
}
