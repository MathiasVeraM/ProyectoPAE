using PAEAppMaui.Models;
using System.Net.Http.Json;

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
                await Shell.Current.DisplayAlert("Error" + ex.Message + "Ok");
                return null;
            }
        }
    }
}
