namespace EFCoreFirstAPI.Models.DTOs
{
    public class ErrorResponseDTO
    {
        public int ErrorNumber { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
