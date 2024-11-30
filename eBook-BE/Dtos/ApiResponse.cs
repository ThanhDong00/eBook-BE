namespace eBook_BE.Dtos
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool IsSuccess {  get; set; } = true;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
