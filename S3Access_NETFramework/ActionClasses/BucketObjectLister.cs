using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;

namespace S3Access_NETFramework.ActionClasses
{
    public class BucketObjectLister
    {
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest2;
        private static IAmazonS3 s3Client;

        public static List<BucketObjectInfo> GetBucketObjectList(string bucketName)
        {
            if (s3Client == null)
                s3Client = S3ClientProvider.GetS3Client();

            List<BucketObjectInfo> list = new List<BucketObjectInfo>();

            var objectList = s3Client.ListObjects(bucketName);
            foreach (var obj in objectList.S3Objects)
            {
                BucketObjectInfo bucketObjectInfo = new BucketObjectInfo()
                {
                    objBucketName = obj.BucketName,
                    objETag = obj.ETag,
                    objLastModifiedDateTime = obj.LastModified,
                    objKeyName = obj.Key,
                    objSize = obj.Size,
                    objStorageClass = obj.StorageClass
                };

                list.Add(bucketObjectInfo);
            }

            return list;
        }
    }
}
