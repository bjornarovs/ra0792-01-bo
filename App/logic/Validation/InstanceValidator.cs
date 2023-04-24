using System.Threading.Tasks;
using Altinn.App.Core.Features;
using Altinn.Platform.Storage.Interface.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Altinn.App.AppLogic.Validation;

public class InstanceValidator : IInstanceValidator
{
    public async Task ValidateData(object data, ModelStateDictionary validationResults)
    {
        await Task.CompletedTask;
    }

    public async Task ValidateTask(Instance instance, string taskId, ModelStateDictionary validationResults)
    {
        await Task.CompletedTask;
    }
}