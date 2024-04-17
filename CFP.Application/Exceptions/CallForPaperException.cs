namespace CFP.Application.Exceptions
{
    public class CallForPaperException : Exception
    {
        public int StatusCode { get; }
        public object Value { get; }

        public CallForPaperException(int statusCode, object value = null) =>
            (StatusCode, Value) = (statusCode, value);
    }
}
