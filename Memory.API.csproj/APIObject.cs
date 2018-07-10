using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.API
{
    public class APIObject : IDisposable
    {
        int id;

        public APIObject(int id)
        {
            this.id = id;
            MagicAPI.Allocate(id);
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    MagicAPI.Free(id);
                }

                disposedValue = true;
            }
        }

        ~APIObject()
        {        
           Dispose(true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
