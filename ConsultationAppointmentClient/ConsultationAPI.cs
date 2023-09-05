using ConsultationAppointmentClient.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
namespace ConsultationAppointmentClient
{
    public interface factorypatternConsulatationAPI
    {
        List<Consultant> ListConsultants();

    }
    public class ConsultationAPI : factorypatternConsulatationAPI
    {
        private string url = "https://localhost:7159/api/Consultant";
        private HttpClient httpClient = new HttpClient();

        public List<Consultant> ListConsultants()
           {
        List<Consultant> consultants = new List<Consultant>();
        if (url.Trim().Substring(0, 5).ToLower() == "https")
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        try
        {
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var datacol = JsonConvert.DeserializeObject<List<Consultant>>(result);

                if (datacol != null)
                    consultants = datacol;
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

        return consultants;
    }

    public Consultant CreateConsultant(Consultant consultant)
    {
        if (url.Trim().Substring(0, 5).ToLower() == "https")
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        string json = JsonConvert.SerializeObject(consultant);
        try
        {
            HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Consultant>(result);

                if (data != null)
                    consultant = data;
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
        return consultant;
    }

    public Consultant GetConsultant(int consultantId)
    {
        Consultant consultant = new Consultant();
        url = url + "/" + consultantId;
        if (url.Trim().Substring(0, 5).ToLower() == "https")
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        try
        {
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Consultant>(result);
                if (data != null)
                    consultant = data;
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
        return consultant;
    }

    public void UpdateConsultant(Consultant consultant)
    {
        if (url.Trim().Substring(0, 5).ToLower() == "https")
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        int consultantId = consultant.ConsultantId;

        url = url + "/" + consultantId;
        string json = JsonConvert.SerializeObject(consultant);

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

    public void DeleteConsultant(int consultantId)
    {
        if (url.Trim().Substring(0, 5).ToLower() == "https")
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        url = url + "/" + consultantId;

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
