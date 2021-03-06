﻿using System;
using Microsoft.Build.Framework;

namespace DM.Emkay.S3
{
    public class DeleteBucket : S3Base
    {
        public DeleteBucket()
            : this(new S3ClientFactory(), DefaultRequestTimeout, DefaultBufferSizeKilobytes, null)
        { }

        [Obsolete("Only for test purpose!")]
        internal DeleteBucket(IS3ClientFactory s3ClientFactory, int timeoutMilliseconds, int bufferSizeKilobytes, ITaskLogger logger)
            : base(s3ClientFactory, timeoutMilliseconds, bufferSizeKilobytes, logger)
        { }

        public override bool Execute()
        {
            try
            {
                Client.DeleteBucket(Bucket);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogMessage(MessageImportance.High,
                                  string.Format("Delete bucket has failed because of {0}", ex.Message));
                return false;
            }
        }
    }
}