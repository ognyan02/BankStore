using Microsoft.Extensions.Diagnostics.HealthChecks;
namespace BankStore.Healthcheck
{
    public class CHealthCheckcs : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            var isHealthy = true;
            if (isHealthy)
            {
                return Task.FromResult(HealthCheckResult.Healthy("A healthy result: "));
            }
            return Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, "A healthy result: "));
        }
    }
}
