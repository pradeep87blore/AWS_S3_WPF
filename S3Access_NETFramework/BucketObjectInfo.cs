using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;

namespace S3Access_NETFramework.ActionClasses
{
    public class BucketObjectInfo
    {
        public string objKeyName = "";
        public string objBucketName = "";
        public DateTime objLastModifiedDateTime;
        public long objSize = 0;
        public S3StorageClass objStorageClass;
        public string objETag;

        //public BucketObjectInfo( string keyName, string bucketName, DateTime lastModifiedDateTime,
        //long objectSize , S3StorageClass objectStorageClass, string ETag)
        //{
        //    objKeyName = keyName;
        //    objBucketName = bucketName;
        //    objLastModifiedDateTime = lastModifiedDateTime;
        //    objSize = objectSize;
        //    objStorageClass = objectStorageClass;
        //    objETag = ETag;
        //}

        public override string ToString()
        {
            return string.Format("FileName: {0}, FileSize: {1}, LastModified: {2}",
                objKeyName, objSize, objLastModifiedDateTime);
        }
    }
}
