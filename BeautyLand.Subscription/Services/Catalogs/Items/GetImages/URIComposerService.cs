namespace BeautyLand.Subscription.Services.Catalogs.Items.GetImages
{
    public class URIComposerService : IURIComposerService
    {
        public string Execute(string source)
        {
            return "https://localhost:44320/" + source.Replace("\\","//");
        }
    }

}
