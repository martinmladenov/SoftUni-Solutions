namespace SIS.Framework.Routers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using ActionResults;
    using Attributes.Methods;
    using Controllers;
    using HTTP.Enums;
    using HTTP.Extensions;
    using HTTP.Requests;
    using HTTP.Responses;
    using Services;
    using WebServer.Api;
    using WebServer.Results;

    public class ControllerRouter : IHttpHandler
    {
        private IDependencyContainer dependencyContainer;

        public ControllerRouter(IDependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        private Controller GetController(string controllerName)
        {
            if (string.IsNullOrWhiteSpace(controllerName))
            {
                return null;
            }

            var fullyQualifiedControllerName = string.Format("{0}.{1}.{2}{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                controllerName.Capitalize(),
                MvcContext.Get.ControllerSuffix);

            var controllerType = Type.GetType(fullyQualifiedControllerName);

            if (controllerType == null)
            {
                return null;
            }

            var controller = (Controller) this.dependencyContainer.CreateInstance(controllerType);

            return controller;
        }

        private MethodInfo GetMethod(string requestMethod, Controller controller, string actionName)
        {
            var actions = this
                .GetSuitableMethods(controller, actionName)
                .ToList();

            if (!actions.Any())
            {
                return null;
            }

            foreach (var action in actions)
            {
                var httpMethodAttributes = action
                    .GetCustomAttributes()
                    .Where(ca => ca is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>()
                    .ToArray();

                if (!httpMethodAttributes.Any() &&
                    requestMethod.ToLower() == "get"
                    || httpMethodAttributes.Any(attribute => attribute.IsValid(requestMethod)))
                {
                    return action;
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(mi => mi.Name.ToLower() == actionName.ToLower());
        }

        private IHttpResponse PrepareResponse(IActionResult result)
        {
            string invocationResult = result.Invoke();

            if (result is IViewable)
            {
                return new HtmlResult(invocationResult, HttpResponseStatusCode.Ok);
            }

            if (result is IRedirectable)
            {
                return new WebServer.Results.RedirectResult(invocationResult);
            }

            return null;
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            var requestMethod = request.RequestMethod.ToString();

            string controllerName;
            string actionName;

            if (request.Path == "/")
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                var requestUrlSplit = request.Url.Split(
                    "/",
                    StringSplitOptions.RemoveEmptyEntries);

                if (requestUrlSplit.Length != 2)
                {
                    return null;
                }

                controllerName = requestUrlSplit[0];
                actionName = requestUrlSplit[1];
            }

            Controller controller = this.GetController(controllerName);

            MethodInfo action = this.GetMethod(requestMethod, controller, actionName);

            if (action == null)
            {
                return null;
            }

            object[] actionParameters = this.MapActionParameters(controller, action, request);

            IActionResult result = this.InvokeAction(controller, action, actionParameters);

            return this.PrepareResponse(result);
        }

        private IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParams)
        {
            return (IActionResult) action.Invoke(controller, actionParams);
        }

        private object[] MapActionParameters(Controller controller, MethodInfo action, IHttpRequest request)
        {
            ParameterInfo[] actionParametersInfo = action.GetParameters();

            object[] mappedActionParameters = new object[actionParametersInfo.Length];

            for (int i = 0; i < actionParametersInfo.Length; i++)
            {
                ParameterInfo current = actionParametersInfo[i];

                if (current.ParameterType.IsPrimitive
                    || current.ParameterType == typeof(string))
                {
                    mappedActionParameters[i] = this.ProcessPrimitiveParameter(current, request);
                }
                else
                {
                    object bindingModel = this.ProcessBindingModelParameters(current, request);
                    controller.ModelState.IsValid = this.IsModelValid(bindingModel, current.ParameterType);
                    mappedActionParameters[i] = bindingModel;
                }
            }

            return mappedActionParameters;
        }

        private bool IsModelValid(object bindingModel, Type bindingModelType)
        {
            var properties = bindingModelType.GetProperties();

            foreach (var property in properties)
            {
                var propertyValidationAttributes = property
                    .GetCustomAttributes()
                    .Where(ca => ca is ValidationAttribute)
                    .Cast<ValidationAttribute>()
                    .ToList();

                foreach (var validationAttribute in propertyValidationAttributes)
                {
                    var propertyValue = property.GetValue(bindingModel);

                    if (!validationAttribute.IsValid(propertyValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private object ProcessPrimitiveParameter(ParameterInfo param, IHttpRequest request)
        {
            return Convert.ChangeType(this.GetParameterFromRequestData(request, param.Name), param.ParameterType);
        }

        private object GetParameterFromRequestData(IHttpRequest request, string paramName)
        {
            if (request.QueryData.ContainsKey(paramName))
            {
                return request.QueryData[paramName];
            }

            if (request.FormData.ContainsKey(paramName))
            {
                return request.FormData[paramName];
            }

            return null;
        }

        private object ProcessBindingModelParameters(ParameterInfo param, IHttpRequest request)
        {
            Type bindingModelType = param.ParameterType;

            var bindingModelInstance = Activator.CreateInstance(bindingModelType);

            var bindingModelProperties = bindingModelType.GetProperties();

            foreach (var property in bindingModelProperties)
            {
                try
                {
                    object value = this.GetParameterFromRequestData(request, property.Name);
                    property.SetValue(bindingModelInstance, Convert.ChangeType(value, property.PropertyType));
                }
                catch
                {
                    Console.WriteLine($"The {property.Name} field could not be mapped.");
                }
            }

            return Convert.ChangeType(bindingModelInstance, bindingModelType);
        }
    }
}