using AEC.Core.Exceptional;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AEC.Core.Exceptional;

namespace AEC.Core
{
    public static class TaskExtensions
    {
        [SuppressMessage("ReSharper", "VariableHidesOuterVariable", Justification = "Pass params explicitly to async local function or it will allocate to pass them")]
        public static void FireAndForget(this Task task, IExceptional logger = null, [CallerMemberName] string callingMethodName = null)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));

            // Allocate the async/await state machine only when needed for performance reasons.
            // More info about the state machine: https://blogs.msdn.microsoft.com/seteplia/2017/11/30/dissecting-the-async-methods-in-c/?WT.mc_id=DT-MVP-5003978
            // Pass params explicitly to async local function or it will allocate to pass them
            static async Task ForgetAwaited(Task task, IExceptional logger = null, string callingMethodName = "")
            {
                try
                {
                    await task;
                }
                catch (TaskCanceledException tce)
                {
                    // log a message if we were given a logger to use
                    logger?.LogError(tce, $"Fire and forget task was canceled for calling method: {callingMethodName}");
                }
                catch (Exception e)
                {
                    // log a message if we were given a logger to use
                    logger?.LogError(e, $"Fire and forget task failed for calling method: {callingMethodName}");
                }
            }

            // note: this code is inspired by a tweet from Ben Adams: https://twitter.com/ben_a_adams/status/1045060828700037125
            // Only care about tasks that may fault (not completed) or are faulted,
            // so fast-path for SuccessfullyCompleted and Canceled tasks.
            if (!task.IsCanceled && (!task.IsCompleted || task.IsFaulted))
            {
                // use "_" (Discard operation) to remove the warning IDE0058: Because this call is not awaited, execution of the
                // current method continues before the call is completed - https://learn.microsoft.com/en-us/dotnet/csharp/discards#a-standalone-discard
                _ = ForgetAwaited(task, logger, callingMethodName);
            }
        }
    }
}
