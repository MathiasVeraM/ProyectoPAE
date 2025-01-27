using PAEAppMaui.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PAEAppMaui.Services
{
    public class LoginService : ILoginInterface
    {
        public async Task<User> Login(string email, string password)
        {
            try
            {
                var cliente = new HttpClient();
                string localhostUrl = "http://localhost:5010/api/users/login/" + email + "/" + password;
                cliente.BaseAddress = new Uri(localhostUrl);
                HttpResponseMessage response = await cliente.GetAsync(cliente.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    User user = await response.Content.ReadFromJsonAsync<User>();
                    return await Task.FromResult(user);
                }
                return null;
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message,"Ok");
                return null;
            }
        }

        public async Task<User> Register(string name, string email, string password)
        {
            try
            {
                var cliente = new HttpClient();
                string localhostUrl = "http://localhost:5010/api/users";
                var user = new { Name = name, Email = email, Password = password };
                var json = JsonSerializer.Serialize(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await cliente.PostAsync(localhostUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<User>(responseContent);
                }

                return null;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }
    }
}
