// using Azure.Storage.Blobs;
using CollectionPR.Services.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

namespace CollectionPR.Services.Classes;

public class DeleteCloudService : IDeleteCloud
{
    private readonly IConfiguration configuration;
    private readonly GoogleCredential googleCredential;

    private readonly StorageClient storageClient;

    private readonly string bucketName;

    public DeleteCloudService(IConfiguration configuration)
    {
        this.configuration = configuration;
        googleCredential = GoogleCredential.FromFile(configuration.GetValue<string>("GoogleCredentialFile"));
        storageClient = StorageClient.Create(googleCredential);
        bucketName = configuration.GetValue<string>("GoogleCloudStorageBucket");
    }

    public async void DeleteFromCloud(string? fileName)
    {
        await storageClient.DeleteObjectAsync(bucketName, fileName);   
    }

}