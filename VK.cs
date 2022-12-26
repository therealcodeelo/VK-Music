using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.Abstractions;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;

namespace VK_Music
{
    public static class VK
    {
        private static readonly IVkApi? api;
        public static bool IsAuth => api.IsAuthorized;
        static VK()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAudioBypass();
            api = new VkApi(serviceCollection);
        }
        public static bool CheckToken()
        {
            if(File.Exists("Token.txt"))
            {
                api?.Authorize(new ApiAuthParams
                {
                    AccessToken = File.ReadAllText("Token.txt")
                });
                return true;
            }
            return false;
        }
        public static void SignIn(string login, string password)
        {
            if (api == null)
                return;
            api.Authorize(new ApiAuthParams
            {
                Login= login,
                Password= password
            });
            if(IsAuth)
            {
                File.WriteAllText("Token.txt", api.Token);
            }
        }
        public static List<Track> GetListOfTracks()
        {
            var list = new List<Track>();
            if (api == null)
                return null;
            foreach (var item in api.Audio.Get(new VkNet.Model.RequestParams.AudioGetParams { Count = 10}))
            {
                var newTrack = new Track
                {
                    Artist = item.Artist,
                    Title = item.Title,
                    Duration = (item.Duration / 60).ToString() + ":" + (item.Duration % 60 < 10 ? "0"+ item.Duration % 60 : item.Duration % 60)
                };
                list.Add(newTrack);
            }
            return list;
        }
    }
}
