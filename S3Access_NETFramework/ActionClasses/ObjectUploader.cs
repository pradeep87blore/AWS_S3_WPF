using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Access_NETFramework
{
    class ObjectUploader
    {        
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.EUWest1;

        private static IAmazonS3 s3Client;       

        public static bool WriteAnObject(string filePath, string bucketName)
        {
            try
            {
                var fileInfo = filePath.Split('\\');

                if (s3Client == null)
                    s3Client = S3ClientProvider.GetS3Client();

                string keyName = fileInfo[fileInfo.Length - 1];
                // 1. Put object-specify only key name for the new object.
                var request = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName
                };
                
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    request.InputStream = stream;

                    // Put object
                    PutObjectResponse response = s3Client.PutObject(request);

                    if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                        return true;
                }
                
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine(
                        "Error encountered ***. Message:'{0}' when writing an object"
                        , e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when writing an object"
                    , e.Message);
            }

            return false;
        }
    }
}
