using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Access_NETFramework
{
    // This class shall be used to pass around the bucket info
    public class BucketInfo
    {
        public string BucketName = "";
        public string BucketRegion = "";
        public string BucketOwner = "";
        public bool BucketVersioningEnabled = false;
        public bool BucketPublicAccessEnabled = false;

        public BucketInfo(string bName, string bRegion = null, string bOwner = null, 
            bool bVersioningEnabled = false, bool bPublicAccessEnabled = false)
        {
            BucketName = bName;
            BucketRegion = bRegion;
            BucketOwner = bOwner;
            BucketVersioningEnabled = bVersioningEnabled;
            BucketPublicAccessEnabled = bPublicAccessEnabled;
        }

        public override string ToString()
        {
            return string.Format("{0} bucket is in region: [{1}]. Bucket Owner is [{2}]",
                BucketName, BucketRegion, BucketOwner);
        }
    }
}
