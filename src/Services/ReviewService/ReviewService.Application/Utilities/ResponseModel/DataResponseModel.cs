namespace Core.Utilities.Results
{
    public class DataResponseModel<T> : ResponseModel, IDataResponseModel<T>
    {
        public DataResponseModel(bool success, string message, T data) : base(success, message)
        {
            Data = data;
        }
        public DataResponseModel(bool success, T data) : base(success)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
