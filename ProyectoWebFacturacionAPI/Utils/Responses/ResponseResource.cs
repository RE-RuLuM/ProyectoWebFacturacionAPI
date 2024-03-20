namespace ProyectoWebFacturacionAPI.Utils.Responses
{
    public class ResponseResource<T>
    {
        public required string Msg { get; set; }
        public T? Data { get; set; }
    }
}
