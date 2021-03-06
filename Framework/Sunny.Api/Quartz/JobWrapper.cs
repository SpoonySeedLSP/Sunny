using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using Sunny.Common.Helper;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sunny.Api.Quartz
{
    [PersistJobDataAfterExecution]
    public class JobWrapper<T> : IJob where T : IJobEntity
    {
        ILogger logger;
        T job;
      

        public JobWrapper()
        {
            logger = DiHelper.GetService<ILoggerFactory>().CreateLogger(typeof(T));
            job = DiHelper.CreateInstance<T>();
           
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Stopwatch sw = new Stopwatch();

            try
            {
                sw.Start();
                await job.ExecuteAsync(context);
                sw.Stop();

                logger.LogInformation($"Job（ Name: {job.JobName} , Describe:{job.Describe}）已执行,耗时:{sw.ElapsedMilliseconds} 毫秒.");

            }
            catch (Exception ex)
            {
                sw.Stop();
                logger.LogError($"Job（ Name: {job.JobName} , Describe:{job.Describe}）执行时发生异常.", ex);
            }
            finally
            {
                IDisposable disposable = job as IDisposable;
                disposable?.Dispose();
            }
        }
    }
}
