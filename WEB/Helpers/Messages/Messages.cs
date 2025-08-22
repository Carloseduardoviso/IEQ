using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace WEB.Helpers.Messages
{
    public class Alert
    {
        public string Title { get; set; }
        public string AlertStyle { get; set; }
        public string Message { get; set; }
    }

    public static class DefaultMessage
    {
        public const string success = "Operação realizada com sucesso!";
        public const string error = "Falha no decorrer da operação!";
    }

    public enum MessageType
    {
        success,
        info,
        warning,
        error,
    }

    public class NotificationMessage : ActionResult
    {
        private readonly ActionResult _actionResult;
        public string Title { get; set; }
        public string AlertStyle { get; set; }
        public string Message { get; set; }

        public NotificationMessage(ActionResult actionResult, string message, MessageType messageType)
        {
            _actionResult = actionResult;
            Message = message;
            AlertStyle = messageType.ToString();
            Title = ConvertMessageToTitle(messageType);
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var factory = context.HttpContext.RequestServices.GetService<ITempDataDictionaryFactory>();
            var tempData = factory.GetTempData(context.HttpContext);
            var alerts = tempData.ContainsKey("Message") ? JsonConvert.DeserializeObject<List<Alert>>((string)tempData["Message"]) : new List<Alert>();
            var alert = new Alert { Message = Message, AlertStyle = AlertStyle, Title = Title };
            alerts.Add(alert);
            tempData["Message"] = JsonConvert.SerializeObject(alerts);
            await _actionResult.ExecuteResultAsync(context);
        }

        public string ConvertMessageToTitle(MessageType messageType)
        {
            return messageType switch
            {
                MessageType.success => "Sucesso",
                MessageType.info => "Informação",
                MessageType.warning => "Atenção",
                MessageType.error => "Oops...",
                _ => "",
            };
        }
    }

    public static class ActionResultExtension
    {
        public static ActionResult Success(this ActionResult actionResult, string message = DefaultMessage.success)
        {
            return new NotificationMessage(actionResult, message, MessageType.success);
        }

        public static ActionResult Error(this ActionResult actionResult, string message = DefaultMessage.error)
        {
            return new NotificationMessage(actionResult, message, MessageType.error);
        }

        public static ActionResult Warning(this ActionResult actionResult, string message)
        {
            return new NotificationMessage(actionResult, message, MessageType.warning);
        }

        public static ActionResult Information(this ActionResult actionResult, string message)
        {
            return new NotificationMessage(actionResult, message, MessageType.info);
        }
    }
}
