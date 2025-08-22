namespace WEB.Helpers.Messages
{
    public class ErrorMessage
    {
        private readonly ILogger<ErrorMessage> _logger;

        public ErrorMessage(ILogger<ErrorMessage>? logger = null)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public string ErrorMessageException(Exception ex)
        {
            string? errorMessage = null;

            if (ex.InnerException is not null)
            {
                errorMessage = ex.InnerException.InnerException?.Message ?? ex.InnerException.Message;
            }

            errorMessage = errorMessage ?? ex.Message;

            _logger.LogError("Erro encontrado: " + errorMessage);

            return errorMessage;
        }
    }
}
