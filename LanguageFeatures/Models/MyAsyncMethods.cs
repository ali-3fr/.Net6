namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpTask = await client.GetAsync("http://Apress.Com");

            return httpTask.Content.Headers.ContentLength;
           //return httpTask.ContinueWith(task => { return task.Result.Content.Headers.ContentLength; });
        }
    }
}
