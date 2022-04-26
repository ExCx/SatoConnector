using Newtonsoft.Json;
using SatoConnector.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SatoConnector
{
    public class ServerManager
    {
        private static HttpClient client;
        public IProgress<string> reporter;
        CancellationTokenSource cancelRenew;

        public ServerManager(IProgress<string> reporter)
        {
            this.reporter = reporter;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://" + Settings.Default.SunucuIp + "/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(5);
        }

        class AbpResult<T>
        {
            public T Result { get; set; }
            public bool Success { get; set; }
        }

        class AuthenticateInput
        {
            public string TenancyName { get; set; }
            public string UsernameOrEmailAddress { get; set; }
            public string Password { get; set; }
        }

        class AuthenticateResponse
        {
            public string Result { get; set; }
        }

        public async Task<bool> Authenticate()
        {
            var input = new AuthenticateInput
            {
                TenancyName = Settings.Default.MusteriAdi,
                UsernameOrEmailAddress = Settings.Default.KullaniciAdi,
                Password = Settings.Default.Sifre
            };
            try
            {
                var response = await client.PostAsJsonAsync("api/Account/Authenticate", input);
                response.EnsureSuccessStatusCode();
                var token = (await response.Content.ReadAsAsync<AuthenticateResponse>()).Result;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            catch
            {
                reporter.Report(string.Format("Sunucu Hatası|Sunucuya bağlanılamadı"));
                return false;
            }
            if (cancelRenew != null)
                cancelRenew.Cancel();
            cancelRenew = new CancellationTokenSource();
            var authRenew = RenewAuth(cancelRenew.Token);
            reporter.Report(string.Format("Sunucu Bağlantısı|Sunucu bağlantısı kuruldu"));
            return true;
        }

        public async Task RenewAuth(CancellationToken token)
        {
            var sec = 0;
            while (!token.IsCancellationRequested && sec <= 3600)
            {
                try
                {
                    await Task.Delay(1000, token);
                    sec++;
                }
                catch (OperationCanceledException e)
                {
                    return;
                }
            }
            reporter.Report(string.Format("Sunucu Bağlantısı|Sunucu bağlantısı yenileniyor"));
            await Authenticate();
        }

        public class AssetGetAllInput
        {
            public string LabelingState { get; set; }
            public string Sorting { get; set; }
        }
        public class AssetPrintDto
        {
            public long Id { get; set; }
            public string AssetTypeDefinition { get; set; }

            public string RemoteId { get; set; }
            public string RemoteId2 { get; set; }
            public string RegistrationCode { get; set; }
            public string RFIDCode { get; set; }

            public string Features { get; set; }
            public string BrandNameDefinition { get; set; }
            public string ModelNameDefinition { get; set; }
            public string BudgetTypeDefinition { get; set; }
            public string SerialNo { get; set; }

            public string AssignedPersonNameSurname { get; set; }
            public string AssignedLocationName { get; set; }

            public DateTime? LabelingDateTime { get; set; }
        }

        public async Task<List<AssetPrintDto>> GetAllWaitingForPrint()
        {
            var input = new AssetGetAllInput { LabelingState = "waiting", Sorting = "id desc" };
            try
            {
                var response = await client.PostAsJsonAsync("api/services/app/asset/GetAllForPrint", input);
                response.EnsureSuccessStatusCode();
                var st = await response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<AbpResult<IEnumerable<AssetPrintDto>>>(st);
                return answer.Result.ToList();
            }
            catch (Exception ex)
            {
                reporter.Report(string.Format("Sunucu Hatası|{0}", ex.Message));
                return null;
            }
        }
        public class LabelingInput
        {
            public long[] AssetIds { get; set; }
            public string LabelingState { get; set; }
        }

        public async Task UpdateLabeledState(List<AssetPrintDto> assetsToPrint)
        {
            var input = new LabelingInput { AssetIds = assetsToPrint.Select(x => x.Id).ToArray(), LabelingState = "true" };
            try
            {
                var response = await client.PostAsJsonAsync("api/services/app/labeling/UpdateLabeledState", input);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                reporter.Report(string.Format("Sunucu Hatası|{0}", ex.Message));
            }
        }
    }
}
