namespace E_commerceApi.ResponseModel
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ResponseModel(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static ResponseModel<T> CreateSuccess(T data, string message = "Done Successfully")
        {
            return new ResponseModel<T>(true, message, data);
        }

        public static ResponseModel<T> CreateFailure(string message)
        {
            return new ResponseModel<T>(false, message, default);
        }
    }

}
