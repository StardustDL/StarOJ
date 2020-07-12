using StarOJ.Models.Judging;
using System.Threading;
using System.Threading.Tasks;

namespace StarOJ.Sdk
{
    public interface IJudgerService
    {
        Task<string?> Create(JudgingTask task, CancellationToken cancellationToken = default);

        Task<JudgingTask?> Get(string id, CancellationToken cancellationToken = default);
    }
}
