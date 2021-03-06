// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics.Contracts;

namespace System
{
    partial struct Guid
    {
        // This will create a new guid.  Since we've now decided that constructors should 0-init,
        // we need a method that allows users to create a guid.
        public static Guid NewGuid()
        {
            // CoCreateGuid should never return Guid.Empty, since it attempts to maintain some
            // uniqueness guarantees.  It should also never return a known GUID, but it's unclear
            // how extensively it checks for known values.
            Contract.Ensures(Contract.Result<Guid>() != Guid.Empty);

            Guid g;
            int hr = Interop.mincore.CoCreateGuid(out g);
            // We don't expect that this will ever throw an error, none are even documented, and so we don't want to pull 
            // in the HR to ComException mappings into the core library just for this so we will try a generic exception if 
            // we ever hit this condition.
            if (hr != 0)
            {
                Exception ex = new Exception();
                ex.SetErrorCode(hr);
                throw ex;
            }
            return g;
        }
    }
}
