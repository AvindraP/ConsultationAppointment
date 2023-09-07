using ConsultationAppointmentClient.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
namespace ConsultationAppointmentClient
{
    public class APIGateway
    {
        private string url = "https://localhost:7159/api/Appointment";
        private HttpClient httpClient = new HttpClient();

        public List<Appointment> ListAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<Appointment>>(result);

                    if (datacol != null)
                        appointments = datacol;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error Info" + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error Info" + ex.Message);
            }
            finally { }

            return appointments;
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string json = JsonConvert.SerializeObject(appointment);
            try
            {
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Appointment>(result);

                    if (data != null)
                        appointment = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error Info" + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error Info" + ex.Message);
            }
            finally { }
            return appointment;
        }

        //public ApiResponse<Appointment> CreateAppointment(Appointment appointment)
        //{
        //    if (url.Trim().Substring(0, 5).ToLower() == "https")
        //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        //    string json = JsonConvert.SerializeObject(appointment);
        //    try
        //    {
        //        HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string result = response.Content.ReadAsStringAsync().Result;
        //            var data = JsonConvert.DeserializeObject<Appointment>(result);

        //            if (data != null)
        //                return new ApiResponse<Appointment> { Data = data };
        //        }
        //        else
        //        {
        //            string result = response.Content.ReadAsStringAsync().Result;
        //            var errorResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(result);

        //            if (errorResponse != null && errorResponse.ErrorMessage != null)
        //            {
        //                // Handle the error response and return it
        //                return new ApiResponse<Appointment> { ErrorMessage = errorResponse.ErrorMessage };
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions and return an error response
        //        return new ApiResponse<Appointment> { ErrorMessage = "An error occurred at the API Endpoint, Error Info: " + ex.Message };
        //    }

        //    // If none of the success or error conditions were met, return a generic error response
        //    return new ApiResponse<Appointment> { ErrorMessage = "An unexpected error occurred at the API Endpoint." };
        //}

        public Appointment GetAppointment(int appointmentId)
        {
            Appointment appointment = new Appointment();
            url = url + "/" + appointmentId;
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Appointment>(result);
                    if (data != null)
                        appointment = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error Info" + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error Info" + ex.Message);
            }
            finally { }
            return appointment;
        }

        public void UpdateAppointment(Appointment appointment)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            int appointmentId = appointment.AppointmentId;

            url = url + "/" + appointmentId;
            string json = JsonConvert.SerializeObject(appointment);

            try
            {
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint Info.  " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred at the API Endpoint, Error Info.  " + ex.Message);
            }
            finally { }

            return;
        }

        public void DeleteAppointment(int AppointmentId)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            url = url + "/" + AppointmentId;

            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API end point, Error Info " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API end point, Error Info:  " + ex.Message);
            }
            finally { }

            return;
        }
    }
}