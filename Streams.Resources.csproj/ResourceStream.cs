using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams.Resources
{
    public class ResourceReaderStream : Stream
    {
        private Stream stream;
        private byte[] key;
        private byte[] dataSource;
        private IEnumerator data;
        private int positionOfValue;

        public ResourceReaderStream(Stream stream, string key)
        {
            this.stream = new BufferedStream(stream, 1024);
            this.key = Encoding.ASCII.GetBytes(key);

            dataSource = new byte[1024];
            data = dataSource.GetEnumerator();
        }

        private bool isFirstTime = true;
        private bool isEndOfValue = false;

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (isFirstTime)
            {
                stream.Read(dataSource, offset, 1024);
                SeekValue();
                isFirstTime = false;
            }

            if (isEndOfValue)
                return 0;

            int i = 0;
            int bufferOffset = 0;
            byte lastValue = 1;
            if (positionOfValue > 0)
            {
                data.MoveNext();
                while (true)
                {
                    buffer[i + bufferOffset] = (byte) data.Current;

                    if (lastValue == 0)
                    {
                        if ((byte)data.Current == 0)
                            bufferOffset--;
                    }

                    lastValue = (byte) data.Current;
                    i++;

                    if (i + bufferOffset == buffer.Length - 1)
                        break;

                    if (!data.MoveNext())
                    {
                        stream.Read(dataSource, offset, 1024);
                        data = dataSource.GetEnumerator();
                        data.MoveNext();
                    }

                    if ((byte)data.Current == 1 && lastValue == 0)
                    {
                        isEndOfValue = true;
                        i--;
                        break;
                    }
                }
            }
            
            return i + bufferOffset;
        }

        private void SeekValue()
        {
            int i = 0;
            int position = 0;
            positionOfValue = -1;
            while(data.MoveNext())
            {
                if (i < key.Length)
                {
                    if ((byte) data.Current == key[i])
                    {
                        i++;
                    }
                    else i = 0;
                }
                else
                {
                    positionOfValue = position + 2;
                    data.MoveNext();
                    break;
                }
                
                position++;
            }
        }

        private byte ReadFieldValue()
        {
            data.MoveNext();
            return (byte) data.Current;
        }

        public override void Flush()
        {
            // nothing to do
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead => throw new NotImplementedException();

        public override bool CanSeek => throw new NotImplementedException();

        public override bool CanWrite => throw new NotImplementedException();

        public override long Length => throw new NotImplementedException();

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
