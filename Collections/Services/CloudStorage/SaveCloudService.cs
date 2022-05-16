using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

namespace CollectionPR.Services.Classes;

public class SaveCloudService : ISaveFileAsync
{
    private readonly IConfiguration configuration;
    private readonly GoogleCredential googleCredential;

    private readonly StorageClient storageClient;

    private readonly string bucketName;

    public SaveCloudService(IConfiguration configuration)
    {
        this.configuration = configuration;
        googleCredential = GoogleCredential.FromFile(configuration.GetValue<string>("GoogleCredentialFile"));
        storageClient = StorageClient.Create(googleCredential);
        bucketName = configuration.GetValue<string>("GoogleCloudStorageBucket");
    }

    public string GetFileName()
    {
        var fileName = Guid.NewGuid().ToString();
        return fileName;
    }

    public async Task<string> SaveFileAsync(IFormFile file)
    {
        var originalFileName = Path.GetFileName(file.FileName);
        var extension = originalFileName.Substring(originalFileName.LastIndexOf('.') + 1, originalFileName.Length - 1 - originalFileName.LastIndexOf('.'));
        var uniqueFileName = GetFileName();
        await using (var stream = File.Create(uniqueFileName + '.' + extension))
        {
            await file.CopyToAsync(stream);
            var resultingName = uniqueFileName + '.' + extension;
            var dataObject = await storageClient.UploadObjectAsync(bucketName, resultingName, null, stream);
            resultingName = dataObject.MediaLink;
            //File.Delete(resultingName);
            return resultingName;
        }       
    }
}