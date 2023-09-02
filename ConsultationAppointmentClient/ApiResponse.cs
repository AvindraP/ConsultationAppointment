namespace ConsultationAppointmentClient
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
